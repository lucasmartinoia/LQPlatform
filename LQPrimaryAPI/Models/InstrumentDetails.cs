using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public class InstrumentDetails
    {
            public Segment segment { get; set; }
            public double lowLimitPrice { get; set; }
            public double highLimitPrice { get; set; }
            public double minPriceIncrement { get; set; }
            public double minTradeVol { get; set; }
            public double maxTradeVol { get; set; }
            public double tickSize { get; set; }
            public string maturityDate { get; set; }
            public double contractMultiplier { get; set; }
            public InstrumentId instrumentId { get; set; }
            public string cficode { get; set; }
            public string currency { get; set; }
            public string orderTypes { get; set; }
            public string timesInForce { get; set; }
            public string securityType { get; set; }
            public string settlType { get; set; }
            public int instrumentPricePrecision { get; set; }
            public int instrumentSizePrecision { get; set; }
            public double roundLot { get; set; }
            public double priceConvertionFactor { get; set; }
    }
}
