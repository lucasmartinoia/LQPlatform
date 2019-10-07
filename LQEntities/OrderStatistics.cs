using System;

namespace INOM.Entities
{
    public class OrderStatistics
    {
        public string BrokerID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string ChannelID { get; set; }
        public string ClientID { get; set; }
        public string Status { get; set; }
        public string FundID { get; set; }
        public string OrderType { get; set; }
        public string Scheduled { get; set; }
    }
}
