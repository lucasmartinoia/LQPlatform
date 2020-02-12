using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public class Order
    {
        public string orderId { get; set; }
        public string clOrdId { get; set; }
        public string proprietary { get; set; }
        public string execId { get; set; }
        public AccountId accountId { get; set; }
        public InstrumentId instrumentId { get; set; }
        public int price { get; set; }
        public int orderQty { get; set; }
        public string ordType { get; set; }
        public string side { get; set; }
        public string timeInForce { get; set; }
        public string transactTime { get; set; }
        public double avgPx { get; set; }
        public double lastPx { get; set; }
        public int lastQty { get; set; }
        public int cumQty { get; set; }
        public int leavesQty { get; set; }
        public string status { get; set; }
        public string text { get; set; }
    }
}
