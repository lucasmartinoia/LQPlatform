using LatamQuants.PrimaryAPI;
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
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string Type { get; set; }
        public string Side { get; set; }
        public string TimeInForce { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Iceberg { get; set; }
        public double? DisplayQuantity { get; set; }

        // Response only properties
        public string TransactionTime { get; set; }
        public double AveragePrice { get; set; }
        public double LastPrice { get; set; }
        public double LastQuantity { get; set; }
        public double CumulativeQuantity { get; set; }
        public double LeavesQuantity { get; set; }
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
            
            // New order
            if(pOrderOriginal is null)
            {
                LatamQuants.PrimaryAPI.Models.newSingleOrderRequest oReqNewOrder = new LatamQuants.PrimaryAPI.Models.newSingleOrderRequest();
                Service.mapper.Map<ModelViews.Order, LatamQuants.PrimaryAPI.Models.newSingleOrderRequest>(this, oReqNewOrder);
                LatamQuants.PrimaryAPI.Models.OrderId oResponse=RestAPI.newSingleOrder(oReqNewOrder).order;

                this.Proprietary = oResponse.proprietary;
                this.ClientOrderID = oResponse.clientId;
            }
            // Replacement
            else
            {

            }

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

        public static List<Order> UpdateOrders(List<Order> pOrderList)
        {
            List<Order> colReturn = new List<Order>();

            if (pOrderList != null && pOrderList.Count > 0)
                colReturn = pOrderList;

            // Update all orders asking for all request done for current account.

            List<LatamQuants.PrimaryAPI.Models.Order> colOrders= RestAPI.GetOrdersByAccount().orders;

            foreach (LatamQuants.PrimaryAPI.Models.Order oOrder in colOrders)
            {
                Order vOrder = new Order();
                Order blotterOrder = null;
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.Order, ModelViews.Order>(oOrder, vOrder);

                // Check if order already exists
                if(colReturn != null)
                    blotterOrder = colReturn.Where(x => x.OrderID == (vOrder.OrderID ?? "") || x.ClientOrderID == vOrder.ClientOrderID).FirstOrDefault();

                // Update order
                if (blotterOrder != null)
                {
                    if(colReturn.Remove(blotterOrder))
                    {
                        blotterOrder.Update(vOrder);
                        colReturn.Add(vOrder);
                    }
                }
                // Add order
                else
                {
                    colReturn.Add(vOrder);
                }
            }

            return colReturn;
        }

        public void Update(Order pOrder)
        {
            this.AveragePrice = pOrder.AveragePrice;
            this.CumulativeQuantity = pOrder.CumulativeQuantity;
            this.DisplayQuantity = pOrder.DisplayQuantity;
            this.ExecutionID = pOrder.ExecutionID;
            this.LastPrice = pOrder.LastPrice;
            this.LastQuantity = pOrder.LastQuantity;
            this.LeavesQuantity = pOrder.LeavesQuantity;
            this.OrderID = pOrder.OrderID;
            this.Proprietary = pOrder.Proprietary;
            this.Status = Order.GetBlotterStatus(pOrder);
            this.Text = pOrder.Text;
            this.TransactionTime = pOrder.TransactionTime;
        }

        public static string GetBlotterStatus(Order pOrder)
        {
            string sReturn = "";

            // PENDING_NEW
            if (pOrder.Status == "PENDING_NEW")
                sReturn = "PENDING_NEW";
            // PENDING
            else if (pOrder.Status == "NEW" || (pOrder.CumulativeQuantity > 0 && pOrder.LeavesQuantity > 0 && pOrder.Status != "CANCELLED"))
                sReturn = "PENDING";
            // FILLED
            else if (pOrder.Status == "FILLED" && (pOrder.LeavesQuantity == 0))
                sReturn = "FILLED";
            // PARTIALLY FILLED
            else if (pOrder.CumulativeQuantity > 0 && pOrder.LeavesQuantity > 0)
                sReturn = "PARTIALLY FILLED";
            // CANCELLED
            else if (pOrder.Status == "CANCELLED")
                sReturn = "CANCELLED";
            else
                sReturn = "PENDING";

            return sReturn;
        }
    }
}
