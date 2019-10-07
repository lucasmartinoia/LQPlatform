using LQ.Support.Config;
using QuickFix;
using System;
using QuickFix.Fields;
using QuickFix.Helper;
using QuickFix.Transport;
using System.IO;
using System.Text;
using LQ.Support;

namespace LQ.Primary
{
    public class QuickFixApp : IApplication
    {
        
        private static string _usuario;
        private static string _password;
        private static string _rutaConfig;
        
        private bool _resetSession = false;

        private SocketInitiator initiator = null;
        static Session _session = null;


        public QuickFixApp()
        {
            _usuario = ReadSettings.ReadQueue("BYMA_USER_FIX");
            _password = ReadSettings.ReadQueue("BYMA_PASS_FIX");
            _rutaConfig = ReadSettings.ReadQueue("BYMA_PATH_FIX");
        }

        #region IApplication
        public void OnCreate(SessionID sessionID)
        {
            if (GlobalSettings.SaveFile)
                LoggingService.Save((int)EnumLogType.Information, string.Format("OnCreate: {0}", sessionID));
            //log.WriteLog(string.Format("onCreate: {0}", sessionID));

            _session = Session.LookupSession(sessionID);

        }
        public void OnLogon(SessionID sessionID)
        {
            LoggingService.Save((int)EnumLogType.Information, string.Format("Logon: {0}", sessionID));
        }
        public void OnLogout(SessionID sessionID)
        {
            LoggingService.Save((int)EnumLogType.Information, string.Format("OnLogout: {0}", sessionID));
        }
        public void FromAdmin(Message message, SessionID sessionID)
        {
            SwitchMessages(message, MsgDirection.RECEIVE, "FromAdmin");
        }
        public void ToAdmin(Message message, SessionID sessionID)
        {
            MsgType mt = new MsgType();
            message.Header.GetField(mt);

            if (mt.getValue() == MsgType.LOGON)
            {
                if (!_usuario.Equals("") && !_password.Equals(""))
                {
                    message.SetField(new Username(_usuario));
                    message.SetField(new Password(_password));
                }

                if (_resetSession)
                {
                    message.SetField(new ResetSeqNumFlag(true));
                }
                SwitchMessages(message, MsgDirection.SEND, "ToAdmin");
            }
            else
            {
                SwitchMessages(message, MsgDirection.SEND, "ToAdmin");
            }
        }
        public void FromApp(Message message, SessionID sessionID)
        {
            SwitchMessages(message, MsgDirection.RECEIVE, "FromApp");
        }
        public void ToApp(Message message, SessionID sessionID)
        {
            try
            {
                bool possDupFlag = false;
                if (message.Header.IsSetField(Tags.PossDupFlag))
                {
                    possDupFlag = QuickFix.Fields.Converters.BoolConverter.Convert(
                        message.Header.GetField(Tags.PossDupFlag)); /// FIXME
                }
                if (possDupFlag)
                    throw new DoNotSend();
            }
            catch (FieldNotFoundException)
            { }

            SwitchMessages(message, MsgDirection.SEND, "ToApp");
        }
        #endregion

