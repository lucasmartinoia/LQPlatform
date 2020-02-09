using System.Globalization;

namespace LatamQuants.Support
{
    public static class GlobalSettings
    {
        public static NumberFormatInfo NumberFormat { get; set; }
        public static string Connection { get; set; }
        public static int Port { get; set; }
        public static int Port2 { get; set; }
        public static int MonitorTimming { get; set; }
        public static int VerifyPendingTimming { get; set; }
        public static string PolicySystem { get; set; }
        public static string PolicySystemCancelOrder { get; set; }
        public static string SAP_Prenote { get; set; }
        public static string PolicySystemBUS { get; set; }
        public static string CalypsoCatalog { get; set; }
        public static string CalypsoInstrumentBond { get; set; }
        public static string CalypsoInstrumentEquity { get; set; }
        public static string CalypsoClauses { get; set; }
        public static string CalypsoSimpleTransfers { get; set; }
        public static string CalypsoFundsTransfers { get; set; }
        public static string CalypsoFundsOrdersTransfer { get; set; }
        public static string CalypsoBalance { get; set; }
        public static string CalypsoBalanceBUS { get; set; }
        //-------------------------------------------------------------------
        // RABBIT
        //-------------------------------------------------------------------

        // Rabbit service host
        public static string RabbitService { get; set; }

        // Rabbit Queues used for Orders
        public static string RQ_INOM_ORD_SR_REQ { get; set; }
        public static string RQ_INOM_ORD_BO_REQ { get; set; }
        public static string RQ_INOM_ORD_MF_REQ { get; set; }
        public static string RQ_INOM_ORD_MB_REQ { get; set; }
        public static string RQ_INOM_ORD_MM_REQ { get; set; }

        public static string RQ_INOM_ORD_MF_RES { get; set; }
        public static string RQ_INOM_ORD_MB_RES { get; set; }
        public static string RQ_INOM_ORD_MM_RES { get; set; }
        public static string RQ_INOM_ORD_SR_RES { get; set; }
        public static string RQ_INOM_ORD_CO_RES { get; set; }
        

        //public static string RQ_INOM_ORD_BO_SR { get; set; }

        // Rabbit Queues used for Instructions
        public static string RQ_INOM_INS_SR_REQ { get; set; }
        public static string RQ_INOM_INS_MF_REQ { get; set; }
        public static string RQ_INOM_INS_BO_REQ { get; set; }
        public static string RQ_INOM_INS_MB_REQ { get; set; }
        public static string RQ_INOM_INS_MM_REQ { get; set; }

        public static string RQ_INOM_INS_MF_RES { get; set; }
        public static string RQ_INOM_INS_MB_RES { get; set; }
        public static string RQ_INOM_INS_MM_RES { get; set; }
        public static string RQ_INOM_INS_SR_RES { get; set; }
        public static string RQ_INOM_INS_CO_RES { get; set; }

        // Rabbit Queues used for Fee Settlement
        public static string RQ_INOM_FEESETL_BO_REQ { get; set; }

        public static string RQ_INOM_MKTORD_BO_REQ { get; set; }



        //-------------------------------------------------------------------

        public static bool TimerVerifyPendingIsRunning { get; set; }
        public static bool TimerMonitorRabbitIsRunning { get; set; }
        public static bool TimerScheduledOrdersIsRunning { get; set; }

        public static bool TimerReceiveIsRunning { get; set; }
        public static bool TimerFeedsIsRunning { get; set; }

        public static string Server { get; set; }
        public static string Host { get; set; }
        public static string Environment { get; set; }  
        public static int HoursDelay { get; set; }
        public static int MinutesDelay { get; set; }
        public static int SchedulerTimerGetFunds { get; set; }
        public static int SchedulerTimerGetInstruments { get; set; }
        public static int SchedulerTimerContingency { get; set; }
        public static int SchedulerTimerScheduledOrders { get; set; }

        public static int SchedulerTimerInstrumentsByma { get; set; }
        public static int SchedulerTimerInstrumentsMae { get; set; }

        public static int SchedulerTimerGenerateReceipts { get; set; }
        public static string URL_ITEX_GEN_COMPROBANTE { get; set; }
        public static string FeedBTUpdate { get; set; }
        public static string InstrumentsPrices { get; set; }
        public static int SchedulerTimerGenerateFeeds { get; set; }

        public static string LogFile { get; set; }
        public static string LogFileMonitor { get; set; }
        public static bool SaveFile { get; set; }

        public static string CALYPSO_CALENDAR { get; set; }
        public static string CALYPSO_CALENDAR_HOLIDAY { get; set; }

        public static string AMQP_TRADES_ADDRESS { get; set; }
        public static string AMQP_TRADES_CONTAINER_ID { get; set; }
        public static string AMQP_TRADES_TOPIC_SEND { get; set; }
        public static string AMQP_TRADES_TARGET_SEND { get; set; }
        public static string AMQP_TRADES_TOPIC_RECEIVE { get; set; }
        public static string AMQP_TRADES_TARGET_RECEIVE { get; set; }

        public static string AMQP_UPDATES_ADDRESS { get; set; }
        public static string AMQP_UPDATES_CONTAINER_ID { get; set; }
        public static string AMQP_UPDATES_TOPIC_SEND { get; set; }
        public static string AMQP_UPDATES_TARGET_SEND { get; set; }
        public static string AMQP_UPDATES_TOPIC_RECEIVE { get; set; }
        public static string AMQP_UPDATES_TARGET_RECEIVE { get; set; }

        public static string MACHINE_IP { get; set; }

        public static string INOMCORE_BAT { get; set; }
        public static string INOMMARKETFUNDS_BAT { get; set; }
        public static string INOMSMARTROUTING_BAT { get; set; }
        public static string INOMBACKOFFICE_BAT { get; set; }
        public static string INOMRECEIPT_BAT { get; set; }
        public static string INOMFEEMGT_BAT { get; set; }
        public static string INOMFEEDS_BAT { get; set; }

        public static string AVAILABLE_SERVERS { get; set; }
        public static string LOCAL_MONITOR { get; set; }
        public static string REMOTE_MONITOR { get; set; }
        public static string VERIFY_PENDING { get; set; }
        public static string URL_MONITOR_GETSTATUS { get; set; }
        public static string TIME_SHIFT_SCHEDULED_ORDERS { get; set; }
        public static string TIME_SHIFT_GET_FUNDS { get; set; }
        public static string TIME_SHIFT_GET_INSTRUMENTS { get; set; }
        public static string TIME_SHIFT_CONTINGENCY { get; set; }
        public static string TIME_SHIFT_GENERATE_RECEIPTS { get; set; }
        public static string TIME_MAX_DELAY_PROCESS_CALYPSO_RESPONSE { get; set; }
        public static string TIME_SHIFT_GENERATE_FEEDS { get; set; }

        
        public static string TIME_BYMA_GET_INSTRUMENTS { get; set; }
        public static string TIME_MAE_GET_INSTRUMENTS { get; set; }
    }
}
