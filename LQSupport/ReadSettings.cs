using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;

namespace LQ.Support.Config
{

    //public static class EmbeddedResource
    //{
    //    public static JObject GetApiRequestFile(string namespaceAndFileName)
    //    {
    //        string pp= "";
    //        using (var stream = typeof(EmbeddedResource).GetTypeInfo().Assembly.GetManifestResourceStream(namespaceAndFileName))
    //        using (var reader = new StreamReader(stream, Encoding.UTF8))
    //        {
    //            pp=reader.ReadToEnd();
    //            return JObject.Parse(pp);
    //        }
    //    }
    //}
    public static class ReadSettings
    {
        public const string PORT = "HOST";
        public const string Server = "SERVER";
        public const string Environment = "ENVIRONMENT";
        public const string SETTINGSJSON = "portsettings.json";
        public const string INOMParameters = "INOMPARAMETERS";
        public const string INOMCore = "INOMCORE";
        public const string INOMReceipt = "INOMRECEIPT";
        public const string INOMMarketFund = "INOMMARKETFUNDS";
        public const string INOMMarketByma = "INOMMARKETBYMA";
        public const string INOMMarketMae = "INOMMARKETMAE";
        public const string INOMSmartRouting = "INOMSMARTROUTING";
        public const string INOMBackOffice = "INOMBACKOFFICE";
        public const string INOMMonitor= "INOMMONITOR";
        public const string INOMFeeMgt = "INOMFEEMGT";
        public const string INOMFeeds = "INOMFEEDS";
        public const string MonitorTimming = "MONITORTIMMING";
        public const string VerifyPendingTimming = "VERIFYPENDINGTIMMING";

        public const string Host = "HOST";
        public const string PolicySystem = "POLICYSYSTEMWCF";
        public const string PolicySystemCancelOrder = "POLICYSYSTEMCANCELORDERWCF";
        public const string CalypsoCatalog = "CALYPSOCATALOGINSTRUMENTS";

        /// <summary>
        /// 
        /// </summary>
        public const string CalypsoInstrumentBond = "CALYPSOINSTRUMENTBOND";
        public const string CalypsoInstrumentEquity = "CALYPSOINSTRUMENTEQUITY";


        public const string CalypsoClauses = "CALYPSOCONSULTCLAUSES";
        public const string CalypsoSimpleTransfers = "CALYPSOCONSULTSIMPLETRANSFERS";
        public const string CalypsoFundsTransfers = "CALYPSOCONSULTFUNDSORDERS2";
        public const string CalypsoFundsOrdersTransfer = "CALYPSOCONSULTFUNDSORDERS";
        public const string CalypsoBalance = "CalypsoBALANCETENANCY";
        public const string CalypsoBalanceBUS = "BALANCETENANCYBUSWCF";
        public const string Prenote = "SAP_PRENOTE";
        public const string SchedulerTimerScheduledOrders = "SCHEDULER_TIMER_SCHEDULED_ORDERS";
        public const string SchedulerTimerGetFunds = "SCHEDULER_TIMER_GET_FUNDS";
        public const string SchedulerTimerContingency = "SCHEDULER_TIMER_CONTINGENCY";
        public const string SchedulerTimerGenerateReceipts = "SCHEDULER_TIMER_GENERATE_RECEIPTS";

        public const string SchedulerTimerInstrumentsByma = "SCHEDULER_TIMER_GET_INSTRUMENTS_BYMA";
        public const string SchedulerTimerInstrumentsMae = "SCHEDULER_TIMER_GET_INSTRUMENTS_MAE";

        public const string URL_ITEX_GEN_COMPROBANTE = "URL_ITEX_GEN_COMPROBANTE";
        public const string FeedBTUpdate = "FEED_BT_UPDATE";
        public const string InstrumentsPrices = "INSTRUMENTS_PRICES";
        public const string CalypsoCalendar = "CALYPSO_CALENDAR";
        public const string CalypsoCalendarHoliday = "CALYPSO_CALENDAR_HOLIDAY";
        public const string SchedulerTimerGenerateFeeds = "SCHEDULER_TIMER_GENERATE_FEEDS";


