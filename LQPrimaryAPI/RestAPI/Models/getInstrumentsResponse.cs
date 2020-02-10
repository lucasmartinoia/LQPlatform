using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getInstrumentsResponse
    {
        public class Instrument
        {
            public InstrumentId instrumentId { get; set; }
            public string cficode { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public string description { get; set; }
            public List<Instrument> instruments { get; set; }
        }
    }
}
