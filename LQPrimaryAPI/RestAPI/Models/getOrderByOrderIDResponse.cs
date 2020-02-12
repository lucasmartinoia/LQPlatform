using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getOrderByOrderIDResponse
    {
        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public string description { get; set; }
            public Order order { get; set; }
        }
    }
}
