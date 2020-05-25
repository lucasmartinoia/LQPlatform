using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LatamQuants.Entities
{
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }
        public string Symbol { get; set; }
        public string MarketID { get; set; }
        public string SegmentID { get; set; }
        public double LowLimitPrice { get; set; }
        public double HighLimitPrice { get; set; }
        public double MinPriceIncrement { get; set; }
        public double MinTradeVol { get; set; }
        public double MaxTradeVol { get; set; }
        public double TickSize { get; set; }
        public double ContractMultiplier { get; set; }
        public double RoundLot { get; set; }
        public double PriceConvertionFactor { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string Currency { get; set; }
        public string OrderTypes { get; set; }
        public string TimesInForce { get; set; }
        public string SecurityType { get; set; }
        public string SettlementType { get; set; }
        public int InstrumentPricePrecision { get; set; }
        public int InstrumentSizePrecision { get; set; }
        public string CFICode { get; set; }
    }
}
