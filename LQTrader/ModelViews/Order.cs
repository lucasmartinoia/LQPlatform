    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LQTrader.ModelViews
{
    public class Order
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
        public DateTime? ExpireDate { get; set; }
        public bool Iceberg { get; set; }
        public int? DisplayQuantity { get; set; }

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

        // Control properties
        public string ReplaceClientOrderID { get; set; }
        public string CancelClientOrderID { get; set; }

        public bool Send(ModelViews.Order pOrderOriginal = null)
        {
            bool bReturn = false;

            Validate(pOrderOriginal);

            // Send order to market if the response is OK then populate the Client Order ID and Execution ID in the Order instance.


            bReturn = true;
            return bReturn;
        }


        // Validate if Order information is OK to send it to Market.
        private void Validate(ModelViews.Order pOrderOriginal=null)
        {
            // Validation for Replace an existent order in the market
            if(pOrderOriginal!=null)
            {
                if(pOrderOriginal.Status=="PENDING")
                {
                    if (this.Price <= 0)
                        throw new Exception("Price cannot be 0");
                    else if(this.Quantity<=0)
                        throw new Exception("Quantity cannot be 0");
                    if (this.Quantity == pOrderOriginal.Quantity && this.Price == pOrderOriginal.Price)
                        throw new Exception("Price and Quantity not were modified");
                    if(this.Quantity>pOrderOriginal.LeavesQuantity)
                        throw new Exception("Quantity cannot be higher than Pending Quantity");
                }
            }
            // Validation for a NEW order
            else
            {
                if(String.IsNullOrEmpty(this.MarketID)==true)
                    throw new Exception("Please select an Instrument");
                else if(String.IsNullOrEmpty(this.Side)==true)
                    throw new Exception("Please select a Side");
                else if(String.IsNullOrEmpty(this.Type)==true)
                    throw new Exception("Please select a Type");
                else if(this.Type=="LIMIT" && this.Price<=0)
                    throw new Exception("Price cannot be 0 for a LIMIT order");
                else if(this.Quantity<=0)
                    throw new Exception("Quantity cannot be 0");
                else if(String.IsNullOrEmpty(this.TimeInForce)==true)
                    throw new Exception("Please select a TimeInForce option");
                else if(this.TimeInForce=="GTD" && (this.ExpireDate is null || this.ExpireDate<=System.DateTime.Now.Date))
                    throw new Exception("Expire Date cannot be in the past");
                else if(this.Iceberg==true && (this.DisplayQuantity is null || this.DisplayQuantity<=0))
                    throw new Exception("Display Quantity cannot be 0 for an Iceberg order");
                else if(this.Iceberg==true && this.DisplayQuantity>=this.Quantity)
                    throw new Exception("Display Quantity cannot be equal or greater than Quantity");
            }
        }
    }
}