        private void SwitchMessages(Message message, char msgDirection, string method)
        {

            string msgType = message.Header.GetString(Tags.MsgType);
            ///* Otra manera
            // * 
            // * MsgType mt = new MsgType();
            // * message.Header.GetField(mt);
            //*/

            string showInfo = string.Format("{0} {1} {2} {3} ({4})",
                DateTime.Now.ToString("HH:mm:ss.fff"),
                msgDirection == MsgDirection.RECEIVE ? "<--" : "-->",
                message.ToString(),
                QuickFixHelper.GetMsgTypeByValue(msgType),
                method);

            switch (msgType)
            {
                case MsgType.REJECT:
                case MsgType.BUSINESSMESSAGEREJECT:
                    break;
                case MsgType.HEARTBEAT:
                    break;
                case MsgType.EXECUTION_REPORT:
                    QuickFixMessageParser.ParseExecutionReport(message);
                    break;
                case MsgType.TRADE_CAPTURE_REPORT:
                    QuickFixMessageParser.ParseTradeCaptureReport(message);
                    break;
                case MsgType.NEWS:
                case MsgType.IOI:
                    break;
                case MsgType.SECURITYLIST:
                    try
                    {
                        bool worked = QuickFixMessageParser.ParseSecurityListMessage(message);
                        if (worked && QuickFixMessageParser.ListInstrumentByma.Count == message.GetInt(Tags.TotalNumSecurities))
                        {
                            InstrumentByma.Truncate();
                            InstrumentByma.SaveMassive(QuickFixMessageParser.ListInstrumentByma);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggingService.Save((int)EnumLogType.Error, ex.Message);
                    }

                    break;

                case MsgType.MARKETDATASNAPSHOTFULLREFRESH:
                    //MessageParser.ParseMarketDataSnapShotFullRefreshMessage(message);
                    //UpdateFormDataCboMarketData();
                    break;

                case MsgType.MARKETDATAINCREMENTALREFRESH:
                    //MessageParser.ParseMarketDataIncrementalRefreshMessage(message);
                    //UpdateFormDataCboMarketData();
                    break;
                case MsgType.NEWORDERSINGLE:
                case MsgType.SECURITYLISTREQUEST:

                    break;
                default:
                    break;
            }
            LoggingService.Save((int)EnumLogType.Information, showInfo);
        }

      

        private void SendMessage(Message m)
        {
            Session session = _session;

            if (session != null)
            {
                m.Header.SetField(new DeliverToCompID("FGW"));
                session.Send(m);
            }
            else
            {
                // This probably won't ever happen.
                if (GlobalSettings.SaveFile)
                    LoggingService.Save((int)EnumLogType.Error, "Can't send message: session not created.");
                //log.WriteLog("Can't send message: session not created.");
            }
        }

        internal void Close()
        {
            if (initiator != null)
            {
                _session.Logout("porque si");
                initiator.Stop(true);
                initiator.Dispose();
                initiator = null;
            }
        }

        internal void Connect()
        {
            try
            {
                StreamReader reader = GetConfiguration();
                SessionSettings settings = new SessionSettings(reader);
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new ScreenLogFactory(settings);
                initiator = new SocketInitiator(this, storeFactory, settings, logFactory);

                initiator.Start();
            }
            catch (Exception ex)
            {
                LoggingService.Save((int)EnumLogType.Error, ex.Message);
            }
        }

        private StreamReader GetConfiguration()
        {
            string text;
            using (StreamReader reader = File.OpenText(_rutaConfig))
            {
                text = reader.ReadToEnd();
            }

            Market market = Market.Get((int)EnumMarkets.BYMA);

            DateTime MarketStartTime = DateTime.ParseExact(market.MarketStartTime, "HH:mm", null, System.Globalization.DateTimeStyles.None);
            DateTime MarketEndTime = DateTime.ParseExact(market.MarketEndTime, "HH:mm", null, System.Globalization.DateTimeStyles.None);

            Parameter parameter = Retrieve.GetParameterValue(Parameter.BYMA_CONN_OPEN_MIN_BEFORE);
            int MinutesBefore = 0;
            if (parameter != null)
            {
                bool CanParse = Int32.TryParse(parameter.Value,out MinutesBefore);
                if(!CanParse)
                {
                    LoggingService.Save((int)EnumLogType.Error, "TABLE - Parameters | NAME - BYMA_CONN_OPEN_MIN_BEFORE | MAL CARGADO, DEBE SER UN ENTERO");
                }
            }else
            {
                LoggingService.Save((int)EnumLogType.Error, "TABLE - Parameters | NAME - BYMA_CONN_OPEN_MIN_BEFORE | NO ESTA CARGADO");
            }
            text = text.Replace("[STARTTIME]", MarketStartTime.AddMinutes(-MinutesBefore).ToString("HH:mm")).Replace("[ENDTIME]", MarketEndTime.ToString("HH:mm"));
            // convert string to stream
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new MemoryStream(byteArray);

            return new StreamReader(stream);
        }

        /// <summary>
        /// Order Roting
        /// MsgType = D
        /// </summary>
        /// <param name="bymaOrder"></param>
        internal void NewOrderSingle(BymaOrder bymaOrder)
        {
            SendMessage(QuickFixMessages.NewOrderSingle(bymaOrder));
        }

        /// <summary>
        /// Order Roting
        /// MsgType = F
        /// </summary>
        /// <param name="orderNewSend"></param>
        internal void OrderCancelRequest(BymaOrderCancellation bymaOrderCancellation)
        {
            SendMessage(QuickFixMessages.OrderCancelRequest(bymaOrderCancellation));
        }

        internal void SecurityListRequest()
        {
            SendMessage(QuickFixMessages.SecurityListRequest(ReadSettings.ReadQueue("BYMA_SECURITYREQID")));
        }

        internal bool IsLoggedOn()
        {
            bool returnValue = false;
            if(initiator !=null)
            {
                returnValue = initiator.IsLoggedOn;
            }
            return returnValue;
        }

        internal void LogIn()
        {
            initiator.Start();
        }
        internal void LogOut()
        {
            initiator.Stop();
        }


        /// <summary>
        /// Order Roting
        /// MsgType = D
        /// </summary>
        /// <param name="bymaOrder"></param>
        internal void OrderStatusRequest(BymaOrder bymaOrder)
        {
            SendMessage(QuickFixMessages.OrderStatusRequest(bymaOrder));
        }
    }
}