        // Queues for Orders.
        public const string RQ_INOM_ORD_SR_REQ = "RQ_INOM_ORD_SR_REQ";
        public const string RQ_INOM_ORD_BO_REQ = "RQ_INOM_ORD_BO_REQ";
        public const string RQ_INOM_ORD_MF_REQ = "RQ_INOM_ORD_MF_REQ";
        public const string RQ_INOM_ORD_MB_REQ = "RQ_INOM_ORD_MB_REQ";
        public const string RQ_INOM_ORD_MM_REQ = "RQ_INOM_ORD_MM_REQ";


        public const string RQ_INOM_ORD_MF_RES = "RQ_INOM_ORD_MF_RES";
        public const string RQ_INOM_ORD_SR_RES = "RQ_INOM_ORD_SR_RES";
        public const string RQ_INOM_ORD_CO_RES = "RQ_INOM_ORD_CO_RES";
        public const string RQ_INOM_ORD_MB_RES = "RQ_INOM_ORD_MB_RES";
        public const string RQ_INOM_ORD_MM_RES = "RQ_INOM_ORD_MM_RES";


        //public const string RQ_INOM_ORD_BO_SR = "RQ_INOM_ORD_BO_SR";

        // Queues for Instructions.
        public const string RQ_INOM_INS_SR_REQ = "RQ_INOM_INS_SR_REQ";
        public const string RQ_INOM_INS_MF_REQ = "RQ_INOM_INS_MF_REQ";
        public const string RQ_INOM_INS_BO_REQ = "RQ_INOM_INS_BO_REQ";
        public const string RQ_INOM_INS_MB_REQ = "RQ_INOM_INS_MB_REQ";
        public const string RQ_INOM_INS_MM_REQ = "RQ_INOM_INS_MM_REQ";

        public const string RQ_INOM_INS_MF_RES = "RQ_INOM_INS_MF_RES";
        public const string RQ_INOM_INS_SR_RES = "RQ_INOM_INS_SR_RES";
        public const string RQ_INOM_INS_CO_RES = "RQ_INOM_INS_CO_RES";
        public const string RQ_INOM_INS_MB_RES = "RQ_INOM_INS_MB_RES";
        public const string RQ_INOM_INS_MM_RES = "RQ_INOM_INS_MM_RES";

        // Queues for Fee Settlement.
        public const string RQ_INOM_FEESETL_BO_REQ = "RQ_INOM_FEESETL_BO_REQ";

        public const string RQ_INOM_MKTORD_BO_REQ = "RQ_INOM_MKTORD_BO_REQ";


        public const string RabbitService = "RABBITSERVICE";

        public const string HoursDelay = "HOURSDELAY";
        public const string MinutesDelay = "MINUTESDELAY";

        public const string LogFile = "LOGFILE";
        public const string LogFileMonitor = "LOGFILEMONITOR";
        public const string SaveFile = "SAVEFILE";

        public const string AMQP_TRADES_ADDRESS = "AMQP_TRADES_ADDRESS";
        public const string AMQP_TRADES_CONTAINER_ID = "AMQP_TRADES_CONTAINER_ID";
        public const string AMQP_TRADES_TOPIC_SEND = "AMQP_TRADES_TOPIC_SEND";
        public const string AMQP_TRADES_TARGET_SEND = "AMQP_TRADES_TARGET_SEND";
        public const string AMQP_TRADES_TOPIC_RECEIVE = "AMQP_TRADES_TOPIC_RECEIVE";
        public const string AMQP_TRADES_TARGET_RECEIVE = "AMQP_TRADES_TARGET_RECEIVE";

