using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public class MarketDataRT
    {
        public double price { get; set; }
        public int size { get; set; }
        public string date { get; set; }
    }
}
