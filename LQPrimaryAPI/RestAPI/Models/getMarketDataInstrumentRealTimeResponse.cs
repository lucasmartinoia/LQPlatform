using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getMarketDataInstrumentRealTimeResponse
    {
        public class LA
        {
            public double price { get; set; }
            public int size { get; set; }
        }

        public class BI
        {
            public double price { get; set; }
            public int size { get; set; }
        }

        public class OF
        {
            public double price { get; set; }
            public int size { get; set; }
        }

        public class MarketData
        {
            public LA LA { get; set; }
            public object SE { get; set; }
            public List<BI> BI { get; set; }
            public object OI { get; set; }
            public List<OF> OF { get; set; }
            public double OP { get; set; }
            public object CL { get; set; }
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
