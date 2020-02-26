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

        public enum eUpdateOrdersMode
        {
            ByAccount=0,
            ActiveOrders=1,
            FilledOrders=2,
        }
        public bool Cancel()
        {
            bool bReturn = false;

            LatamQuants.PrimaryAPI.Models.OrderId oResponse= RestAPI.CancelOrderByClientOrderID(this.ClientOrderID, this.Proprietary).order;
            this.CancelClientOrderID = oResponse.clientId;

            bReturn = true;
            return bReturn;
        }
        
        
        public Order Replace(double pPrice, double pQuantity)
        {
            Order oReturn = null;

            // Validate parameters
            if (pPrice <= 0)
                throw new Exception("Price cannot be 0");
            else if (pQuantity <= 0)
                throw new Exception("Quantity cannot be 0");

            // Send request
            LatamQuants.PrimaryAPI.Models.OrderId oResponse = RestAPI.ReplaceOrderByClientOrderID(this.ClientOrderID, this.Proprietary, pQuantity, pPrice).order;

            // Update current order
            this.ReplaceClientOrderID= oResponse.clientId;

            // Returns new order
            oReturn = this.New();
            oReturn.Quantity = pQuantity;
            oReturn.Price = pPrice;
            oReturn.ClientOrderID = oResponse.clientId;
            oReturn.Status = "SENT";

            return oReturn;
        }
        
        /// <summary>
        /// Return a new order instance with same input values from original.
        /// </summary>
        /// <returns>New order</returns>
        public Order New()
        {
            Order oReturn = new Order();

            oReturn.AccountID = this.AccountID;
            oReturn.DisplayQuantity = this.DisplayQuantity;
            oReturn.ExpireDate = this.ExpireDate;
            oReturn.Iceberg = this.Iceberg;
            oReturn.MarketID = this.MarketID;
            oReturn.Price = this.Price;
            oReturn.Proprietary = this.Proprietary;
            oReturn.Quantity = this.Quantity;
            oReturn.Side = this.Side;
            oReturn.Symbol = this.Symbol;
            oReturn.TimeInForce = this.TimeInForce;
            oReturn.Type = this.Type;

            return oReturn;
        }
        
        /// <summary>
        /// Send NEW order to the market
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            bool bReturn = false;

            Validate();

            LatamQuants.PrimaryAPI.Models.newSingleOrderRequest oReqNewOrder = new LatamQuants.PrimaryAPI.Models.newSingleOrderRequest();
            Service.mapper.Map<ModelViews.Order, LatamQuants.PrimaryAPI.Models.newSingleOrderRequest>(this, oReqNewOrder);
            LatamQuants.PrimaryAPI.Models.OrderId oResponse=RestAPI.newSingleOrder(oReqNewOrder).order;

            this.Proprietary = oResponse.proprietary;
            this.ClientOrderID = oResponse.clientId;
            this.Status = "SENT";

            bReturn = true;
            return bReturn;
        }

        public Order Clone()
        {
            return (Order)this.MemberwiseClone();
        }


        // Validate if Order information is OK to send it to Market.
        private void Validate()
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

        public static List<Order> UpdateOrders(List<Order> pOrderList, eUpdateOrdersMode pMode)
        {
            List<Order> colReturn = new List<Order>();

            if (pOrderList != null && pOrderList.Count > 0)
                colReturn = pOrderList;

            // Update all orders asking for all request done for current account.
            List<LatamQuants.PrimaryAPI.Models.Order> colOrders = null;

            if (pMode== eUpdateOrdersMode.ByAccount)
                colOrders= RestAPI.GetOrdersByAccount().orders;
            else if(pMode== eUpdateOrdersMode.ActiveOrders)
                colOrders = RestAPI.GetActiveOrders().orders;
            else if(pMode== eUpdateOrdersMode.FilledOrders)
                colOrders = RestAPI.GetOrdersFilled().orders;

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

        public static List<Order> UpdateOrders(List<Order> pOrderListOriginal, List<Order> pOrderListNews)
        {
            List<Order> colReturn = new List<Order>();

            colReturn = pOrderListOriginal;

            foreach (Order vOrder in pOrderListNews)
            {
                Order oOriginalOrder = null;

                // Check if order already exists
                if (colReturn != null)
                    oOriginalOrder = colReturn.Where(x => x.OrderID == (vOrder.OrderID ?? "") || x.ClientOrderID == vOrder.ClientOrderID).FirstOrDefault();

                // Update order
                if (oOriginalOrder != null)
                {
                    if (colReturn.Remove(oOriginalOrder))
                    {
                        oOriginalOrder.Update(vOrder);
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
            //this.DisplayQuantity = pOrder.DisplayQuantity;
            this.Price = pOrder.Price;
            this.Quantity = pOrder.Quantity;
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

        public void Update(string sOrderID, string sClientOrderID, string sExecutionID)
        {
            LatamQuants.PrimaryAPI.Models.Order oOrder=null;

            if (String.IsNullOrEmpty(sOrderID) == false)
            {
                // Update by OrderID
                oOrder = RestAPI.GetOrderByOrderID(sOrderID).order;
            }
            else if (String.IsNullOrEmpty(sClientOrderID) == false)
            {
                // Update by Client Order ID
                oOrder = RestAPI.GetOrderAllStatusByCliendOrderID(sClientOrderID).orders.LastOrDefault();
            }
            else if (String.IsNullOrEmpty(sExecutionID) == false)
            {
                // Update by Execution ID
                oOrder = RestAPI.GetOrderStatusByExecutionID(sExecutionID).orders.LastOrDefault();
            }

            if(oOrder != null)
            {
                Order vOrder = new Order();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.Order, ModelViews.Order>(oOrder, vOrder);
                Update(vOrder);
            }
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
