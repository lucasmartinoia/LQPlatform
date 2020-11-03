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

            // Log opportunity.
            string sInfo = System.Environment.NewLine + "[Strategy]" + System.Environment.NewLine + pStrategy.ToString();
            sInfo = sInfo + System.Environment.NewLine + "[Opportunity]" + System.Environment.NewLine + pOpp.ToString();
            sInfo = sInfo + System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
            LoggingService.Save(sInfo, "==NEW ACCEPTED OPPORTUNITY==");

            // Start listening order updates.
            //Services.Strategist.oWSOrderUpdates.OnDataReceived += new WebSocket<LatamQuants.PrimaryAPI.WebSocket.Request, LatamQuants.PrimaryAPI.WebSocket.Response>.OnDataReceivedEventHandler(OnOrderUpdateReceived);
            
            // Receive opportunity
            Task t2 = new Task(() => this.Receive());
            t2.Start();

        }

        public void Receive()
        {
            Order oOrder = null;
            bool bResult = false;
            bool bResult2 = false;
            DateTime dtStartAt = DateTime.Now;
            const int EXPIRATION_MINUTES = 120;

            try
            {
                // Arbitrage
                if (Strategy.StrategyID == 1)
                {
                    // Order 1
                    oOrder = CreateOrderStrategy1(1);
                    colOrders.Add(oOrder);

                    // Log order.
                    LoggingService.Save(EnumLogType.Information, "==SEND ORDER 1==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oOrder.ToString() + System.Environment.NewLine);

                    // Send Order 1
                    if (Strategy.Simulation == false)
                    {
                        // LIVE TRADING
                        bResult = oOrder.Send();

                        // Create order 2.
                        Order oOrder2 = CreateOrderStrategy1(2, oOrder.Quantity);
                        colOrders.Add(oOrder2);

                        if (bResult == true)
                        {
                            Thread.Sleep(200);

                            // Recheck sell price and size for 2nd order.
                            double dblPrice = GetCurrentMarketPrice(oOrder2.MarketID, oOrder2.Symbol, oOrder2.Quantity, false);

                            if (dblPrice > 0 && dblPrice!=oOrder2.Price)
                            {
                                oOrder2.Price = dblPrice;
                                bResult2 = oOrder2.Send();
                                LoggingService.Save(EnumLogType.Information, "==SEND ORDER 2 (PRICE CHANGED)==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oOrder2.ToString() + System.Environment.NewLine);
                            }
                            else if(dblPrice>0 && dblPrice==oOrder2.Price)
                            {
                                bResult2 = oOrder2.Send();
                                LoggingService.Save(EnumLogType.Information, "==SEND ORDER 2 (SAME PRICE)==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oOrder2.ToString() + System.Environment.NewLine);
                            }
                            else
                            {
                                // Without liquidity in the market.
                                bResult2 = oOrder2.Send();
                                LoggingService.Save(EnumLogType.Information, "==SEND ORDER 2 (THERE ISN'T LIQUIDITY)==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oOrder2.ToString() + System.Environment.NewLine);
                            }
                        }

                        // Check send task results.

                        if (bResult == true)
                        {
                            // Update order 1.
                            colOrders[0] = oOrder;

                            // Ask broker for order.
                            Order oOrderUpdated = oOrder.Clone();
                            oOrderUpdated.Update(null, oOrder.ClientOrderID, null);
                            colOrders[0] = oOrderUpdated;
                        }

                        if (bResult2 == true)
                        {
                            // Update order 2.
                            colOrders[1] = oOrder2;

                            // Ask broker for order.
                            Thread.Sleep(200);
                            Order oOrderUpdated = oOrder2.Clone();
                            oOrderUpdated.Update(null, oOrder2.ClientOrderID, null);
                            colOrders[1] = oOrderUpdated;
                            OrderManagementStrategy1(2);
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

                        if (Data.Status == "In Progress")
                        {
                            // Check expiration time.
                            if (dtStartAt.AddMinutes(EXPIRATION_MINUTES) >= DateTime.Now)
                            {
                                if (colOrders.Count > 1)
                                {
                                    // Update second order.
                                    Order oOrder2 = colOrders[1].Clone();
                                    oOrder2.Update(null, oOrder2.ClientOrderID, null);
                                    colOrders[1] = oOrder2;
                                    OrderManagementStrategy1(2, true);
                                }
                            }
                        }
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

        private void OrderManagementStrategy1(int pOrderNo, bool pSellPosition=false)
        {
            string sFailOrderStatus = "|CANCELED|CANCELLED|REJECTED|EXPIRED|";
            double feeIntradayEquities = 0.00296; // per trade
            double feeIntradayBonds = 0.00255; // per trade
            bool bResult = false;
            string sStatus = colOrders[pOrderNo - 1].Status;

            // FIRST ORDER
            if (pOrderNo == 1)
            {
                if (sStatus == "FILLED")
                {
                    // Update accepted opportunity.
                    Data.Status = "In Progress";
                    Data.LastUpdate = DateTime.Now;
                    Data.OrderID1 = colOrders[pOrderNo - 1].ClientOrderID;
                    Data.Update();

                    // Order 2
                    Order oOrder2 = CreateOrderStrategy1(2, colOrders[pOrderNo - 1].Quantity);
                    colOrders.Add(oOrder2);

                    // Log order.
                    LoggingService.Save(EnumLogType.Information, "==SEND ORDER 2==" + System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + oOrder2.ToString());

                    // Send Order 2
                    try
                    {
                        bResult = oOrder2.Send();

                        if (bResult == true)
                        {
                            // Ask broker for order.
                            Thread.Sleep(100);
                            Order oOrderUpdated = oOrder2.Clone();
                            oOrderUpdated.Update(null, oOrder2.ClientOrderID, null);
                            colOrders[1] = oOrderUpdated;
                            OrderManagementStrategy1(2);
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
                    Data.OrderID1 = colOrders[pOrderNo - 1].ClientOrderID;
                    Data.ErrorDescription = colOrders[pOrderNo - 1].Text;
                    Data.Status = "Error";
                    Data.Update();

                    // Log.
                    string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                    LoggingService.Save(sInfo, "==UPDATE ACCEPTED OPPORTUNITY==");
                }
            }
            // SECOND ORDER
            else if (pOrderNo == 2)
            {
                if (pSellPosition == false)
                {
                    if (sStatus == "FILLED")
                    {
                        // Update accepted opportunity.
                        Data.LastUpdate = DateTime.Now;
                        Data.OrderID2 = colOrders[pOrderNo - 1].ClientOrderID;
                        Data.Status = "Thanks";
                        Data.Update();

                        // Log.
                        string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                        LoggingService.Save(sInfo, "==UPDATE ACCEPTED OPPORTUNITY - THANKS !!! ==");
                    }
                    else if (sFailOrderStatus.Contains(sStatus))
                    {
                        // Update accepted opportunity.
                        Data.LastUpdate = DateTime.Now;
                        Data.OrderID2 = colOrders[pOrderNo - 1].ClientOrderID;
                        Data.ErrorDescription = colOrders[pOrderNo - 1].Text;
                        Data.Status = "Error";
                        Data.Update();

                        // Log.
                        string sInfo = System.Environment.NewLine + "[AcceptedOpportunity]" + System.Environment.NewLine + Data.ToString();
                        sInfo += System.Environment.NewLine + "[ORDER]" + System.Environment.NewLine + colOrders[pOrderNo - 1].ToString();
                        LoggingService.Save(sInfo, "==ACCEPTED OPPORTUNITY ERROR==");

                        // Update reserved amount.
                        Order oOrder2 = colOrders[1];
                        double dAmount = (double)oOrder2.Price * oOrder2.Quantity;
                        Services.Strategist.CashReserved = Services.Strategist.CashReserved - Convert.ToDecimal(dAmount + feeIntradayEquities * dAmount);

                        // Sell position.
                        pSellPosition = true;
                    }
                }

                if(pSellPosition==true)
                {
                    Order oOrder = colOrders[pOrderNo - 1].Clone();

                    // Get current price for quantity.
                    double dblPrice = GetCurrentMarketPrice(oOrder.MarketID,oOrder.Symbol,oOrder.Quantity,false);

                    if (dblPrice > 0)
                    {
                        if (sFailOrderStatus.Contains(sStatus))
                        {
                            // Create a new order to sell position.
                            bResult = oOrder.Send();

                            if (bResult == true)
                            {
                                colOrders[1] = oOrder;
                                LoggingService.Save(EnumLogType.Information, "NEW REPLACEMENT ORDER SENT " + oOrder.ClientOrderID);
                            }
                            else
                            {
                                LoggingService.Save(EnumLogType.Error, "ERROR SENDING REPLACEMENT ORDER FOR " + colOrders[pOrderNo - 1].ClientOrderID);
                            }
                        }
                        else if (sStatus == "PENDING")
                        {
                            // Modify order.
                            ModelViews.Order oNewOrder = oOrder.Replace(dblPrice, oOrder.Quantity);
                            colOrders[1] = oNewOrder; // Replace second order in collection.
                            LoggingService.Save(EnumLogType.Information, "REPLACEMENT ORDER SENT " + oNewOrder.ClientOrderID);
                        }
                    }
                    else
                    {
                        LoggingService.Save(EnumLogType.Information, "NOT PRICE FOR REPLACEMENT ORDER " + colOrders[pOrderNo - 1].ClientOrderID);
                    }
                }
            }
        }

        private double GetCurrentMarketPrice(string sMarketID, string sSymbol, double dSize, bool bBuy)
        {
            double dReturn = 0;
            IEnumerable<LatamQuants.PrimaryAPI.Models.Trade> colTrades = null;

            LatamQuants.PrimaryAPI.Models.MarketData oMD = Services.Strategist.MarketDataMatrix[sMarketID + "|" + sSymbol];

            if (bBuy == true)
                colTrades = oMD.Data.Offers;
            else
                colTrades = oMD.Data.Bids;
                
            if (colTrades != null && colTrades.Count() > 0)
            {
                foreach (LatamQuants.PrimaryAPI.Models.Trade oTrade in colTrades)
                {
                    if (oTrade.size >=dSize)
                    {
                        dReturn = oTrade.price;
                        break;
                    }
                }
            }

            return dReturn;
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
            string timeInForce = "";
            double dPriceConversionFactor = 0;
            string sMarketID = "";
            double dProfitRate = 0;
            double dRefPrice = 0;

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
                    oInstrument = InstrumentDetail.colInstrumentDetails.Where(x => x.Symbol == sSymbol).FirstOrDefault();
                    sMarketID = oInstrument.MarketID;
                    dPriceConversionFactor = oInstrument.PriceConvertionFactor;
                    dPrice = Opportunity.BuyPrice1;
                    sSide = "Buy";
                    timeInForce = "FOK";

                    if (pQuantity > 0)
                        dQuantity = pQuantity;
                    else
                        dQuantity = (Convert.ToDouble(this.Data.CashReserved) * (1 - feeIntradayEquities)) / dPrice / dPriceConversionFactor;

                }
                else if (pOrderNo == 2)
                {
                    sSymbol = Opportunity.Symbol2;
                    oInstrument = InstrumentDetail.colInstrumentDetails.Where(x => x.Symbol == sSymbol).FirstOrDefault();
                    sMarketID = oInstrument.MarketID;
                    dPriceConversionFactor = oInstrument.PriceConvertionFactor;
                    dPrice = Opportunity.SellPrice2;
                    sSide = "Sell";
                    timeInForce = "Day";

                    if (pQuantity > 0)
                        dQuantity = pQuantity;
                    else
                        dQuantity = colOrders[0].Quantity;

                    if(dQuantity>0)
                    {
                        // Check reference price for the quantity.
                        LatamQuants.PrimaryAPI.Models.MarketData oMD1 = Services.Strategist.MarketDataMatrix[this.Opportunity.MarketID + "|" + this.Opportunity.Symbol1];
                        LatamQuants.PrimaryAPI.Models.MarketData oMD2 = Services.Strategist.MarketDataMatrix[this.Opportunity.MarketID + "|" + this.Opportunity.Symbol2];
                        dProfitRate = Services.Strategist.Instance.StrategyArbEquitiesProfit(oMD1, oMD2, out dRefPrice, dQuantity);

                        // If reference price is set => this price could reduce risk of not found enough liquidity for first sell price, 
                        // else use the original price and cross the fingers.
                        if(dRefPrice>0)
                        {
                            dPrice = dRefPrice;
                        }
                    }
                }

                oReturn.MarketID = sMarketID;
                oReturn.Symbol = sSymbol;

                oReturn.Side = sSide;
                oReturn.Type = "Limit";
                oReturn.Price = dPrice;
                oReturn.Quantity = dQuantity;
                oReturn.TimeInForce = timeInForce;
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
