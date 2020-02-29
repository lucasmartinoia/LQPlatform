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
        public double? price { get; set; }
        public double orderQty { get; set; }
        public string ordType { get; set; }
        public string side { get; set; }
        public string timeInForce { get; set; }
        public string transactTime { get; set; }
        public double? avgPx { get; set; }
        public double? lastPx { get; set; }
        public double? lastQty { get; set; }
        public double? cumQty { get; set; }
        public double? leavesQty { get; set; }
        public string status { get; set; }
        public string text { get; set; }
        public string origClOrdId { get; set; }
        public bool? iceberg { get; set; }
        public double? displayQty { get; set; }
        public string expireDate { get; set; }
    }
}
