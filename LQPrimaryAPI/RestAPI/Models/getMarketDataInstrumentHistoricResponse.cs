using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getMarketDataInstrumentHistoricResponse
    {
        public class Trade
        {
            public double price { get; set; }
            public int size { get; set; }
            public string datetime { get; set; }
            public object servertime { get; set; }
            public string symbol { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
            public List<Trade> trades { get; set; }
        }
    }
}
