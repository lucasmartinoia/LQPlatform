using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getMarketDataInstrumentHistoricResponse
    {
        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public string description { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
            public List<Trade> trades { get; set; }
        }
    }
}
