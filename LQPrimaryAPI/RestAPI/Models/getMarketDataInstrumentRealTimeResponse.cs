using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getMarketDataInstrumentRealTimeResponse
    {
        public class MarketData
        {
            public MarketDataRT LA { get; set; }
            public MarketDataRT SE { get; set; }
            public List<MarketDataRT> BI { get; set; }
            public MarketDataRT OI { get; set; }
            public List<MarketDataRT> OF { get; set; }
            public double? OP { get; set; }
            public double? CL { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public string description { get; set; }
            public MarketData marketData { get; set; }
            public int depth { get; set; }
            public bool aggregated { get; set; }
        }
    }
}