        public const string AMQP_UPDATES_ADDRESS = "AMQP_UPDATES_ADDRESS";
        public const string AMQP_UPDATES_CONTAINER_ID = "AMQP_UPDATES_CONTAINER_ID";
        public const string AMQP_UPDATES_TOPIC_SEND = "AMQP_UPDATES_TOPIC_SEND";
        public const string AMQP_UPDATES_TARGET_SEND = "AMQP_UPDATES_TARGET_SEND";
        public const string AMQP_UPDATES_TOPIC_RECEIVE = "AMQP_UPDATES_TOPIC_RECEIVE";
        public const string AMQP_UPDATES_TARGET_RECEIVE = "AMQP_UPDATES_TARGET_RECEIVE";

        public const string MACHINE_IP = "MACHINE_IP";

        public const string INOMCORE_BAT = "INOMCORE_BAT";
        public const string INOMMARKETFUNDS_BAT = "INOMMARKETFUNDS_BAT";
        public const string INOMSMARTROUTING_BAT = "INOMSMARTROUTING_BAT";
        public const string INOMBACKOFFICE_BAT = "INOMBACKOFFICE_BAT";
        public const string INOMRECEIPT_BAT = "INOMRECEIPT_BAT";
        public const string INOMFEEMGT_BAT = "INOMFEEMGT_BAT";
        public const string INOMFEEDS_BAT = "INOMFEEDS_BAT";

        public const string AVAILABLE_SERVERS = "AVAILABLE_SERVERS";
        public const string LOCAL_MONITOR = "LOCAL_MONITOR";
        public const string REMOTE_MONITOR = "REMOTE_MONITOR";
        public const string VERIFY_PENDING = "VERIFY_PENDING";
        public const string URL_MONITOR_GETSTATUS = "URL_MONITOR_GETSTATUS";
        public const string TIME_SHIFT_SCHEDULED_ORDERS = "TIME_SHIFT_SCHEDULED_ORDERS";
        public const string TIME_SHIFT_GET_FUNDS = "TIME_SHIFT_GET_FUNDS";
        public const string TIME_SHIFT_GET_INSTRUMENTS = "TIME_SHIFT_GET_INSTRUMENTS";
        public const string TIME_SHIFT_CONTINGENCY = "TIME_SHIFT_CONTINGENCY";
        public const string TIME_SHIFT_GENERATE_RECEIPTS = "TIME_SHIFT_GENERATE_RECEIPTS";
        public const string TIME_MAX_DELAY_PROCESS_CALYPSO_RESPONSE = "TIME_MAX_DELAY_PROCESS_CALYPSO_RESPONSE";
        public const string TIME_SHIFT_GENERATE_FEEDS = "TIME_SHIFT_GENERATE_FEEDS";

        public const string TIME_BYMA_GET_INSTRUMENTS = "TIME_BYMA_GET_INSTRUMENTS";
        public const string TIME_MAE_GET_INSTRUMENTS = "TIME_MAE_GET_INSTRUMENTS";
        

