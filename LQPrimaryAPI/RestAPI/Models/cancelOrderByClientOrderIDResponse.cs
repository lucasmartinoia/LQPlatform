﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class cancelOrderByClientOrderIDResponse
    {
        public class RootObject
        {
            public string message { get; set; }
            public string description { get; set; }
            public string status { get; set; }
            public OrderId order { get; set; }
        }
    }
}
