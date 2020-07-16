using LatamQuants.Entities;
using LatamQuants.PrimaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI.WebSocket.Net;
using System.Windows.Forms;
using LatamQuants.Support;

namespace LQTrader.Services
{
    public class Strategist
    {
        private static Task task;
        private static CancellationTokenSource cts;
        public static Dictionary<string, LatamQuants.PrimaryAPI.Models.MarketData> MarketDataMatrix = new Dictionary<string, LatamQuants.PrimaryAPI.Models.MarketData>();

        public static Strategist Instance = new Strategist();

        public delegate void OnOpportunityReceivedEventHandler(Object sender, OnOpportunityReceivedArgs e);
        public event OnOpportunityReceivedEventHandler OnOpportunityReceived;

        // Store on going opportunities. Key = Symbol1+|+Symbol2.
        //public static Dictionary<string, ModelViews.AcceptedOpportunity> AcceptedOpportunityMatrix = new Dictionary<string, ModelViews.AcceptedOpportunity>();
        
        public static List<ModelViews.AcceptedOpportunity> colAcceptedOpportunities = new List<ModelViews.AcceptedOpportunity>();
        public List<Strategy> colStrategies = null;

        // Store order updates. Key = clOrdId.
        public static Dictionary<string, LatamQuants.PrimaryAPI.Models.Websocket.OrderStatus> OrderUpdateMatrix = new Dictionary<string, LatamQuants.PrimaryAPI.Models.Websocket.OrderStatus>();

        // Cash management.
        public static decimal CashAvailable = 0; // Account cash available -  account margin amount
        public static decimal CashReserved = 0; // Reserved cash
        public static decimal AccountMarginAmount = 0; // Not available amount to trade.

        // Websocket connections.
        public static List<LatamQuants.PrimaryAPI.WebSocket.MarketDataWebSocket> colWSMarketData;
        public static LatamQuants.PrimaryAPI.WebSocket.OrderDataWebSocket oWSOrderUpdates;

        public class OnOpportunityReceivedArgs : EventArgs
        {
            public object opportunity;
            public bool accepted;

            public OnOpportunityReceivedArgs(object pOpportunity, bool pAccepted)
            {
                opportunity = pOpportunity;
                accepted = pAccepted;
            }
        }

