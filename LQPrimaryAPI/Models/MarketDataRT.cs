using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public class MarketDataRT
    {
        public double? price { get; set; }
        public double? size { get; set; }
        public string date { get; set; }
    }
}