        public static IConfiguration Configuration { get; set; }
        public static string ReadConfig(string service)
        {
            //JObject jObject= ReadEmbeddedJson();
            //string port = (string)jObject[PORT];
            //string myConfig = (string)jObject[service];

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(SETTINGSJSON);
            Configuration = builder.Build();
            string port = Configuration[PORT];
            string myConfig = Configuration[service];
            return port + myConfig;
        }
        public static int ReadPort(string service)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(SETTINGSJSON);
            Configuration = builder.Build();
            string port = Configuration[service].Split('/')[0] ;
            return Convert.ToInt16(port);
        }
        public static int ReadTimming(string value)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(SETTINGSJSON);
            Configuration = builder.Build();
            string timer = Configuration[value];
            return Convert.ToInt16(timer);
        }
        public static string ReadQueue(string service)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile(SETTINGSJSON);
            Configuration = builder.Build();
            return Configuration[service];
        }
        public static string ReadLogFile(string service)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile(SETTINGSJSON);
            Configuration = builder.Build();
            string file = Configuration[service];
            return Directory.GetCurrentDirectory()  + file;
        }
        public static string ReadDBConnection()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(SETTINGSJSON);
            Configuration = builder.Build();
            return string.Format( Configuration.GetConnectionString("ConnectionString"));
        }

        public static int PortService(string service)
        {
            return ReadPort(service);
        }

        public static void SaveSettings(string service)
        {
            GlobalSettings.Environment = ReadQueue(Environment);
            GlobalSettings.Connection = ReadDBConnection();
            // Set FormatNumber
            GlobalSettings.NumberFormat = new System.Globalization.NumberFormatInfo();
            GlobalSettings.NumberFormat.NumberDecimalSeparator = ".";
            if( service != "" )
                GlobalSettings.Port = PortService(service);
            GlobalSettings.Port2 = GlobalSettings.Port + 1;
            GlobalSettings.MonitorTimming = ReadTimming(MonitorTimming);
            GlobalSettings.VerifyPendingTimming = ReadTimming(VerifyPendingTimming);

            GlobalSettings.HoursDelay = ReadTimming(HoursDelay);
            GlobalSettings.MinutesDelay = ReadTimming(MinutesDelay);
            GlobalSettings.SchedulerTimerScheduledOrders = ReadTimming(SchedulerTimerScheduledOrders);
            GlobalSettings.SchedulerTimerGetFunds = ReadTimming(SchedulerTimerGetFunds);
            GlobalSettings.SchedulerTimerContingency = ReadTimming(SchedulerTimerContingency);
            GlobalSettings.SchedulerTimerGenerateReceipts = ReadTimming(SchedulerTimerGenerateReceipts);
            GlobalSettings.URL_ITEX_GEN_COMPROBANTE = ReadQueue(URL_ITEX_GEN_COMPROBANTE);
            GlobalSettings.FeedBTUpdate = ReadQueue(FeedBTUpdate);
            GlobalSettings.InstrumentsPrices = ReadQueue(InstrumentsPrices);
            GlobalSettings.SchedulerTimerGenerateFeeds = ReadTimming(SchedulerTimerGenerateFeeds);

            GlobalSettings.SchedulerTimerInstrumentsByma = ReadTimming(SchedulerTimerInstrumentsByma);
            GlobalSettings.SchedulerTimerInstrumentsMae = ReadTimming(SchedulerTimerInstrumentsMae);
            

            // Queues used for Orders.
            GlobalSettings.RQ_INOM_ORD_SR_REQ = ReadQueue(RQ_INOM_ORD_SR_REQ);
            GlobalSettings.RQ_INOM_ORD_MF_REQ = ReadQueue(RQ_INOM_ORD_MF_REQ);
            GlobalSettings.RQ_INOM_ORD_BO_REQ = ReadQueue(RQ_INOM_ORD_BO_REQ);
            GlobalSettings.RQ_INOM_ORD_MB_REQ = ReadQueue(RQ_INOM_ORD_MB_REQ);
            GlobalSettings.RQ_INOM_ORD_MM_REQ = ReadQueue(RQ_INOM_ORD_MM_REQ);

            GlobalSettings.RQ_INOM_ORD_MF_RES = ReadQueue(RQ_INOM_ORD_MF_RES);
            GlobalSettings.RQ_INOM_ORD_SR_RES = ReadQueue(RQ_INOM_ORD_SR_RES);
            GlobalSettings.RQ_INOM_ORD_CO_RES = ReadQueue(RQ_INOM_ORD_CO_RES);
            GlobalSettings.RQ_INOM_ORD_MB_RES = ReadQueue(RQ_INOM_ORD_MB_RES);
            GlobalSettings.RQ_INOM_ORD_MM_RES = ReadQueue(RQ_INOM_ORD_MM_RES);

            // Queues used for Instructions.
            GlobalSettings.RQ_INOM_INS_SR_REQ = ReadQueue(RQ_INOM_INS_SR_REQ);
            GlobalSettings.RQ_INOM_INS_MF_REQ = ReadQueue(RQ_INOM_INS_MF_REQ);
            GlobalSettings.RQ_INOM_INS_BO_REQ = ReadQueue(RQ_INOM_INS_BO_REQ);
            GlobalSettings.RQ_INOM_INS_MB_REQ = ReadQueue(RQ_INOM_INS_MB_REQ);
            GlobalSettings.RQ_INOM_INS_MM_REQ = ReadQueue(RQ_INOM_INS_MM_REQ);


            GlobalSettings.RQ_INOM_INS_MF_RES = ReadQueue(RQ_INOM_INS_MF_RES);
            GlobalSettings.RQ_INOM_INS_SR_RES = ReadQueue(RQ_INOM_INS_SR_RES);
            GlobalSettings.RQ_INOM_INS_CO_RES = ReadQueue(RQ_INOM_INS_CO_RES);
            GlobalSettings.RQ_INOM_INS_MB_RES = ReadQueue(RQ_INOM_INS_MB_RES);
            GlobalSettings.RQ_INOM_INS_MM_RES = ReadQueue(RQ_INOM_INS_MM_RES);

            // Queues used for Instructions.
            GlobalSettings.RQ_INOM_FEESETL_BO_REQ = ReadQueue(RQ_INOM_FEESETL_BO_REQ);

            GlobalSettings.RQ_INOM_MKTORD_BO_REQ = ReadQueue(RQ_INOM_MKTORD_BO_REQ);


            GlobalSettings.RabbitService = ReadQueue(RabbitService);
            GlobalSettings.Server = ReadQueue(Server);
            GlobalSettings.Host = ReadQueue(Host);
            GlobalSettings.PolicySystem = ReadQueue(PolicySystem);
            GlobalSettings.PolicySystemCancelOrder = ReadQueue(PolicySystemCancelOrder);
            GlobalSettings.CalypsoCatalog = ReadQueue(CalypsoCatalog);

            GlobalSettings.CalypsoInstrumentBond = ReadQueue(CalypsoInstrumentBond);
            GlobalSettings.CalypsoInstrumentEquity = ReadQueue(CalypsoInstrumentEquity);

            GlobalSettings.CalypsoClauses = ReadQueue(CalypsoClauses);
            GlobalSettings.CalypsoSimpleTransfers = ReadQueue(CalypsoSimpleTransfers);
            GlobalSettings.CalypsoFundsTransfers = ReadQueue(CalypsoFundsTransfers);
            GlobalSettings.CalypsoFundsOrdersTransfer = ReadQueue(CalypsoFundsOrdersTransfer);
            GlobalSettings.CalypsoBalanceBUS = ReadQueue(CalypsoBalanceBUS);
            GlobalSettings.SAP_Prenote = ReadQueue(Prenote);
            GlobalSettings.CalypsoBalance = ReadQueue(CalypsoBalance);
            GlobalSettings.LogFile = ReadLogFile(LogFile);
            GlobalSettings.LogFileMonitor = ReadLogFile(LogFileMonitor);
            GlobalSettings.SaveFile = Convert.ToBoolean(Convert.ToInt16(ReadQueue(SaveFile)));
            GlobalSettings.CALYPSO_CALENDAR = ReadQueue(CalypsoCalendar);
            GlobalSettings.CALYPSO_CALENDAR_HOLIDAY = ReadQueue(CalypsoCalendarHoliday);

            GlobalSettings.AMQP_TRADES_ADDRESS = ReadQueue(AMQP_TRADES_ADDRESS);
            GlobalSettings.AMQP_TRADES_CONTAINER_ID = ReadQueue(AMQP_TRADES_CONTAINER_ID);
            GlobalSettings.AMQP_TRADES_TOPIC_SEND = ReadQueue(AMQP_TRADES_TOPIC_SEND);
            GlobalSettings.AMQP_TRADES_TARGET_SEND = ReadQueue(AMQP_TRADES_TARGET_SEND);
            GlobalSettings.AMQP_TRADES_TOPIC_RECEIVE = ReadQueue(AMQP_TRADES_TOPIC_RECEIVE);
            GlobalSettings.AMQP_TRADES_TARGET_RECEIVE = ReadQueue(AMQP_TRADES_TARGET_RECEIVE);

            GlobalSettings.AMQP_UPDATES_ADDRESS = ReadQueue(AMQP_UPDATES_ADDRESS);
            GlobalSettings.AMQP_UPDATES_CONTAINER_ID = ReadQueue(AMQP_UPDATES_CONTAINER_ID);
            GlobalSettings.AMQP_UPDATES_TOPIC_SEND = ReadQueue(AMQP_UPDATES_TOPIC_SEND);
            GlobalSettings.AMQP_UPDATES_TARGET_SEND = ReadQueue(AMQP_UPDATES_TARGET_SEND);
            GlobalSettings.AMQP_UPDATES_TOPIC_RECEIVE = ReadQueue(AMQP_UPDATES_TOPIC_RECEIVE);
            GlobalSettings.AMQP_UPDATES_TARGET_RECEIVE = ReadQueue(AMQP_UPDATES_TARGET_RECEIVE);

            GlobalSettings.MACHINE_IP = GetIPAddress();

            GlobalSettings.INOMCORE_BAT= ReadQueue(INOMCORE_BAT);
            GlobalSettings.INOMMARKETFUNDS_BAT = ReadQueue(INOMMARKETFUNDS_BAT);
            GlobalSettings.INOMSMARTROUTING_BAT = ReadQueue(INOMSMARTROUTING_BAT);
            GlobalSettings.INOMBACKOFFICE_BAT = ReadQueue(INOMBACKOFFICE_BAT);
            GlobalSettings.INOMRECEIPT_BAT = ReadQueue(INOMRECEIPT_BAT);
            GlobalSettings.INOMFEEMGT_BAT = ReadQueue(INOMFEEMGT_BAT);
            GlobalSettings.AVAILABLE_SERVERS = ReadQueue(AVAILABLE_SERVERS);
            GlobalSettings.LOCAL_MONITOR = ReadQueue(LOCAL_MONITOR);
            GlobalSettings.REMOTE_MONITOR = ReadQueue(REMOTE_MONITOR);
            GlobalSettings.VERIFY_PENDING = ReadQueue(VERIFY_PENDING);
            GlobalSettings.URL_MONITOR_GETSTATUS = ReadQueue(URL_MONITOR_GETSTATUS);
            GlobalSettings.TIME_SHIFT_SCHEDULED_ORDERS = ReadQueue(TIME_SHIFT_SCHEDULED_ORDERS);
            GlobalSettings.TIME_SHIFT_GET_FUNDS = ReadQueue(TIME_SHIFT_GET_FUNDS);
            GlobalSettings.TIME_SHIFT_CONTINGENCY = ReadQueue(TIME_SHIFT_CONTINGENCY);
            GlobalSettings.TIME_SHIFT_GET_INSTRUMENTS = ReadQueue(TIME_SHIFT_GET_INSTRUMENTS);
            GlobalSettings.TIME_SHIFT_GENERATE_RECEIPTS = ReadQueue(TIME_SHIFT_GENERATE_RECEIPTS);
            GlobalSettings.TIME_MAX_DELAY_PROCESS_CALYPSO_RESPONSE = ReadQueue(TIME_MAX_DELAY_PROCESS_CALYPSO_RESPONSE);
            GlobalSettings.INOMFEEDS_BAT = ReadQueue(INOMFEEDS_BAT);
            GlobalSettings.TIME_SHIFT_GENERATE_FEEDS = ReadQueue(TIME_SHIFT_GENERATE_FEEDS);

            GlobalSettings.TIME_BYMA_GET_INSTRUMENTS = ReadQueue(TIME_BYMA_GET_INSTRUMENTS);
            GlobalSettings.TIME_MAE_GET_INSTRUMENTS = ReadQueue(TIME_MAE_GET_INSTRUMENTS);
        }

        public static string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            string IPAddress = "";
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
              //      break;
                }
            }
            return IPAddress;
        }

    }
}