        public Strategist()
        {
            // Load strategy list.
            colStrategies = Strategy.GetList();

            // Update initial amounts.
            AccountMarginAmount = LatamQuants.Entities.Account.CurrentAccount.CashMarginAmount;

            // Get current ARS T0 available.
            ModelViews.AccountReport oAccReport=ModelViews.AccountReport.GetAccountReport();

            if(oAccReport!=null && oAccReport.CurrencyBalances!=null)
            {
                ModelViews.AccountReport.CurrencyBalance oCurrBalance = oAccReport.CurrencyBalances.Where(x => x.Currency == "ARS").FirstOrDefault();

                if (oCurrBalance.T0Available != null)
                {
                    CashAvailable = Convert.ToDecimal(oCurrBalance.T0Available);
                    CashAvailable -= AccountMarginAmount;
                }
                else
                {
                    MessageBox.Show("There is not possible to get the account amount", "Market is closed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There is not possible to get the account information", "Account Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Entry[] AllEntries = {
            Entry.Bids,
            Entry.Offers,
            Entry.Last,
            Entry.Open,
            Entry.Close,
            Entry.SettlementPrice,
            Entry.SessionHighPrice,
            Entry.SessionLowPrice,
            Entry.Volume,
            Entry.OpenInterest,
            Entry.IndexValue,
            Entry.EffectiveVolume,
            Entry.NominalVolume
        };

        /// <summary>
        /// Starts Strategist process.
        /// </summary>
        public static void Start()
        {
            try
            {
                LoggingService.Save("Started","Strategist");

                // Create new task
                cts = new CancellationTokenSource();
                task = new Task(() => Instance.Execute(cts), cts.Token, TaskCreationOptions.LongRunning);

                // Start it
                task.Start();
            }
            catch(Exception ex)
            {
                string sError = "LQTrader.Strategist.Start()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);
            }
        }

        public static void Stop()
        {
            // Close websocket connections and finalize threads.
            cts.Cancel();
        }

        private async Task Execute(CancellationTokenSource tokenSource)
        {
            const int INSTRUMENT_LOT = 600;
            const int DEPTH = 2;
            const int FREQUENCY = 1;

            try
            {
                // Start listening WS order updates.
                //oWSOrderUpdates = LatamQuants.PrimaryAPI.WebSocketAPI.CreateOrderDataSocket(new[] { Account.CurrentAccount.CustodyAccount });
                //oWSOrderUpdates.OnDataReceived += new WebSocket<LatamQuants.PrimaryAPI.WebSocket.Request, LatamQuants.PrimaryAPI.WebSocket.Response>.OnDataReceivedEventHandler(OnOrderUpdateReceived);

                // Load instruments to monitor.
                LatamQuants.PrimaryAPI.Models.InstrumentId oInstrumentId = null;
                List<LatamQuants.Entities.Instrument> colInstruments = InstrumentMonitor.GetList().Select(x=>x.Instrument).ToList<LatamQuants.Entities.Instrument>();

                if (colInstruments.Count > 0)
                {
                    // Create instrumentIds list
                    List<LatamQuants.PrimaryAPI.Models.InstrumentId> colInstrumentIds = new List<InstrumentId>();
                    List<LatamQuants.PrimaryAPI.Models.InstrumentId> colInstruments2Send;

                    foreach (LatamQuants.Entities.Instrument oInstrument in colInstruments)
                    {
                        oInstrumentId = new InstrumentId();
                        Service.mapper.Map<LatamQuants.Entities.Instrument, LatamQuants.PrimaryAPI.Models.InstrumentId>(oInstrument, oInstrumentId);
                        colInstrumentIds.Add(oInstrumentId);
                    }

                    // Subscribe to all entries
                    colWSMarketData = new List<LatamQuants.PrimaryAPI.WebSocket.MarketDataWebSocket>();
                    int iRest = colInstrumentIds.Count % INSTRUMENT_LOT;
                    int iCountMax = (colInstrumentIds.Count - iRest)/ INSTRUMENT_LOT;
                    
                    for(int i=0;i<iCountMax;i++)
                    {
                        colInstruments2Send = colInstrumentIds.GetRange(i * INSTRUMENT_LOT, INSTRUMENT_LOT);
                        colWSMarketData.Add(LatamQuants.PrimaryAPI.WebSocketAPI.CreateMarketDataSocket(colInstruments2Send, AllEntries, FREQUENCY, DEPTH, tokenSource.Token));
                        colWSMarketData[i].OnDataReceived += new WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedEventHandler(OnMarketDataReceived);

                        try
                        {
                            await colWSMarketData[i].Start();
                        }
                        catch(Exception ex)
                        {
                            // Websocket error
                            string sError = "LQTrader.Strategist.Execute() subscribing " + i + " time.\n" + ex.Message;
                            LoggingService.Save(EnumLogType.Error, sError);
                            MessageBox.Show(sError, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (iRest>0)
                    {
                        colWSMarketData.Add(LatamQuants.PrimaryAPI.WebSocketAPI.CreateMarketDataSocket(colInstrumentIds.GetRange(iCountMax* INSTRUMENT_LOT, iRest), AllEntries, FREQUENCY, DEPTH, tokenSource.Token));
                        colWSMarketData[iCountMax].OnDataReceived += new WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedEventHandler(OnMarketDataReceived);
                        await colWSMarketData[iCountMax].Start();
                    }

                    //LatamQuants.PrimaryAPI.WebSocket.MarketDataWebSocket socket = LatamQuants.PrimaryAPI.WebSocketAPI.CreateMarketDataSocket(colInstrumentIds.GetRange(0, 300), AllEntries, 1, 2);
                    //socket.OnDataReceived += new WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedEventHandler(OnDataReceived);
                    //await socket.Start();
                }
            }
            catch (Exception ex)
            {
                if (tokenSource.IsCancellationRequested != true)
                {
                    string sError = "Strategist.Execute() error" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                    LoggingService.Save(EnumLogType.Error, sError);
                }
            }
        }

        private void OnMarketDataReceived(Object sender, WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedArgs e)
        {
            try
            {
                LatamQuants.PrimaryAPI.Models.MarketData oNewMarketData = (LatamQuants.PrimaryAPI.Models.MarketData)e.oResponse;

                if (oNewMarketData.Status == "ERROR")
                {
                    MessageBox.Show("OnMarketDataReceived ERROR: " + oNewMarketData.Description, "WS ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Desactive instrument and remove from monitor.
                    string sSymbol = oNewMarketData.Description.Substring(8, oNewMarketData.Description.Length - 8 - 17);
                    LatamQuants.Entities.Instrument oInstrument = LatamQuants.Entities.Instrument.GetBySymbol(sSymbol);

                    if (oInstrument != null)
                    {
                        oInstrument.Active = false;
                        oInstrument.Update();
                        InstrumentMonitor.UpdateAll();
                    }
                }
                else
                {
                    // TODO: Should I consider also market data without bids or without offers ??
                    if (oNewMarketData != null && oNewMarketData.Data != null &&
                        oNewMarketData.Data.Bids != null && oNewMarketData.Data.Bids.Count() > 0 &&
                        oNewMarketData.Data.Offers != null && oNewMarketData.Data.Offers.Count() > 0)
                    {
                        // Update data market matrix
                        Task t1 = new Task(() => this.UpdateMatrix(oNewMarketData));
                        t1.Start();

                        // Save md in db
                        Task t3 = new Task(() => this.SaveMarketData(oNewMarketData));
                        t3.Start();

                        // Check for opportunities
                        Task t2 = new Task(() => this.CheckOpportunities(oNewMarketData));
                        t2.Start();
                    }
                }
            }
            catch(Exception ex)
            {
                string sError = "LQTrader.Services.Strategist.OnMarketReceived()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);
            }
        }

        private void UpdateMatrix(LatamQuants.PrimaryAPI.Models.MarketData pMarketData)
        {
            MarketDataMatrix[pMarketData.Instrument.marketId + "|" + pMarketData.Instrument.symbol] = pMarketData;
        }

        private void CheckOpportunities(LatamQuants.PrimaryAPI.Models.MarketData pMarketData)
        {
            // Strategy Arbitrage Equities
            Task t1 = new Task(() => this.StrategyArbEquities(pMarketData));
            t1.Start();
        }

        private bool CheckOpportunityStrategy1(Opportunity pOpp, out string pErrorDesc)
        {
            bool bReturn = false;
            pErrorDesc = "";

            // Buy order.
            ModelViews.MarketDataRT oMD1 = ModelViews.MarketDataRT.GetMarketDataRT(pOpp.MarketID, pOpp.Symbol1, 2);

            if (oMD1 != null && oMD1.Offers != null && oMD1.Offers.Count > 0)
            {
                if (pOpp.BuyPrice1 != oMD1.Offers[0].Price)
                {
                    pErrorDesc = pErrorDesc + "BuyPrice differs: expected " + pOpp.BuyPrice1 + " found " + oMD1.Offers[0].Price + System.Environment.NewLine;
                }
                if(pOpp.Size1 != oMD1.Offers[0].Size)
                {
                    pErrorDesc = pErrorDesc + "Buy Size differs: expected " + pOpp.Size1 + " found " + oMD1.Offers[0].Size + System.Environment.NewLine;
                }
            }
            else
            {
                pErrorDesc = "MD not found for " + pOpp.Symbol1 + System.Environment.NewLine;
            }

            // Sell order.
            ModelViews.MarketDataRT oMD2 = ModelViews.MarketDataRT.GetMarketDataRT(pOpp.MarketID, pOpp.Symbol2, 2);

            if (oMD2 != null && oMD2.Bids != null && oMD2.Bids.Count > 0)
            {
                if (pOpp.SellPrice2 != oMD2.Bids[0].Price)
                {
                    pErrorDesc = pErrorDesc + "Sell Price differs: expected " + pOpp.SellPrice2 + " found " + oMD2.Bids[0].Price + System.Environment.NewLine;
                }
                if (pOpp.Size2 != oMD2.Bids[0].Size)
                {
                    pErrorDesc = pErrorDesc + "Sell Size differs: expected " + pOpp.Size2 + " found " + oMD2.Bids[0].Size + System.Environment.NewLine;
                }
            }
            else
            {
                pErrorDesc = pErrorDesc + "MD not found for " + pOpp.Symbol2 + System.Environment.NewLine;
            }

            if (pErrorDesc != "")
            {
                bReturn = false;
            }
            else
            {
                bReturn = true;
            }

            return bReturn;
        }

        private void StrategyArbEquities(LatamQuants.PrimaryAPI.Models.MarketData pMarketData)
        {
            const int STRATEGY_ID = 1;
            double dProfit = 0;
            string CfiCodes = "|ESXXXX|DBXXXX|DTXXXX|DYXTXR|EMXXXX|MXXXXX|";
            string Currencies = "|ARS|";
            double feeIntradayEquities = 0.00296; // per trade
            double feeIntradayBonds = 0.00255; // per trade
            Strategy oStrategy = colStrategies[STRATEGY_ID-1];

            try
            {
                // Check instrument type
                ModelViews.InstrumentDetail oInstrument = ModelViews.InstrumentDetail.colInstrumentDetails.Where(x => x.MarketID == pMarketData.Instrument.marketId && x.Symbol == pMarketData.Instrument.symbol).FirstOrDefault();

                if (CfiCodes.Contains(oInstrument.CFICode)==true) 
                {
                    // Get root symbol name and settlement period
                    int iLastMinus = oInstrument.Symbol.LastIndexOf("-");
                    string sSymbol = oInstrument.Symbol.Substring(0, iLastMinus - 1).Trim();

                    // Get prices for T0,T1 and T2
                    List<LatamQuants.PrimaryAPI.Models.MarketData> colMDs = GetEqMDList(oInstrument.MarketID, sSymbol);

                    // Only run with almost 2 items
                    if (colMDs.Count > 1)
                    {
                        for (int i = 0; i < colMDs.Count - 1; i++)
                        {
                            for (int t = i + 1; t < colMDs.Count; t++)
                            {
                                dProfit = StrategyArbEquitiesProfit(colMDs[i], colMDs[t]);

                                if (dProfit > 0)
                                {
                                    // Register opportunity.
                                    Opportunity oOpportunity = new Opportunity();
                                    oOpportunity.BuyPrice1 = colMDs[i].Data.Offers.FirstOrDefault().price;
                                    oOpportunity.Size1 = colMDs[i].Data.Offers.FirstOrDefault().size;
                                    oOpportunity.Timestamp1 = colMDs[i].Timestamp;
                                    oOpportunity.SellPrice2 = colMDs[t].Data.Bids.FirstOrDefault().price;
                                    oOpportunity.Size2 = colMDs[t].Data.Bids.FirstOrDefault().size;
                                    oOpportunity.Timestamp2 = colMDs[t].Timestamp;
                                    oOpportunity.Checked = oStrategy.CheckOpportunity;
                                    oOpportunity.AmountMax = (decimal)(Math.Min(oOpportunity.Size1, oOpportunity.Size2) * oOpportunity.BuyPrice1);
                                    oOpportunity.AmountMin = (decimal)(oInstrument.MinTradeVol * oOpportunity.BuyPrice1);
                                    oOpportunity.Currency = oInstrument.Currency;
                                    oOpportunity.DateTime = DateTime.Now;
                                    oOpportunity.MarketID = oInstrument.MarketID;
                                    oOpportunity.ProfitRate = dProfit * 100 / oOpportunity.BuyPrice1;
                                    oOpportunity.Symbol1 = colMDs[i].Instrument.symbol;
                                    oOpportunity.Symbol2 = colMDs[t].Instrument.symbol;
                                    oOpportunity.StrategyID = STRATEGY_ID;

                                    //// Check prices and sizes
                                    //if (oOpportunity.Checked==true)
                                    //{
                                    //    string sErrorDesc = "";
                                    //    bool bResult = CheckOpportunityStrategy1(oOpportunity, out sErrorDesc);
                                    //    oOpportunity.CheckPassed = bResult;
                                    //    oOpportunity.CheckError = sErrorDesc;
                                    //}

                                    oOpportunity.Save();

                                    //OnOpportunityReceived(this, new OnOpportunityReceivedArgs(oOpportunity, false));

                                    // Check for Auto Trade option.
                                    if (Currencies.Contains(oOpportunity.Currency) == true)
                                    {
                                        if (oStrategy != null)
                                        {
                                            if (oStrategy.Executable() == true)
                                            {
                                                bool bContinue = true;
                                                double cash4Opportunity = 0;

                                                // Check for same opportunity in progress.
                                                bContinue=colAcceptedOpportunities.Where(x => x.Opportunity.Symbol1 == oOpportunity.Symbol1 && x.Opportunity.Symbol2 == oOpportunity.Symbol2 && (x.Data.Status == "In Progress" || x.Data.Status =="Accepted")).Count()==0;

                                                // Filter of profit rate.
                                                if (bContinue == true)
                                                {
                                                    if (oOpportunity.Symbol2.EndsWith("24hs") == true && oOpportunity.ProfitRate < oStrategy.OppMinRate1)
                                                    {
                                                        bContinue = false;
                                                    }
                                                    else if (oOpportunity.Symbol2.EndsWith("48hs") == true && oOpportunity.ProfitRate < oStrategy.OppMinRate2)
                                                    {
                                                        bContinue = false;
                                                    }
                                                    else if(oOpportunity.Symbol1.EndsWith("CI")==false)
                                                    {
                                                        bContinue = false;
                                                    }
                                                }

                                                // Amount available
                                                if (bContinue == true)
                                                {
                                                    double cashAvailable = Convert.ToDouble(CashAvailable - CashReserved);
                                                    cash4Opportunity = oStrategy.GetAmountAvailable(cashAvailable)*(1-feeIntradayEquities*2);

                                                    if (cash4Opportunity > 0)
                                                    {
                                                        // Check if it's enough to enter.
                                                        bContinue = cash4Opportunity >= Convert.ToDouble(oOpportunity.AmountMin);

                                                        if(bContinue==false)
                                                        {
                                                            // Log information.
                                                            LoggingService.Save(EnumLogType.Information, "OPPORTUNITY NOT ACCEPTED: minimum amount, available " + cash4Opportunity.ToString() + System.Environment.NewLine + oOpportunity.ToString());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bContinue = false;
                                                    }
                                                }

                                                // READY TO ACCEPT THE OPPORTUNITY
                                                if (bContinue == true)
                                                {
                                                    CashReserved += Convert.ToDecimal(cash4Opportunity);
                                                    ModelViews.AcceptedOpportunity oAccepted = new ModelViews.AcceptedOpportunity(oStrategy, oOpportunity, cash4Opportunity,true);
                                                    colAcceptedOpportunities.Add(oAccepted);
                                                    //OnOpportunityReceived(this, new OnOpportunityReceivedArgs(oAccepted, true));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                string sError = "LQTrader.StrategistArbEquities()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);
            }
        }

        private double StrategyArbEquitiesProfit(LatamQuants.PrimaryAPI.Models.MarketData pMD1, LatamQuants.PrimaryAPI.Models.MarketData pMD2)
        {
            double dReturn = 0;
            double dCom1 = 0.005;
            double dCom2 = 0.00131;

            // Get prices
            double dPrice1 = pMD1.Data.Offers.First().price; // Buy price
            double dPrice2 = pMD2.Data.Bids.First().price; // Sell price

            if (dPrice1<dPrice2)
            {
                // Apply function
                dReturn = (dPrice2 - dPrice1) - (dCom1 * dPrice2 + dCom2 * dPrice1);
            }

            return dReturn;
        }

        public List<LatamQuants.PrimaryAPI.Models.MarketData> GetEqMDList(string pMarketId, string pSymbol)
        {
            List<LatamQuants.PrimaryAPI.Models.MarketData> colReturn = new List<LatamQuants.PrimaryAPI.Models.MarketData>();

            try
            {
                // Get CI
                string sKey = pMarketId + "|" + pSymbol + " - CI";

                if (MarketDataMatrix.ContainsKey(sKey) == true)
                {
                    colReturn.Add(MarketDataMatrix[sKey]);
                }

                // Get 24hs
                sKey = pMarketId + "|" + pSymbol + " - 24hs";

                if (MarketDataMatrix.ContainsKey(sKey) == true)
                {
                    colReturn.Add(MarketDataMatrix[sKey]);
                }

                // Get 24hs
                sKey = pMarketId + "|" + pSymbol + " - 48hs";

                if (MarketDataMatrix.ContainsKey(sKey) == true)
                {
                    colReturn.Add(MarketDataMatrix[sKey]);
                }
            }
            catch (Exception ex)
            {
                string sError = "LQTrader.Services.Strategist.GetEqMDList()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);
            }

            return colReturn;
        }

        private void SaveMarketData(LatamQuants.PrimaryAPI.Models.MarketData pMarketData)
        {
            try
            {
                if (pMarketData != null && pMarketData.Data != null &&
                    pMarketData.Data.Bids != null && pMarketData.Data.Bids.Count() > 0 &&
                    pMarketData.Data.Offers != null && pMarketData.Data.Offers.Count() > 0)
                {
                    // Update MD
                    string sql1 = "INSERT INTO[dbo].[MarketDatas] " +
                              "([Timestamp]" +
                              ",[MarketID]" +
                              ",[Symbol]" +
                              ",[OfferPrice]" +
                              ",[OfferSize]" +
                              ",[BidPrice]" +
                              ",[BidSize]" +
                              ",[NominalVolume]" +
                              ",[TradeVolume]" +
                              ",[IndexValue]" +
                              ",[OpenInterestSize]" +
                              ",[OpenInterestDate]" +
                              ",[TradeEffectiveVolume]" +
                              ",[DateTime]) " +
                        "VALUES (" + pMarketData.Timestamp + ",'" + pMarketData.Instrument.marketId + "','" + pMarketData.Instrument.symbol + "'" +
                              "," + (pMarketData.Data.Offers?.Count() > 0 ? pMarketData.Data.Offers.First().price.ToString() : "0") +
                              "," + (pMarketData.Data.Offers?.Count() > 0 ? pMarketData.Data.Offers.First().size.ToString() : "0") +
                              "," + (pMarketData.Data.Bids?.Count() > 0 ? pMarketData.Data.Bids.First().price.ToString() : "0") +
                              "," + (pMarketData.Data.Bids?.Count() > 0 ? pMarketData.Data.Bids.First().size.ToString() : "0") +
                              "," + (pMarketData.Data.NominalVolume == null ? "0" : pMarketData.Data.NominalVolume.ToString()) +
                              "," + (pMarketData.Data.Volume == null ? "0" : pMarketData.Data.Volume.ToString()) +
                              "," + (pMarketData.Data.IndexValue == null ? "0" : pMarketData.Data.IndexValue.ToString()) +
                              "," + (pMarketData.Data.OpenInterest == null ? "0" : pMarketData.Data.OpenInterest.size.ToString()) +
                              "," + (pMarketData.Data.OpenInterest == null ? "0" : pMarketData.Data.OpenInterest.datetime ?? "0") +
                              "," + (pMarketData.Data.EffectiveVolume == null ? "0" : pMarketData.Data.EffectiveVolume.ToString()) +
                              ", GETDATE());";

                    // Update Depths
                    if (pMarketData.Data.Bids != null && pMarketData.Data.Bids.Count() > 1)
                    {
                        foreach (LatamQuants.PrimaryAPI.Models.Trade oTrade in pMarketData.Data.Bids)
                        {
                            sql1 += " INSERT INTO [dbo].[MarketDataDepths] " +
                                            "([Timestamp],[MarketID],[Symbol],[Bid],[Price],[Volume]) " +
                                         "VALUES (" + pMarketData.Timestamp + ",'" + pMarketData.Instrument.marketId + "','" +
                                               pMarketData.Instrument.symbol + "',1," + (oTrade.price.ToString() ?? "0") + "," + (oTrade.size.ToString() ?? "0") + "); ";
                        }
                    }

                    if (pMarketData.Data.Offers != null && pMarketData.Data.Offers.Count() > 1)
                    {
                        foreach (LatamQuants.PrimaryAPI.Models.Trade oTrade in pMarketData.Data.Offers)
                        {
                            sql1 += " INSERT INTO [dbo].[MarketDataDepths] " +
                                            "([Timestamp],[MarketID],[Symbol],[Bid],[Price],[Volume]) " +
                                         "VALUES (" + pMarketData.Timestamp + ",'" + pMarketData.Instrument.marketId + "','" +
                                               pMarketData.Instrument.symbol + "',0," + (oTrade.price.ToString() ?? "0") + "," + (oTrade.size.ToString() ?? "0") + "); ";
                        }
                    }

                    // Impact database.
                    string sql = "BEGIN TRANSACTION " + sql1 + " COMMIT TRANSACTION;";

                    using (var ctx = new DBContext())
                    {
                        int iResult = ctx.Database.ExecuteSqlCommand(sql);
                    }
                }
            }
            catch (Exception ex)
            {
                string sError = "LQTrader.Services.Strategist.SaveMarketData()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);
            }
        }
    }
}
