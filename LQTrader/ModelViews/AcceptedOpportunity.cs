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
using LatamQuants.Support;

namespace LQTrader.ModelViews
{
    public class AcceptedOpportunity
    {
        public Opportunity Opportunity { get; set; }
        public Strategy Strategy { get; set; }
        public LatamQuants.Entities.AcceptedOpportunity Data { get; set; }
        public List<ModelViews.Order> colOrders = new List<Order>();

        public AcceptedOpportunity(Strategy pStrategy, Opportunity pOpp, double pAmount, bool pAutoTrade=true)
        {
            Opportunity = pOpp;
            Strategy = pStrategy;

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
            Data.Simulation = Strategy.Simulation;
            Data.Save();

            // Start listening order updates.
            Services.Strategist.oWSOrderUpdates.OnDataReceived += new WebSocket<LatamQuants.PrimaryAPI.WebSocket.Request, LatamQuants.PrimaryAPI.WebSocket.Response>.OnDataReceivedEventHandler(OnOrderUpdateReceived);
            
            // Receive opportunity
            Task t1 = new Task(() => this.Receive());
            t1.Start();

            // Log opportunity.
            string sInfo = System.Environment.NewLine + "[Strategy]" + System.Environment.NewLine + pStrategy.ToString();
            sInfo = sInfo + System.Environment.NewLine + "[Opportunity]" + System.Environment.NewLine + pOpp.ToString();
            sInfo = sInfo + System.Environment.NewLine + "[AcceptedOpportunity]"+ System.Environment.NewLine + Data.ToString();
            LoggingService.Save(sInfo, "==NEW ACCEPTED OPPORTUNITY==");
        }

        private void OnOrderUpdateReceived(Object sender, WebSocket<LatamQuants.PrimaryAPI.WebSocket.Request, LatamQuants.PrimaryAPI.WebSocket.Response>.OnDataReceivedArgs e)
        {
            try
            {
                LatamQuants.PrimaryAPI.WebSocket.Response oOrderUpdate = (LatamQuants.PrimaryAPI.WebSocket.Response)e.oResponse;

                if (oOrderUpdate.Status != "ERROR")
                {
                    if (Strategy.StrategyID == 1)
                    {
                        ProcessOrderUpdateStrategy1(oOrderUpdate.OrderReport);
                    }
                }
                else
                {
                    // Log error.
                    string sError = "LQTrader.ModelViews.AcceptedOpportunity.OnOrderUpdateReceived()" + System.Environment.NewLine + "ERROR" + System.Environment.NewLine + oOrderUpdate.Description;

                    if (oOrderUpdate.OrderReport != null)
                    {
                        sError = sError + System.Environment.NewLine + "[OrderStatus]" + System.Environment.NewLine + oOrderUpdate.OrderReport.ToString();
                    }

                    LoggingService.Save(EnumLogType.Error, sError);

                    // TODO: Maybe could be proactive to ask API the status of the orders and update accepted opportunity status.
                }
            }
            catch (Exception ex)
            {
                // Log error.
                string sError = "LQTrader.ModelViews.AcceptedOpportunity.OnOrderUpdateReceived()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);
            }
        }

