using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class MarketData
    {
        [Key]
        public int MarketDataID { get; set; }
        public long Timestamp { get; set; }
        [MaxLength(5)]
        public string MarketID { get; set; }
        [MaxLength(50)]
        public string Symbol { get; set; }
        public float OfferPrice { get; set; }
        public decimal OfferSize { get; set; }
        public float BidPrice { get; set; }
        public decimal BidSize { get; set; }
        public decimal NominalVolume { get; set; }
        public decimal TradeVolume { get; set; }
        public float IndexValue { get; set; }
        public decimal OpenInterestSize { get; set; }
        public long OpenInterestDate { get; set; }
        public decimal TradeEffectiveVolume { get; set; }
        public DateTime DateTime { get; set; }
    }
}
