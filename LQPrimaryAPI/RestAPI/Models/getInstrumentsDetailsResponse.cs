using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getInstrumentsDetailsResponse
    {
        public class Segment
        {
            public string marketSegmentId { get; set; }
            public string marketId { get; set; }
        }

        public class InstrumentId
        {
            public string marketId { get; set; }
            public string symbol { get; set; }
        }

        public class Instrument
        {
            public Segment segment { get; set; }
            public double lowLimitPrice { get; set; }
            public double highLimitPrice { get; set; }
            public double minPriceIncrement { get; set; }
            public double minTradeVol { get; set; }
            public double maxTradeVol { get; set; }
            public double tickSize { get; set; }
            public int maturityDate { get; set; }
            public double contractMultiplier { get; set; }
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
