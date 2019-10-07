namespace INOM.Entities
{
    public class PendingOrder
    {
        public string OrderID { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDateTime { get; set; }
        public string ElapsedTime { get; set; }
        public string BrokerID { get; set; }
        public string ChannelID { get; set; }
        public string OperatorID { get; set; }
        public string OrderType { get; set; }
        public string Scheduled { get; set; }
        public string ProductType { get; set; }
        public string Status { get; set; }
        public string Discriminator { get; set; }
        public string RecycleActive { get; set; }
    }
}
