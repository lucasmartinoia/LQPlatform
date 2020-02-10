using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getAccountPositionsResponse
    {
        public class Instrument
        {
            public string symbolReference { get; set; }
        }

        public class Position
        {
            public double originalBuyPrice { get; set; }
            public double originalSellPrice { get; set; }
            public string symbol { get; set; }
            public Instrument instrument { get; set; }
            public double buyPrice { get; set; }
            public double buySize { get; set; }
            public double sellPrice { get; set; }
            public int sellSize { get; set; }
            public double totalDailyDiff { get; set; }
            public double totalDiff { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public string description { get; set; }
            public List<Position> positions { get; set; }
        }
    }
}
