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

namespace LQTrader.Services
{
    public class Strategist
    {
        private static Task task;
        private static CancellationTokenSource cts;
        private static Dictionary<string, LatamQuants.PrimaryAPI.Models.MarketData> MarketDataMatrix = new Dictionary<string, LatamQuants.PrimaryAPI.Models.MarketData>();

        public static Strategist Instance = new Strategist();

        public delegate void OnOpportunityReceivedEventHandler(Object sender, OnOpportunityReceivedArgs e);
        public event OnOpportunityReceivedEventHandler OnOpportunityReceived;

        public static Dictionary<string, AcceptedOpportunity> AcceptedOpportunityMatrix = new Dictionary<string, AcceptedOpportunity>();
        public static List<Strategy> colStrategies = null;

        public static decimal CashAvailable = 50000;
        public static decimal CashReserved = 0;

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
                // Create new task
                cts = new CancellationTokenSource();
                task = new Task(() => Instance.Execute(cts), cts.Token, TaskCreationOptions.LongRunning);

                // Start it
                task.Start();
            }
            catch(Exception ex)
            {
                //TODO
            }
        }

        private async Task Execute(CancellationTokenSource tokenSource)
        {
            const int INSTRUMENT_LOT = 600;
            const int DEPTH = 2;
            const int FREQUENCY = 1;

            try
            {
                LatamQuants.PrimaryAPI.Models.InstrumentId oInstrumentId = null;

                // Load instruments to monitor.
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
                    List<LatamQuants.PrimaryAPI.WebSocket.MarketDataWebSocket> colSocket = new List<LatamQuants.PrimaryAPI.WebSocket.MarketDataWebSocket>();
                    int iRest = colInstrumentIds.Count % INSTRUMENT_LOT;
                    int iCountMax = (colInstrumentIds.Count - iRest)/ INSTRUMENT_LOT;
                    
                    for(int i=0;i<iCountMax;i++)
                    {
                        colInstruments2Send = colInstrumentIds.GetRange(i * INSTRUMENT_LOT, INSTRUMENT_LOT);
                        colSocket.Add(LatamQuants.PrimaryAPI.WebSocketAPI.CreateMarketDataSocket(colInstruments2Send, AllEntries, FREQUENCY, DEPTH));
                        colSocket[i].OnDataReceived += new WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedEventHandler(OnDataReceived);

                        try
                        {
                            await colSocket[i].Start();
                        }
                        catch(Exception ex)
                        {
                            // Websocket error
                            MessageBox.Show("Strategist.Execute() error subscribing " + i + " time.\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (iRest>0)
                    {
                        colSocket.Add(LatamQuants.PrimaryAPI.WebSocketAPI.CreateMarketDataSocket(colInstrumentIds.GetRange(iCountMax* INSTRUMENT_LOT, iRest), AllEntries, FREQUENCY, DEPTH));
                        colSocket[iCountMax].OnDataReceived += new WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedEventHandler(OnDataReceived);
                        await colSocket[iCountMax].Start();
                    }

                    //LatamQuants.PrimaryAPI.WebSocket.MarketDataWebSocket socket = LatamQuants.PrimaryAPI.WebSocketAPI.CreateMarketDataSocket(colInstrumentIds.GetRange(0, 300), AllEntries, 1, 2);
                    //socket.OnDataReceived += new WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedEventHandler(OnDataReceived);
                    //await socket.Start();
                }
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void OnDataReceived(Object sender, WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedArgs e)
        {
            LatamQuants.PrimaryAPI.Models.MarketData oNewMarketData = (LatamQuants.PrimaryAPI.Models.MarketData)e.oResponse;

            if (oNewMarketData.Status == "ERROR")
            {
                MessageBox.Show("OnDataReceived ERROR: " + oNewMarketData.Description, "WS ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Desactive instrument and remove from monitor.
                string sSymbol = oNewMarketData.Description.Substring(8, oNewMarketData.Description.Length - 8 - 17);
                LatamQuants.Entities.Instrument oInstrument=LatamQuants.Entities.Instrument.GetBySymbol(sSymbol);

                if (oInstrument != null)
                {
                    oInstrument.Active = false;
                    oInstrument.Update();
                    InstrumentMonitor.UpdateAll();
                }
            }
            else
            {
                //            if (oNewMarketData != null && oNewMarketData.Data != null && oNewMarketData.Instrument != null)
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

        private void StrategyArbEquities(LatamQuants.PrimaryAPI.Models.MarketData pMarketData)
        {
            const int STRATEGY_ID = 1;
            double dProfit = 0;
            string CfiCodes = "|ESXXXX|DBXXXX|DTXXXX|DYXTXR|EMXXXX|MXXXXX|";

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
                                    oOpportunity.SellPrice2 = colMDs[t].Data.Bids.FirstOrDefault().price;
                                    oOpportunity.AmountMax = (decimal)(Math.Min(colMDs[i].Data.Offers.FirstOrDefault().size, colMDs[t].Data.Bids.FirstOrDefault().size)* oOpportunity.BuyPrice1);
                                    oOpportunity.AmountMin = (decimal)(oInstrument.MinTradeVol * oOpportunity.BuyPrice1);
                                    oOpportunity.Currency = oInstrument.Currency;
                                    oOpportunity.DateTime = DateTime.Now;
                                    oOpportunity.MarketID = oInstrument.MarketID;
                                    oOpportunity.ProfitRate = dProfit * 100 / oOpportunity.BuyPrice1;
                                    oOpportunity.Symbol1 = colMDs[i].Instrument.symbol;
                                    oOpportunity.Symbol2 = colMDs[t].Instrument.symbol;
                                    oOpportunity.StrategyID = STRATEGY_ID;
                                    oOpportunity.Save();

                                    OnOpportunityReceived(this, new OnOpportunityReceivedArgs(oOpportunity, false));

                                    //// Check for Auto Trade option.
                                    //Strategy oStrategy = colStrategies.Where(x => x.StrategyID == STRATEGY_ID).FirstOrDefault();

                                    //if (oStrategy != null)
                                    //{
                                    //    if (oStrategy.AutoTrade == true && oStrategy.Active == true)
                                    //    {

                                    //    }
                                    //}
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
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

            return colReturn;
        }

        private void SaveMarketData(LatamQuants.PrimaryAPI.Models.MarketData pMarketData)
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
    }
}
