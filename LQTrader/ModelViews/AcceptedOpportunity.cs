using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LatamQuants.Entities;
using LatamQuants.PrimaryAPI.WebSocket.Net;
using System.Threading;

namespace LQTrader.ModelViews
{
    public class AcceptedOpportunity
    {
        public Opportunity Opportunity { get; set; }
        public Strategy Strategy { get; set; }
        public LatamQuants.Entities.AcceptedOpportunity Data { get; set; }
        public string Key { get; set; }
        public List<ModelViews.Order> colOrders = new List<Order>();

        public AcceptedOpportunity(Strategy pStrategy, Opportunity pOpp, double pAmount, bool pAutoTrade=true)
        {
            Opportunity = pOpp;
            Strategy = pStrategy;
            Key = Opportunity.Symbol1 + "|" + Opportunity.Symbol2;

            // Save accepted opportunity.
            Data = new LatamQuants.Entities.AcceptedOpportunity();
            Data.AcceptedDateTime = DateTime.Now;
            Data.AutoTrade = pAutoTrade;
            Data.OpportunityID = Opportunity.OpportunityID;
            Data.Status = "Accepted";
            Data.LastUpdate = DateTime.Now;
            Data.OrderID1 = ""; // Client Order ID 1
            Data.OrderID2 = ""; // Client Order ID 2
            Data.OrderID3 = ""; // Client Order ID 3
            Data.CashReserved = Convert.ToDecimal(pAmount);
            Data.Save();

            // Start listening order updates.
            Services.Strategist.oWSOrderUpdates.OnDataReceived += new WebSocket<LatamQuants.PrimaryAPI.WebSocket.Request, LatamQuants.PrimaryAPI.WebSocket.Response>.OnDataReceivedEventHandler(OnOrderUpdateReceived);
            
            // Receive opportunity
            Task t1 = new Task(() => this.Receive());
            t1.Start();
        }

        private void OnOrderUpdateReceived(Object sender, WebSocket<LatamQuants.PrimaryAPI.WebSocket.Request, LatamQuants.PrimaryAPI.WebSocket.Response>.OnDataReceivedArgs e)
        {
            LatamQuants.PrimaryAPI.WebSocket.Response oOrderUpdate = (LatamQuants.PrimaryAPI.WebSocket.Response)e.oResponse;

            if (oOrderUpdate.Status != "ERROR")
            {
                if(Strategy.StrategyID==1)
                {
                    ProcessOrderUpdateStrategy1(oOrderUpdate.OrderReport);
                }
            }
        }

        private void ProcessOrderUpdateStrategy1(LatamQuants.PrimaryAPI.Models.Websocket.OrderStatus oOrderUpdate)
        {
            string sClientOrderID = oOrderUpdate.ClientOrderId.ToString();
            string sFailOrderStatus = "|CANCELED|CANCELLED|REJECTED|EXPIRED|";
            bool bResult = false;

            Order oOrder = colOrders.Where(x => x.ClientOrderID == sClientOrderID).FirstOrDefault();

            if (oOrder != null)
            {
                Order oUpdatedOrder = new Order();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.Websocket.OrderStatus, ModelViews.Order>(oOrderUpdate, oUpdatedOrder);

                // Get order status.
                string sStatus = Order.GetBlotterStatus(oUpdatedOrder);

                // First order.
                if (colOrders.IndexOf(oOrder) == 0)
                {
                    if (sStatus == "FILLED")
                    {
                        // Order 2
                        Order oOrder2 = CreateOrderStrategy1(2, oUpdatedOrder.Quantity);
                        colOrders.Add(oOrder2);

                        // Send Order 2
                        try
                        {
                            bResult = oOrder2.Send();

                            if (bResult == true)
                            {
                                // Update order 2.
                                colOrders[1] = oOrder2;

                                // Update accepted opportunity.
                                Data.LastUpdate = DateTime.Now;
                                Data.OrderID2 = oOrder2.ClientOrderID;
                                Data.Update();
                            }
                        }
                        catch (Exception ex)
                        {
                            // Update accepted opportunity.
                            Data.LastUpdate = DateTime.Now;
                            Data.ErrorDescription = ex.Message;
                            Data.Status = "Error";
                            Data.Update();
                        }
                    }
                    else if (sFailOrderStatus.Contains(sStatus))
                    {
                        // Update accepted opportunity.
                        Data.LastUpdate = DateTime.Now;
                        Data.ErrorDescription = oUpdatedOrder.Text;
                        Data.Status = "Error";
                        Data.Update();
                    }
                }
                // Second order.
                else
                {
                    if (sStatus == "FILLED")
                    {
                        // Update accepted opportunity.
                        Data.LastUpdate = DateTime.Now;
                        Data.Status = "Thanks";
                        Data.Update();
                    }
                    else if (sFailOrderStatus.Contains(sStatus))
                    {
                        // Update accepted opportunity.
                        Data.LastUpdate = DateTime.Now;
                        Data.ErrorDescription = oUpdatedOrder.Text;
                        Data.Status = "Error";
                        Data.Update();

                        // Sell first order?
                    }
                }
            }
        }

