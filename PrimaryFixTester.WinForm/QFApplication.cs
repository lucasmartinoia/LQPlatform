using System;
using System.Windows.Forms;
using QuickFix.Fields;
using System.Collections.Generic;
using QuickFix;
using QuickFix.Transport;
using System.Reflection;
using System.Linq;
using QuickFix.FIX50SP2;
using System.Drawing;
using Entity;

namespace BymaFixTester.WinForm
{
    public class QFApplication : MessageCracker, QuickFix.IApplication
    {

        static Control _control = null;
        private static string _usuario;
        private static string _password;
        private bool _resetSession = false;

        // This variable is a kludge for developer test purposes.  Don't do this on a production application.
        //public IInitiator MyInitiator = null;

        private SocketInitiator initiator = null;

        #region IApplication interface overrides

        static Session _session = null;

        public void OnCreate(SessionID sessionID)
        {
            UpdateDisplay(string.Format("onCreate: {0}", sessionID), Color.Black);

            _session = Session.LookupSession(sessionID);

        }

        public void OnLogon(SessionID sessionID)
        {
            UpdateDisplay("Logon - " + sessionID.ToString(), Color.Black);
        }
        public void OnLogout(SessionID sessionID)
        {
            UpdateDisplay("Logout - " + sessionID.ToString(), Color.Black);
        }

        public void FromAdmin(QuickFix.Message message, SessionID sessionID)
        {
            SwitchMessages(message, MsgDirection.RECEIVE, "FromAdmin");
        }
        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
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



        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            SwitchMessages(message, MsgDirection.RECEIVE, "FromApp");
        }

