using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LQTrader.ModelViews
{
    public class OrderInput
    {
        // Input order properties
        public string MarketID { get; set; }
        public string Symbol { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Side { get; set; }
        public string TimeInForce { get; set; }
        public bool? CancelPrevious { get; set; }
        public bool? Iceberg { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? DisplayQuantity { get; set; }
    }
}