        public void Receive()
        {
            Order oOrder = null;
            bool bResult = false;

            // Arbitrage
            if (Strategy.StrategyID == 1)
            {
                // Order 1
                oOrder = CreateOrderStrategy1(1);
                colOrders.Add(oOrder);

                // Send Order 1
                bResult=oOrder.Send();

                if(bResult==true)
                {
                    // Update order 1.
                    colOrders[0] = oOrder;

                    // Update accepted opportunity.
                    Data.Status = "In Progress";
                    Data.LastUpdate = DateTime.Now;
                    Data.OrderID1 = oOrder.ClientOrderID;
                    Data.Update();
                }

                // Wait until accepted opportunity change status to "Thanks" or "Error".
                while(Data.Status=="In Progress")
                {
                    Thread.Sleep(1000); // 1 second
                }
            }
        }

        private Order CreateOrderStrategy1(int pOrderNo, double pQuantity=0)
        {
            Order oReturn = new Order();
            InstrumentDetail oInstrument = null;
            string sSymbol = "";
            string sSide = "";
            double dPrice = 0;
            double dQuantity = 0;
            double feeIntradayEquities = 0.00296; // per trade
            double feeIntradayBonds = 0.00255; // per trade

            //--------------- Identification section
            oReturn.AccountID = Account.CurrentAccount.CustodyAccount;
            oReturn.OrderID = "";
            oReturn.ClientOrderID = "";
            oReturn.ExecutionID = "";
            oReturn.ReplaceClientOrderID = "";
            oReturn.CancelClientOrderID = "";
            oReturn.OriginalClientOrderID = "";
            oReturn.Proprietary = "";

            //--------------- Input section
            if(pOrderNo==1)
            {
                sSymbol = Opportunity.Symbol1;
                dPrice = Opportunity.BuyPrice1;
                sSide = "Buy";

                if (pQuantity > 0)
                    dQuantity = pQuantity;
                else
                    dQuantity = (Convert.ToDouble(this.Data.CashReserved) * (1 - feeIntradayEquities)) / dPrice;
            }
            else if(pOrderNo==2)
            {
                sSymbol = Opportunity.Symbol2;
                dPrice = Opportunity.SellPrice2;
                sSide = "Sell";

                if (pQuantity > 0)
                    dQuantity = pQuantity;
                else
                    dQuantity = colOrders[0].Quantity;
            }

            oInstrument = InstrumentDetail.colInstrumentDetails.Where(x => x.Symbol == sSymbol).FirstOrDefault();
            oReturn.MarketID = oInstrument.MarketID;
            oReturn.Symbol = oInstrument.Symbol;

            oReturn.Side = sSide;
            oReturn.Type = "Limit";
            oReturn.Price = dPrice;
            oReturn.Quantity = dQuantity;
            oReturn.TimeInForce = "IOC";
            oReturn.Iceberg = false;

            //--------------- Status section
            oReturn.TransactionTime = "";
            oReturn.AveragePrice = 0;
            oReturn.LastPrice = 0;
            oReturn.LeavesQuantity = 0;
            oReturn.CumulativeQuantity = 0;
            oReturn.LastQuantity = 0;
            oReturn.Status = "";
            oReturn.Text = "";

            return oReturn;
        }
    }
}