        private void SwitchMessages(QuickFix.Message message, char msgDirection, string method)
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
                QFHelper.GetMsgTypeByValue(msgType),
                method);

            switch (msgType)
            {
                case MsgType.REJECT:
                case MsgType.BUSINESSMESSAGEREJECT:
                    UpdateDisplay(showInfo, Color.Red);
                    break;
                case MsgType.HEARTBEAT:
                    //updateDisplay(DateTime.Now.ToString("HH:mm:ss.fff") + " <-- " + message.ToString() + " " + GetMsgTypeByValue(msgType) + " (FromApp)");
                    break;
                case MsgType.EXECUTION_REPORT:
                    UpdateDisplay(showInfo, Color.Green);
                    if (MessageParser.ParseExecutionReport(message))
                    {
                        UpdateFormDataDGV();
                    }

                    break;
                case MsgType.TRADE_CAPTURE_REPORT:
                    UpdateDisplay(showInfo, Color.Violet);
                    if (MessageParser.ParseTradeCaptureReportMessage(message))
                    {
                        UpdateFormDataDGV();
                    }
                    break;
                case MsgType.NEWS:
                case MsgType.IOI:
                    UpdateDisplay(showInfo, Color.Green);
                    break;
                case MsgType.SECURITYLIST:
                    UpdateDisplay(showInfo, Color.Blue);
                    MessageParser.ParseSecurityListMessage(message);
                    if (MessageParser.OrderMarketDataRecives.Count == message.GetInt(Tags.TotalNumSecurities))
                    {
                        MessageParser.OrderMarketDataRecives = MessageParser.OrderMarketDataRecives.OrderBy(x => x.SecurityID_48).ToList();
                        UpdateCboSecurityList();
                    }
                    break;

                case MsgType.MARKETDATASNAPSHOTFULLREFRESH:
                    UpdateDisplay(showInfo, Color.Blue);
                    MessageParser.ParseMarketDataSnapShotFullRefreshMessage(message);
                    UpdateFormDataCboMarketData();
                    break;

                case MsgType.MARKETDATAINCREMENTALREFRESH:
                    UpdateDisplay(showInfo, Color.Blue);
                    MessageParser.ParseMarketDataIncrementalRefreshMessage(message);

                    UpdateFormDataCboMarketData();
                    break;
                case MsgType.NEWORDERSINGLE:
                case MsgType.SECURITYLISTREQUEST:
                    UpdateDisplay(showInfo, Color.Blue);

                    break;
                //case MsgType.markedata:
                //    updateDisplay(showInfo, Color.Blue);

                //    break;
                default:
                    UpdateDisplay(showInfo, Color.Black);
                    break;
            }
        }

        public void ToApp(QuickFix.Message message, SessionID sessionID)
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

        #region Custom Methods & Variables for Sample application  

        public delegate void ThreadSafeFormControl(string text, Color color);
        protected static ThreadSafeFormControl _tsfc;
        public void RegisterFormController(ThreadSafeFormControl fc)
        {
            if (_tsfc == null)
            {
                _tsfc += fc;
            }
        }
        protected void UpdateDisplay(string s, Color color)
        {
            if (_control.InvokeRequired)
            {
                _control.Invoke(_tsfc, new Object[] { s, color });
            }
            else
            {
                _tsfc(s, color);
            }
        }
        private void UpdateDisplayInfo(string Msg)
        {
            UpdateDisplay(Msg, Color.Fuchsia);
        }

        /****************************************************************/
        public delegate void ThreadSafeFormDataControl();
        protected static ThreadSafeFormDataControl _tsfdc;

        public void RegisterCboSecurityListData(ThreadSafeFormDataControl fc)
        {
            if (_tsfdc == null)
            {
                _tsfdc += fc;
            }
        }
        protected void UpdateCboSecurityList()
        {
            if (_control.InvokeRequired)
            {
                _control.Invoke(_tsfdc);
            }
            else
            {
                _tsfdc();
            }
        }

        /****************************************************************/
        protected static ThreadSafeFormDataControl _tsfdcCMD;
        public void RegisterCboMarketData(ThreadSafeFormDataControl fc)
        {
            if (_tsfdcCMD == null)
            {
                _tsfdcCMD += fc;
            }
        }
        protected void UpdateFormDataCboMarketData()
        {
            if (_control.InvokeRequired)
            {
                _control.Invoke(_tsfdcCMD);
            }
            else
            {
                _tsfdcCMD();
            }
        }
        /****************************************************************/
        protected static ThreadSafeFormDataControl _tsfdcDGV;
        public void RegisterDGV(ThreadSafeFormDataControl fc)
        {
            if (_tsfdcDGV == null)
            {
                _tsfdcDGV += fc;
            }
        }
        protected void UpdateFormDataDGV()
        {
            if (_control.InvokeRequired)
            {
                _control.Invoke(_tsfdcDGV);
            }
            else
            {
                _tsfdcDGV();
            }
        }

        #endregion

        private void SendMessage(QuickFix.Message m)
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
                UpdateDisplay("Can't send message: session not created.", Color.Black);
            }
        }


        public void NewOrderSingle50SP2(NewOrderSingleSend orderNewSend)
        {
            UpdateDisplayInfo("NewOrderSingle");

            OrdType ordType = new OrdType(orderNewSend.OrderType_40);
            NewOrderSingle newOrderSingle = new NewOrderSingle(new ClOrdID(orderNewSend.ClOrdID_11), new Side(orderNewSend.Side_54), new TransactTime(DateTime.UtcNow), ordType)
            {
                OrderQty = new OrderQty(orderNewSend.Quantity_53),
                TimeInForce = new TimeInForce(orderNewSend.TimeInForce_59),
                Currency = new Currency(orderNewSend.Currency_15),
                Account = new Account(orderNewSend.Account_1),
                Symbol = new Symbol(orderNewSend.Symbol_55),
                SecurityType = new SecurityType(orderNewSend.SecurityType_167),
                SecurityExchange = new SecurityExchange(orderNewSend.SecurityExchange_207),
                CFICode = new CFICode(orderNewSend.CFICode_461),
                OrderCapacity = new OrderCapacity(orderNewSend.OrderCapacity_528),
            };

            if (orderNewSend.TimeInForce_59 == TimeInForce.GOOD_TILL_DATE)
            {
                newOrderSingle.ExpireDate = new ExpireDate(orderNewSend.ExpireDate_432);
            }

            switch (ordType.getValue())
            {
                case OrdType.LIMIT:
                    newOrderSingle.Set(new Price(orderNewSend.Price_44));
                    break;
                case OrdType.STOP_LIMIT:
                    newOrderSingle.Set(new Price(orderNewSend.Price_44));
                    newOrderSingle.Set(new StopPx(orderNewSend.StopPx_99));
                    break;
                case OrdType.STOP:
                    newOrderSingle.Set(new StopPx(orderNewSend.StopPx_99));
                    break;
                case OrdType.MARKET:
                    //newOrderSingle.Set(new Price(0));
                    break;
                default:
                    break;
            }


            //if (ordType.getValue() == OrdType.LIMIT || ordType.getValue() == OrdType.STOP_LIMIT)
            //    newOrderSingle.Set(new Price(orderNewSend.Price_44));
            //if (ordType.getValue() == OrdType.STOP || ordType.getValue() == OrdType.STOP_LIMIT)
            //    newOrderSingle.Set(new StopPx(orderNewSend.StopPx_99));

            //NewOrderSingle.NoPartyIDsGroup.NoPartySubIDsGroup subID = new NewOrderSingle.NoPartyIDsGroup.NoPartySubIDsGroup();
            //subID.PartySubID = new PartySubID("Sub ID");
            //subID.PartySubIDType= new PartySubIDType(PartySubIDType.EMAIL_ADDRESS);


            //SettlmntTyp = new SettlmntTyp(settlmntTyp);


            NewOrderSingle.NoPartyIDsGroup parties = new NewOrderSingle.NoPartyIDsGroup
            {
                PartyID = new PartyID(orderNewSend.PartyID_448),
                PartyIDSource = new PartyIDSource(orderNewSend.PartyIDSource_447),//partyIDSource
                PartyRole = new PartyRole(orderNewSend.PartyRole_452)//partyRole
            };
            //parties.AddGroup(subID);

            newOrderSingle.AddGroup(parties);

            newOrderSingle.SetField(new SettlType(orderNewSend.SettlType_63));
            newOrderSingle.SetField(new CharField(29501, orderNewSend.TradeFrag_29501));


            if (newOrderSingle != null)
            {
                SendMessage(newOrderSingle);
            }
        }

        internal string GetNameByTagEnumValue(string name, object Value)
        {
            string returnValue = "";
            Type typeParameterType = typeof(Account).Assembly.GetType("QuickFix.Fields." + name);
            var props = typeParameterType.GetFields(BindingFlags.Public | BindingFlags.Static);
            try
            {
                object o = Convert.ChangeType(Value, props.First().FieldType);
                MemberInfo memberInfo = props.FirstOrDefault(prop => prop.GetValue(null).Equals(o));
                if (memberInfo != null)
                {
                    returnValue = memberInfo.Name;
                }
            }
            catch (Exception)
            {
            }


            return returnValue;
        }

        internal void QueryCancelOrder(OrderCancelSend orderCancelSend)
        {

            OrderCancelRequest m = QueryOrderCancelRequestFIX50SP2(orderCancelSend);

            if (m != null)
                SendMessage(m);
        }

        internal void QueryOrderStatusRequest(OrderStatusRequestSend orderStatusRequestSend)
        {
            UpdateDisplayInfo("QueryOrderStatusRequest");

            OrderStatusRequest message = new OrderStatusRequest(new Side(orderStatusRequestSend.Side_54))
            {
                ClOrdID = new ClOrdID(orderStatusRequestSend.ClOrdID_11)
            };
            OrderStatusRequest.NoPartyIDsGroup partyIdsGrp = new OrderStatusRequest.NoPartyIDsGroup
            {
                PartyID = new PartyID(orderStatusRequestSend.PartyID_448),
                PartyIDSource = new PartyIDSource(orderStatusRequestSend.PartyIDSource_447),
                PartyRole = new PartyRole(orderStatusRequestSend.PartyRole_452)
            };

            message.AddGroup(partyIdsGrp);

            if (message != null)
                SendMessage(message);
        }

        internal void QuerySecurityDefinition(SecurityDefinitionSend securityDefinitionSend)
        {
            UpdateDisplayInfo("SecurityDefinition");

            SecurityDefinitionRequest message = new SecurityDefinitionRequest
            {
                SecurityReqID = new SecurityReqID(securityDefinitionSend.SecurityReqID_320),
                SecurityExchange = new SecurityExchange(securityDefinitionSend.SecurityExchange_207),
                SecurityID = new SecurityID(securityDefinitionSend.SecurityID_48),
                Symbol = new Symbol(securityDefinitionSend.Symbol_55),
                SecurityType = new SecurityType(securityDefinitionSend.SecurityType_167),
                SecurityRequestType = new SecurityRequestType(SecurityRequestType.REQUEST_SECURITY_IDENTITY_AND_SPECIFICATIONS)
            };

            if (message != null)
                SendMessage(message);
        }

        private void QueryReplaceOrder(string origClOrdID, string clOrdID, string symbol, char side, char ordType, decimal quantity)
        {
            UpdateDisplayInfo("CancelReplaceRequest");

            OrderCancelReplaceRequest m = QueryCancelReplaceRequestFIX50SP2(origClOrdID, clOrdID, symbol, side, ordType, quantity);

            if (m != null)
                SendMessage(m);
        }

        internal void QueryMarketDataRequest(MarketDataRequestSend marketDataRequestSend)
        {
            UpdateDisplayInfo("MarketDataRequest");

            MessageParser.OrderMarketDataRequestRecive = new List<MarketDataRequestRecive>();


            //QuickFix.FIX50SP2.Message m = QueryMarketDataRequestFIX50SP2(new string[] { "OCTGA28FEB20", "LUCH", "ARS", SecurityType.CASH }, SubscriptionRequestType.SNAPSHOT);
            //Message message = new QuickFix.FIX50SP2.Message();
            MarketDataRequest mdr = new MarketDataRequest();

            mdr.Set(new MDReqID(DateTime.UtcNow.ToString("ddMMyyyyHHmmss"))); //PARA QUE SE UNICO

            mdr.Set(new SubscriptionRequestType(marketDataRequestSend.SubscriptionRequestType_263));
            mdr.Set(new MDUpdateType(MDUpdateType.FULL_REFRESH)); //required if above type is SNAPSHOT_PLUS_UPDATES
                                                                  //1=Top of Book, 0 = full book, other integer equals number of levels
            mdr.Set(new MarketDepth(1));
            mdr.Set(new AggregatedBook(true));

            //mdr.Set(new DeliverToCompID("FGW")); //Para Millennium el valor será “FGW” y para futuros “UMDF” y para futuros “UMDF”

            // Define instrument
            MarketDataRequest.NoRelatedSymGroup sgroup = new MarketDataRequest.NoRelatedSymGroup();
            sgroup.Set(new Symbol(marketDataRequestSend.Symbol_55)); //Instrumento
            sgroup.Set(new SecurityType(marketDataRequestSend.SecurityType_167)); //Instrumento
            //sgroup.Set(new SecurityExchange(marketDataRequestSend.SecurityExchange_207)); //RUEDA
            sgroup.Set(new Currency(marketDataRequestSend.Currency_15)); //MONEDA
            sgroup.Set(new SettlType(marketDataRequestSend.SettlType_63)); //CASH
            //sgroup.Set(new Product(Product.INDEX)); //7 INDEX 12 OTHER (used for Statistics)

            mdr.AddGroup(sgroup);

            MarketDataRequest.NoMDEntryTypesGroup tgroup = new MarketDataRequest.NoMDEntryTypesGroup();//.NoMDEntryTypes();
            tgroup.Set(new MDEntryType(MDEntryType.BID));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.OFFER));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.TRADE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.INDEX_VALUE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.OPENING_PRICE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.CLOSING_PRICE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.SETTLEMENT_PRICE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.TRADING_SESSION_HIGH_PRICE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.TRADING_SESSION_LOW_PRICE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.IMBALANCE));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.TRADE_VOLUME));
            mdr.AddGroup(tgroup);
            tgroup.Set(new MDEntryType(MDEntryType.AUCTION_CLEARING_PRICE));
            mdr.AddGroup(tgroup);

            if (mdr != null)
                SendMessage(mdr);

        }

        internal void QuerySecurityListRequest(string uniqueID)
        {
            UpdateDisplayInfo("QuerySecurityListRequest");

            QuickFix.Message m = QuerySecurityList(uniqueID);

            MessageParser.OrderMarketDataRecives = new List<OrderMarketDataRecive>();
            // DeliverToCompID (128) Para Millennium el valor será “FGW”

            if (m != null)
                SendMessage(m);
        }

        internal void QueryTradeCaptureReportRequest(string tradeRequestID, string partyId, char partyIDSource, int partyRole)
        {
            UpdateDisplayInfo("QuerySecurityListRequest");

            TradeCaptureReportRequest m = new TradeCaptureReportRequest(
                new TradeRequestID(tradeRequestID),
                new TradeRequestType(TradeRequestType.ALL_TRADES)
                );

            
            TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup partyIdsGrp = new TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup
            {
                PartyID = new PartyID(partyId),
                PartyIDSource = new PartyIDSource(partyIDSource),
                PartyRole = new PartyRole(partyRole)
            };

            m.AddGroup(partyIdsGrp);
            /* OrderBook - Tag 30001
             * 1 Regular
             * 2 Off Book
             * 3 Odd Lot
             * 4 Block Trade
             * 6 Early Settlement
             * 7 Auctions
            */
            m.SetField(new IntField(30001, 1));

            if (m != null)
                SendMessage(m);

        }


        private QuickFix.Message QuerySecurityList(string uniqueID)
        {
            SecurityListRequest message = new SecurityListRequest(new SecurityReqID("SLRGAL"), new SecurityListRequestType(SecurityListRequestType.ALL_SECURITIES))
            {
                SubscriptionRequestType = new SubscriptionRequestType(SubscriptionRequestType.SNAPSHOT),
                SecurityListType = new SecurityListType(2)
            };
            return message;
        }

        private OrderCancelRequest QueryOrderCancelRequestFIX50SP2(OrderCancelSend orderCancelSend)
        {
            OrderCancelRequest orderCancelRequest = new OrderCancelRequest(
                new ClOrdID(orderCancelSend.ClOrdID_11),
                new Side(orderCancelSend.Side_54),
                new TransactTime(DateTime.UtcNow))
            {
                OrigClOrdID = new OrigClOrdID(orderCancelSend.OrigClOrdID_41),
                //SecurityID = new SecurityID(orderCancelSend.SecurityID_48),
                Symbol = new Symbol(orderCancelSend.Symbol_55),
                SecurityType = new SecurityType(orderCancelSend.SecurityType_167)
            };
            orderCancelRequest.SetField(new Currency(orderCancelSend.Currency_15));
            orderCancelRequest.SetField(new SettlType(orderCancelSend.SettlmntTyp_63));


            TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup partyIdsGrp = new TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup
            {
                PartyID = new PartyID(orderCancelSend.PartyID_448),
                PartyIDSource = new PartyIDSource(orderCancelSend.PartyIDSource_447),
                PartyRole = new PartyRole(orderCancelSend.PartyRole_452)
            };

            orderCancelRequest.AddGroup(partyIdsGrp);
            return orderCancelRequest;
        }

        private OrderCancelReplaceRequest QueryCancelReplaceRequestFIX50SP2(string origClOrdID, string clOrdID, string symbol, char side, char orderType, decimal quantity)
        {
            OrderCancelReplaceRequest ocrr = new OrderCancelReplaceRequest(
                new ClOrdID(clOrdID),
                //QueryOrigClOrdID(origClOrdID),
                new Side(side),
                new TransactTime(DateTime.UtcNow),
                //QuerySymbol(symbol),
                new OrdType(orderType));

            ocrr.Set(new HandlInst('1'));
            //if (QueryConfirm("New price"))
            ocrr.Set(new Price(quantity));
            //if (QueryConfirm("New quantity"))
            ocrr.Set(new OrderQty(quantity));

            return ocrr;
        }

        private MarketDataRequest QueryMarketDataRequest44()
        {
            //“Campo requerido si el mensaje surge de un pedido mediante un mensaje MarkeDataRequest. Es el único
            //Identificador de la solicitud(copia el valor desde el mensaje MarketDataRequest).”
            MDReqID mdReqID = new MDReqID("SuscripcionBYMA_MD64");

            //1 (**) Snapshot + Updates (Subscribe) 
            //2 (**) Unsubscribe (not supported for DMA)
            SubscriptionRequestType subType = new SubscriptionRequestType(SubscriptionRequestType.SNAPSHOT_PLUS_UPDATES);

            //“Profundidad del Mercado tanto para capturas de libro, como actualizaciones incrementales.
            //Para el caso de los futuros este valor es fijo y debe ser 100”
            MarketDepth marketDepth = new MarketDepth(5);



            MarketDataRequest.NoMDEntryTypesGroup marketDataEntryGroup = new MarketDataRequest.NoMDEntryTypesGroup();
            marketDataEntryGroup.Set(new MDEntryType(MDEntryType.BID));

            //55 OCTGA28FEB20 “Especies”
            MarketDataRequest.NoRelatedSymGroup symbolGroup = new MarketDataRequest.NoRelatedSymGroup();
            symbolGroup.Set(new Symbol("OCTGA28FEB20"));

            MarketDataRequest message = new MarketDataRequest(mdReqID, subType, marketDepth);
            message.AddGroup(marketDataEntryGroup);
            message.AddGroup(symbolGroup);

            // ”Este campo es requerido si el tag (263) SubscriptionRequestType
            //= Snapshot + Updates(1).El servicio FIX de BYMA no soporta el valor 1 en el tag 263, por lo tanto este campo no es requerido.”
            message.MDUpdateType = new MDUpdateType(MDUpdateType.FULL_REFRESH);

            //266   Y Aggregated  N Disaggregated
            message.AggregatedBook = new AggregatedBook(AggregatedBook.YES);

            //207 LUCH "rueda"
            SecurityExchange securityExchange = new SecurityExchange("LUCH");
            message.SetField(securityExchange);

            //15 ARS "Moneda"
            Currency currency = new Currency("ARS");
            message.SetField(currency);


            return message;
        }

        private RequestForPositions QueryRequestForPositionFIX50SP2(string posReqID, int posReqType)
        {
            return new RequestForPositions(new PosReqID(posReqID), new PosReqType(posReqType), new ClearingBusinessDate(DateTime.UtcNow.ToString("yyyyMMdd")), new TransactTime(DateTime.UtcNow));

        }

        private OrderStatusRequest QueryGatewayStatus(char c)
        {
            OrderStatusRequest message = new OrderStatusRequest(new Side(c));

            return message;
        }

        private List<KeyValuePair<string, string>> RetornaListKeyValuePairFormateadoPorValor<T>()
        {
            List<KeyValuePair<string, string>> array = new List<KeyValuePair<string, string>>();

            Type typeParameterType = typeof(T);
            var props = typeParameterType.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var prop in props)
            {
                array.Add(new KeyValuePair<string, string>(prop.GetValue(prop.Name).ToString(), string.Format("{0} ({1})", prop.Name, prop.GetValue(prop.Name))));
            }

            return array;
        }

        internal List<KeyValuePair<string, string>> GetSideArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<Side>();
        }
        internal List<KeyValuePair<string, string>> GetSecurityTypeArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<SecurityType>();
        }
        internal List<KeyValuePair<string, string>> GetSettlmntTypeArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<SettlmntTyp>();
        }
        internal List<KeyValuePair<string, string>> GetOrdTypeArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<OrdType>();
        }
        internal List<KeyValuePair<string, string>> GetTimeInForceArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<TimeInForce>();
        }
        internal List<KeyValuePair<string, string>> GetOrderCapacityArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<OrderCapacity>();
        }
        internal List<KeyValuePair<string, string>> GetPartyIDSourceArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<PartyIDSource>();
        }
        internal List<KeyValuePair<string, string>> GetPartyRoleArrayForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<PartyRole>();
        }

        internal List<KeyValuePair<string, string>> GetSubscriptionRequestTypeForCombo()
        {
            return RetornaListKeyValuePairFormateadoPorValor<SubscriptionRequestType>();
        }


        internal List<KeyValuePair<string, string>> GetTradeFragArrayForCombo()
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("1","NONE (1)"),
                new KeyValuePair<string, string>("2","PASS (2)"),
                new KeyValuePair<string, string>("3","BLOCK (3)"),
            };
        }


        #region field query private methods

        internal void Initiate(string rutaConfig, string usuario, string password, bool resetSession, Form1 form1)
        {
            _usuario = usuario;
            _password = password;
            _resetSession = resetSession;
            _control = form1;

            try
            {
                //log.CreateLog(MethodBase.GetCurrentMethod().DeclaringType.ToString(), null);

                SessionSettings settings = new SessionSettings(rutaConfig);

                //TELNET
                //TelnetConnection telnet = new TelnetConnection(settings.Get().GetString("SOCKETCONNECTHOST"), settings.Get().GetInt("SOCKETCONNECTPORT"));
                //settings.GetString("SOCKETCONNECTHOST")
                //settings.GetString("SOCKETCONNECTPORT")


                //QFApplication application = new QFApplication();
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new ScreenLogFactory(settings);
                initiator = new SocketInitiator(this, storeFactory, settings, logFactory);

                // this is a developer-test kludge.  do not emulate.
                //application.MyInitiator = initiator;

                initiator.Start();
                //initiator.Stop();
            }
            catch (Exception ex)
            {
                UpdateDisplay(ex.ToString(), Color.Black);
            }
        }

        #endregion

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
    }
}

