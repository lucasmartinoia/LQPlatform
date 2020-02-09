using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getInstrumentsResponse
    {
        public class InstrumentId
        {
            public string marketId { get; set; }
            public string symbol { get; set; }
        }

        public class Instrument
        {
            public InstrumentId instrumentId { get; set; }
            public string cficode { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public List<Instrument> instruments { get; set; }
        }
    }
}
