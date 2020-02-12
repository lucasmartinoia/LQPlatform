using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class cancelOrderByClientOrderIDResponse
    {
        public class RootObject
        {
            public string status { get; set; }
            public OrderId order { get; set; }
        }
    }
}
