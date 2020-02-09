using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getInstrumentsByCFICodeResponse
    {
        public class Instrument
        {
            public string marketId { get; set; }
            public string symbol { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public List<Instrument> instruments { get; set; }
        }
    }
}
