using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getMarketDataInstrumentRealTimeResponse
    {
        public class MarketData
        {
            public Trade LA { get; set; }
            public Trade SE { get; set; }
            public List<Trade> BI { get; set; }
            public Trade OI { get; set; }
            public List<Trade> OF { get; set; }
            public Trade OP { get; set; }
            public Trade CL { get; set; }
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