        private void ProcessOrderUpdateStrategy1(LatamQuants.PrimaryAPI.Models.Websocket.OrderStatus oOrderUpdate)
        {
            double feeIntradayEquities = 0.00296; // per trade
            double feeIntradayBonds = 0.00255; // per trade

            try
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

                            // Log order.
                            LoggingService.Save(EnumLogType.Information, "==SEND ORDER 2==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oOrder2.ToString());

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

                                    // Log
                                    string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                                    LoggingService.Save(sInfo, "==UPDATE ACCEPTED OPPORTUNITY==");
                                }
                            }
                            catch (Exception ex)
                            {
                                // Log error.
                                string sError = "LQTrader.ModelViews.AcceptedOpportunity.ProcessOrderUpdateStrategy1()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                                LoggingService.Save(EnumLogType.Error, sError);

                                // Update accepted opportunity.
                                Data.LastUpdate = DateTime.Now;
                                Data.ErrorDescription = ex.Message;
                                Data.Status = "Error";
                                Data.Update();

                                // Log.
                                string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                                LoggingService.Save(sInfo, "==UPDATE ACCEPTED OPPORTUNITY==");

                                // Update reserved amount.
                                double dAmount = (double)oOrder2.Price * oOrder2.Quantity;
                                Services.Strategist.CashReserved = Services.Strategist.CashReserved - Convert.ToDecimal(dAmount + feeIntradayEquities * dAmount);
                            }
                        }
                        else if (sFailOrderStatus.Contains(sStatus))
                        {
                            // Update accepted opportunity.
                            Data.LastUpdate = DateTime.Now;
                            Data.ErrorDescription = oUpdatedOrder.Text;
                            Data.Status = "Error";
                            Data.Update();

                            // Log.
                            string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                            LoggingService.Save(sInfo, "==UPDATE ACCEPTED OPPORTUNITY==");
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

                            // Log.
                            string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                            LoggingService.Save(sInfo, "==UPDATE ACCEPTED OPPORTUNITY==");
                        }
                        else if (sFailOrderStatus.Contains(sStatus))
                        {
                            // Update accepted opportunity.
                            Data.LastUpdate = DateTime.Now;
                            Data.ErrorDescription = oUpdatedOrder.Text;
                            Data.Status = "Error";
                            Data.Update();

                            // Log.
                            string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                            sInfo += System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oUpdatedOrder.ToString();
                            LoggingService.Save(sInfo, "==ACCEPTED OPPORTUNITY ERROR==");

                            // Update reserved amount.
                            Order oOrder2 = colOrders[1];
                            double dAmount = (double)oOrder2.Price * oOrder2.Quantity;
                            Services.Strategist.CashReserved = Services.Strategist.CashReserved - Convert.ToDecimal(dAmount + feeIntradayEquities * dAmount);

                            // Sell first order?
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string sError = "LQTrader.ModelViews.AcceptedOpportunity.ProcessOrderUpdateStrategy1()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);
            }
        }

        public void Receive()
        {
            Order oOrder = null;
            bool bResult = false;

            try
            {
                // Arbitrage
                if (Strategy.StrategyID == 1)
                {
                    // Order 1
                    oOrder = CreateOrderStrategy1(1);
                    colOrders.Add(oOrder);

                    // Log order.
                    LoggingService.Save(EnumLogType.Information, "==SEND ORDER 1==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oOrder.ToString());

                    // Send Order 1
                    if (Strategy.Simulation == false)
                    {
                        // LIVE TRADING
                        bResult = oOrder.Send();

                        if (bResult == true)
                        {
                            // Update order 1.
                            colOrders[0] = oOrder;

                            // Update accepted opportunity.
                            Data.Status = "In Progress";
                            Data.LastUpdate = DateTime.Now;
                            Data.OrderID1 = oOrder.ClientOrderID;
                            Data.Update();
                        }
                    }
                    else
                    {
                        // SIMULATION
                        Thread.Sleep(100);

                        // Supposing first order was well, send second one.
                        Order oSimulateOrder= CreateOrderStrategy1(2,oOrder.Quantity);
                        LoggingService.Save(EnumLogType.Information, "==SEND ORDER 2==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oSimulateOrder.ToString());

                        Thread.Sleep(100);

                        // Supposing second order was well, change accepted opportunity status.
                        this.Data.LastUpdate = DateTime.Now;
                        this.Data.Status = "Thanks";
                    }

                    // Wait until accepted opportunity change status to "Thanks" or "Error".
                    while (Data.Status == "In Progress")
                    {
                        Thread.Sleep(1000); // 1 second
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error.
                string sError = "LQTrader.ModelViews.AcceptedOpportunity.Receive()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                sError=sError + System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + this.Data.ToString();
                
                if(oOrder!=null)
                {
                    sError = sError + System.Environment.NewLine + "[Order]" + System.Environment.NewLine + oOrder.ToString();
                }

                LoggingService.Save(EnumLogType.Error, sError);
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

            try
            {
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
                if (pOrderNo == 1)
                {
                    sSymbol = Opportunity.Symbol1;
                    dPrice = Opportunity.BuyPrice1;
                    sSide = "Buy";

                    if (pQuantity > 0)
                        dQuantity = pQuantity;
                    else
                        dQuantity = (Convert.ToDouble(this.Data.CashReserved) * (1 - feeIntradayEquities)) / dPrice;
                }
                else if (pOrderNo == 2)
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
                oReturn.TimeInForce = "FOK";
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
            }
            catch (Exception ex)
            {
                string sError = "LQTrader.ModelViews.AcceptedOpportunity.CreateOrderStrategy1()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                sError = sError + System.Environment.NewLine + "[Opportunity]" + System.Environment.NewLine + this.Opportunity.ToString();
                sError = sError + System.Environment.NewLine + "[Order]" + System.Environment.NewLine + oReturn.ToString();
                LoggingService.Save(EnumLogType.Error, sError);
            }

            return oReturn;
        }
    }
}
