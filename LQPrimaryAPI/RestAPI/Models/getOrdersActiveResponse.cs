using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getOrdersActiveResponse
    {
        public class AccountId
        {
            public string id { get; set; }
        }

        public class InstrumentId
        {
            public string marketId { get; set; }
            public string symbol { get; set; }
        }

        public class Order
        {
            public string orderId { get; set; }
            public string clOrdId { get; set; }
            public string proprietary { get; set; }
            public string execId { get; set; }
            public AccountId accountId { get; set; }
            public InstrumentId instrumentId { get; set; }
            public double price { get; set; }
            public int orderQty { get; set; }
            public string ordType { get; set; }
            public string side { get; set; }
            public string timeInForce { get; set; }
            public string transactTime { get; set; }
            public int avgPx { get; set; }
            public int lastPx { get; set; }
            public int lastQty { get; set; }
            public int cumQty { get; set; }
            public int leavesQty { get; set; }
            public string status { get; set; }
            public string text { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public List<Order> orders { get; set; }
        }
    }
}
