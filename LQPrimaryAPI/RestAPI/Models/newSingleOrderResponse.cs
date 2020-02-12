using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class newSingleOrderResponse
    {
        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public string description { get; set; }
            public OrderId order { get; set; }
        }
    }
}
