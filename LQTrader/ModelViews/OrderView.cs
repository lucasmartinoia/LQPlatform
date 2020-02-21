using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LQTrader.ModelViews
{
    public class OrderView
    {
        // Order and execution reference properties
        public string AccountID { get; set; }
        public string OrderID { get; set; }
        public string ClientOrderID { get; set; }
        public string ExecutionID { get; set; }

        // Input order properties
        public string MarketID { get; set; }
        public string Symbol { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Side { get; set; }
        public string TimeInForce { get; set; }

        // Response only properties
        public string TransactionTime { get; set; }
        public double AveragePrice { get; set; }
        public double LastPrice { get; set; }
        public int LastQuantity { get; set; }
        public int CumulativeQuantity { get; set; }
        public int LeavesQuantity { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
        public string Proprietary { get; set; }
    }
}
