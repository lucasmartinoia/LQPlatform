using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class replaceOrderByClientOrderIDResponse
    {
        public class Order
        {
            public string clientId { get; set; }
            public string proprietary { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public Order order { get; set; }
        }
    }
}
