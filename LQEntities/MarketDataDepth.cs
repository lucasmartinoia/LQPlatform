using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class MarketDataDepth
    {
        [Key]
        public int MarketDataDepthID { get; set; }
        public long Timestamp { get; set; }
        [MaxLength(5)]
        public string MarketID { get; set; }
        [MaxLength(50)]
        public string Symbol { get; set; }
        public bool  Bid { get; set; }
        public float Price { get; set; }
        public decimal Volume { get; set; }
    }
}
