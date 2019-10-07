using Entity;
using LQ.Support;
using QuickFix;
using QuickFix.Fields;
using QuickFix.Helper;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace INOMMarketByma.Byma
{
    public static class QuickFixMessageParser
    {
        internal static List<InstrumentByma> ListInstrumentByma { get; set; } = new List<InstrumentByma>();
        //internal static List<MarketDataRequestRecive> OrderMarketDataRequestRecive { get; set; }

        public static bool ParseSecurityListMessage(Message message)
        {
            bool worked = false;
            if (((QuickFix.FIX50.SecurityList)message).TotNoRelatedSym.Obj > 0)
            {
                for (int i = 0; i < Convert.ToInt32(message.GetField(Tags.NoRelatedSym)); i++)
                {
                    QuickFix.FIX50.SecurityList.NoRelatedSymGroup noRelatedSymGroup = (QuickFix.FIX50.SecurityList.NoRelatedSymGroup)message.GetGroup(i + 1, Tags.NoRelatedSym);
                    InstrumentByma orderMarketDataRecive = new InstrumentByma()
                    {
                        Symbol = noRelatedSymGroup.IsSetField(Tags.Symbol) == true ? noRelatedSymGroup.Symbol.Obj : null,
                        Currency = noRelatedSymGroup.IsSetField(Tags.Currency) == true ? noRelatedSymGroup.Currency.Obj : null,
                        SecurityID = noRelatedSymGroup.IsSetField(Tags.SecurityID) == true ? noRelatedSymGroup.SecurityID.Obj : null,
                        //NoSecurityAltID = noRelatedSymGroup.IsSetField(Tags.NoSecurityAltID) == true ? noRelatedSymGroup.NoSecurityAltID.Obj : (int?)null,
                        CFICode = noRelatedSymGroup.IsSetField(Tags.CFICode) == true ? noRelatedSymGroup.CFICode.Obj : null,
                        SecurityType = noRelatedSymGroup.IsSetField(Tags.SecurityType) == true ? noRelatedSymGroup.SecurityType.Obj : null,
                        SecurityExchange = noRelatedSymGroup.IsSetField(Tags.SecurityExchange) == true ? noRelatedSymGroup.SecurityExchange.Obj : null,
                        SecurityStat = noRelatedSymGroup.IsSetField(Tags.SecurityStat) == true ? noRelatedSymGroup.SecurityStat.Obj : null,
                        TradingSessionID = noRelatedSymGroup.IsSetField(Tags.TradingSessionID) == true ? noRelatedSymGroup.TradingSessionID.Obj : null,
                        //NoUnderlyings = noRelatedSymGroup.IsSetField(Tags.NoUnderlyings) == true ? noRelatedSymGroup.NoUnderlyings.Obj : (int?)null,
                        //NoTradingSessionRules_1309 = noRelatedSymGroup.IsSetField(Tags.NoTradingSessionRules)  == true ? noRelatedSymGroup.GetInt(Tags.NoTradingSessionRules) : (int?)null,
                    };

                    orderMarketDataRecive.SettlmntTyp = GetSettlmntTypFromSecurityIDParce(orderMarketDataRecive.SecurityID);

                    int? NoSecurityAltID = noRelatedSymGroup.IsSetField(Tags.NoSecurityAltID) == true ? noRelatedSymGroup.NoSecurityAltID.Obj : (int?)null;
                    if (NoSecurityAltID != null)
                    {
                        for (int y = 0; y < NoSecurityAltID; y++)
                        {
                            QuickFix.FIX50.SecurityList.NoRelatedSymGroup.NoSecurityAltIDGroup noSecurityAltIDGroup = (QuickFix.FIX50.SecurityList.NoRelatedSymGroup.NoSecurityAltIDGroup)noRelatedSymGroup.GetGroup(y + 1, Tags.NoSecurityAltID);
                            orderMarketDataRecive.SecurityAltID += (noSecurityAltIDGroup.IsSetField(Tags.SecurityAltID) == true ? noSecurityAltIDGroup.SecurityAltID.Obj : null) + ",";
                            orderMarketDataRecive.SecurityAltIDSource += (noSecurityAltIDGroup.IsSetField(Tags.SecurityAltIDSource) == true ? noSecurityAltIDGroup.SecurityAltIDSource.Obj : null) + ",";
                        }
                        orderMarketDataRecive.SecurityAltID = orderMarketDataRecive.SecurityAltID.Substring(0, orderMarketDataRecive.SecurityAltID.Length - 1);
                        orderMarketDataRecive.SecurityAltIDSource = orderMarketDataRecive.SecurityAltIDSource.Substring(0, orderMarketDataRecive.SecurityAltIDSource.Length - 1);
                    }

                    int? NoTradingSessionRules = noRelatedSymGroup.IsSetField(Tags.NoTradingSessionRules) == true ? noRelatedSymGroup.GetInt(Tags.NoTradingSessionRules) : (int?)null;

                    if (NoTradingSessionRules != null)
                    {
                        for (int x = 0; x < NoTradingSessionRules; x++)
                        {
                            Group noTradingSessionRules = noRelatedSymGroup.GetGroup(x + 1, Tags.NoTradingSessionRules);
                            int NoOrdTypeRules = noTradingSessionRules.GetInt(Tags.NoOrdTypeRules);
                            for (int y = 0; y < NoOrdTypeRules; y++)
                            {
                                orderMarketDataRecive.OrderType += (noTradingSessionRules.GetGroup(y + 1, Tags.NoOrdTypeRules).GetChar(Tags.OrdType)) + ",";
                            }
                            orderMarketDataRecive.OrderType = orderMarketDataRecive.OrderType.Substring(0, orderMarketDataRecive.OrderType.Length - 1);

                            orderMarketDataRecive.TradingSessionID = noTradingSessionRules.GetField(Tags.TradingSessionID);

                            int NoTimeInForceRules = noTradingSessionRules.GetInt(Tags.NoTimeInForceRules);
                            for (int y = 0; y < NoTimeInForceRules; y++)
                            {
                                orderMarketDataRecive.TimeInForce += (noTradingSessionRules.GetGroup(y + 1, Tags.NoTimeInForceRules).GetChar(Tags.TimeInForce)) + ",";
                            }
                            orderMarketDataRecive.TimeInForce = orderMarketDataRecive.TimeInForce.Substring(0, orderMarketDataRecive.TimeInForce.Length - 1);
                        }
                    }

                    ListInstrumentByma.Add(orderMarketDataRecive);
                    worked = true;
                }
            }
            else
            {
                string ComponentTarget = "ParseSecurityListMessage - Status -> " + QuickFixHelper.GetNameByValue(((QuickFix.FIX50.SecurityList)message).SecurityRequestResult.Obj,typeof(SecurityRequestResult));
                ErrorLog.Save(Assembly.GetEntryAssembly().GetName().Name, LogError.ReadErrorDescription(EnumErrorCode.OMS0106.ToString()), EnumErrorCode.OMS0106, ComponentTarget);
            }
            return worked;
        }

        public static void ParseTradeCaptureReport(Message message)
        {
            QuickFix.FIX50.TradeCaptureReport tradeCaptureReport = (QuickFix.FIX50.TradeCaptureReport)message;
            //tradeCaptureReport.LastPx


            BymaTradeCaptureReport bymaTradeCaptureReport = new BymaTradeCaptureReport()
            {
                ApplID = tradeCaptureReport.IsSetField(Tags.ApplID) ? tradeCaptureReport.GetField(Tags.ApplID) : null,
                ApplLastSeqNum = tradeCaptureReport.IsSetField(Tags.ApplLastSeqNum) ? Convert.ToInt32(tradeCaptureReport.GetField(Tags.ApplLastSeqNum)) : (int?)null,
                ApplResendFlag = tradeCaptureReport.IsSetField(Tags.ApplResendFlag) ? tradeCaptureReport.GetField(Tags.ApplResendFlag) == "N" ? false : true : (bool?)null,
                ApplSeqNum = tradeCaptureReport.IsSetField(Tags.ApplSeqNum) ? Convert.ToInt32(tradeCaptureReport.GetField(Tags.ApplSeqNum)) : (int?)null,
                Currency = tradeCaptureReport.IsSetField(Tags.Currency) ? tradeCaptureReport.GetField(Tags.Currency) : null,
                ExecType = tradeCaptureReport.ExecType.Obj.ToString(),
                FutSettDate = tradeCaptureReport.IsSetField(Tags.FutSettDate) ? tradeCaptureReport.GetField(Tags.FutSettDate) : null,
                GrossTradeAmt = tradeCaptureReport.GrossTradeAmt.Obj,
                IDSource = tradeCaptureReport.IsSetField(Tags.IDSource) ? tradeCaptureReport.GetField(Tags.IDSource) : null,
                LastQty = tradeCaptureReport.LastQty.Obj,
                LastPx = tradeCaptureReport.LastPx.Obj,
                LastShares = tradeCaptureReport.IsSetField(Tags.LastShares) ? Convert.ToInt32(tradeCaptureReport.GetField(Tags.LastShares)) : (int?)null,
                LotType = tradeCaptureReport.IsSetField(Tags.LotType) ? tradeCaptureReport.GetField(Tags.LotType) : null,
                MatchStatus = tradeCaptureReport.MatchStatus.Obj.ToString(),
                MatchType = tradeCaptureReport.MatchType.Obj,
                MultiLegReportingType = tradeCaptureReport.MultiLegReportingType.Obj.ToString(),
                NoSides = tradeCaptureReport.NoSides.Obj,
                NumericOrderID = tradeCaptureReport.IsSetField(29500) ? tradeCaptureReport.GetField(29500) : null,
                OrderCategory = tradeCaptureReport.IsSetField(Tags.OrderCategory) ? tradeCaptureReport.GetField(Tags.OrderCategory) : null,
                PriceSetter = tradeCaptureReport.IsSetField(29502) ? tradeCaptureReport.GetField(29502) : null,
                PriceType = tradeCaptureReport.PriceType.Obj,
                ProductComplex = tradeCaptureReport.IsSetField(Tags.ProductComplex) ? tradeCaptureReport.GetField(Tags.ProductComplex) : null,
                SecondaryTradeID = tradeCaptureReport.SecondaryTradeID.Obj,
                SecurityID = tradeCaptureReport.SecurityID.Obj,
                SecurityType = tradeCaptureReport.SecurityType.Obj,
                SettlmntTyp = tradeCaptureReport.IsSetField(Tags.SettlmntTyp) ? tradeCaptureReport.GetField(Tags.SettlmntTyp) : null,
                SideExecID = tradeCaptureReport.IsSetField(Tags.SideExecID) ? tradeCaptureReport.GetField(Tags.SideExecID) : null,
                SideLiquidityInd = tradeCaptureReport.IsSetField(Tags.SideLiquidityInd) ? tradeCaptureReport.GetField(Tags.SideLiquidityInd) : null,
                Symbol = tradeCaptureReport.Symbol.Obj,
                TradeHandlingInstr = tradeCaptureReport.TradeHandlingInstr.Obj.ToString(),
                TradeID = tradeCaptureReport.TradeID.Obj,
                TradeLinkID = tradeCaptureReport.TradeLinkID.Obj,
                TradeReportID = tradeCaptureReport.TradeReportID.Obj,
                TradeReportTransType = tradeCaptureReport.TradeReportTransType.Obj,
                TradeReportType = tradeCaptureReport.TradeReportType.Obj,
                TransactTime = tradeCaptureReport.TransactTime.Obj,
                TrdType = tradeCaptureReport.TrdType.Obj,
                MaturityDate = tradeCaptureReport.IsSetField(Tags.MaturityDate) ? tradeCaptureReport.MaturityDate.Obj : null,
            };

            int? NoSides = tradeCaptureReport.IsSetField(Tags.NoSides) ? tradeCaptureReport.GetInt(Tags.NoSides) : (int?)null;

            if (NoSides != null) // Segun la documentacion de byma siempre es 1
            {
                //for (int x = 0; x < NoSides; x++)
                //{
                    QuickFix.FIX50.TradeCaptureReport.NoSidesGroup noSidesGroup = (QuickFix.FIX50.TradeCaptureReport.NoSidesGroup)tradeCaptureReport.GetGroup(1, Tags.NoSides);
                    //noSidesGroup.
                    bymaTradeCaptureReport.OrderID = noSidesGroup.OrderID.Obj;
                    bymaTradeCaptureReport.Side = noSidesGroup.Side.Obj.ToString();
                    bymaTradeCaptureReport.ClOrdID = noSidesGroup.ClOrdID.Obj;
                    bymaTradeCaptureReport.Account = noSidesGroup.Account.Obj;
                    bymaTradeCaptureReport.AccountType = noSidesGroup.AccountType.Obj;
                    bymaTradeCaptureReport.OrderCapacity = noSidesGroup.OrderCapacity.Obj.ToString();
                    bymaTradeCaptureReport.NetMoney = noSidesGroup.NetMoney.Obj;
                    bymaTradeCaptureReport.AccruedInterestAmt = noSidesGroup.IsSetField(Tags.AccruedInterestAmt) ? noSidesGroup.AccruedInterestAmt.Obj : (decimal?)null;
                    BymaOrder bymaOrder = Retrieve.GetBymaOrderFromClOrdID(bymaTradeCaptureReport.ClOrdID);
                    if(bymaOrder != null)
                    {
                        bymaTradeCaptureReport.BymaOrderID = bymaOrder.BymaOrderID;
                        bymaTradeCaptureReport.MarketOrderID = bymaOrder.MarketOrderID;
                    }
                    // bymaTradeCaptureReport.OrderCategory = noSidesGroup.OrderCategory.Obj;
                    //noSidesGroup.IsSetField(Tags.OrderID) ? tradeCaptureReport.GetField(Tags.OrderID) : null,
                    BymaTradeCaptureReport.Save(bymaTradeCaptureReport);
                //}
            }
            MarketTrade marketTrades = INOM.MarketByma.Service.mapper.Map<BymaTradeCaptureReport, MarketTrade>(bymaTradeCaptureReport);

            switch (bymaTradeCaptureReport.TradeReportTransType)
            {
                case TradeReportTransType.NEW:
                    MarketTrade.Save(marketTrades);
                    break;
                case TradeReportTransType.CANCEL:
                    //TODO
                    MarketTrade.Update(marketTrades);
                    break;
                default:
                    break;
            }
            
           
        }

        public static void ParseExecutionReport(Message message)
        {
            QuickFix.FIX50.ExecutionReport executionReport = (QuickFix.FIX50.ExecutionReport)message;
            BymaOrder bymaOrder = Retrieve.GetBymaOrderFromClOrdID(executionReport.ClOrdID.Obj);
            BymaExecutionReport bymaExecutionReport = new BymaExecutionReport
            {
                BymaOrderID = bymaOrder.BymaOrderID,
                MarketOrderID = bymaOrder.MarketOrderID,
                Account = executionReport.Account.Obj,
                AccountType = executionReport.IsSet(new AccountType()) ? executionReport.AccountType.Obj : (int?)null,
                ClOrdID = executionReport.ClOrdID.Obj,
                CumQty = executionReport.CumQty.Obj,
                Currency = executionReport.Currency.Obj,
                DisplayQty = executionReport.DisplayQty.Obj,
                ExecID = executionReport.ExecID.Obj,
                ExecType = executionReport.ExecType.Obj.ToString(),
                LastPx = executionReport.IsSet(new LastPx()) ? executionReport.LastPx.Obj : (decimal?)null,
                LastQty = executionReport.IsSet(new LastQty()) ? executionReport.LastQty.Obj : (decimal?)null,
                LeavesQty = executionReport.IsSet(new LeavesQty()) ? executionReport.LeavesQty.Obj : 0,
                MultiLegReportingType = executionReport.MultiLegReportingType.Obj,
                OrdStatus = executionReport.OrdStatus.Obj.ToString(),
                OrdType = executionReport.OrdType.Obj.ToString(),
                OrderCapacity = executionReport.OrderCapacity.Obj.ToString(),
                OrderID = executionReport.OrderID.Obj,
                OrderQty = executionReport.IsSet(new OrderQty()) ? executionReport.OrderQty.Obj : 0,
                OrdRejReason = executionReport.IsSet(new OrdRejReason()) ? executionReport.OrdRejReason.Obj : (int?)null,
                PreTradeAnonymity = executionReport.IsSet(new PreTradeAnonymity()) ? executionReport.PreTradeAnonymity.Obj ? "Y" : "N" : null,
                Price = executionReport.IsSet(new Price()) ? executionReport.Price.Obj : (decimal?)null,
                SecurityID = executionReport.SecurityID.Obj,
                SecurityIDSource = executionReport.SecurityIDSource.Obj,
                SecurityType = executionReport.SecurityType.Obj,
                SettlType = executionReport.SettlType.Obj,
                Side = executionReport.Side.Obj.ToString(),
                Symbol = executionReport.Symbol.Obj,
                Text = executionReport.IsSet(new Text()) ? executionReport.Text.Obj : (string)null,
                TimeInForce = executionReport.TimeInForce.Obj.ToString(),
                TransactTime = executionReport.TransactTime.Obj,
                MDEntryID = executionReport.GetField(Tags.MDEntryID),
                ApplID = executionReport.GetField(Tags.ApplID),
                TradeFlag = executionReport.GetField(29501)

            };
            BymaExecutionReport.Save(bymaExecutionReport);


            bymaOrder.MarketOwnOrderID = bymaExecutionReport.OrderID;
            //UPDATE CommStatus
            bymaOrder.Status = bymaExecutionReport.OrdStatus;
            bymaOrder.CommStatus = "C"; //COMPLETED
            BymaOrder.Update(bymaOrder); //MarketOwnOrderID

            bool hasOperations = bymaExecutionReport.CumQty > 0;

            INOM.MarketByma.Models.Byma.SendBackSmartRouting(bymaOrder.MarketOrderID, bymaOrder.Status, hasOperations);
        }

        private static string GetSettlmntTypFromSecurityIDParce(string securityID)
        {
            string returnValue = null;
            if(securityID != null && securityID.Contains("-"))
            {
                if (int.TryParse(securityID.Split('-')[1], out int settlmntTyp))
                {
                    returnValue = settlmntTyp.ToString();
                }
            }
            return returnValue;
        }


        //internal static void ParseMarketDataSnapShotFullRefreshMessage(Message message)
        //{
        //    for (int i = 0; i < Convert.ToInt32(message.GetField(Tags.NoMDEntries)); i++)
        //    {
        //        QuickFix.FIX50.MarketDataSnapshotFullRefresh.NoMDEntriesGroup NoMDEntriesGroup = (QuickFix.FIX50.MarketDataSnapshotFullRefresh.NoMDEntriesGroup)message.GetGroup(i + 1, Tags.NoMDEntries);
        //        MarketDataRequestRecive marketDataRequestRecive = new MarketDataRequestRecive()
        //        {
        //            Id = OrderMarketDataRequestRecive.Count(),
        //            MDEntryType_269 = NoMDEntriesGroup.IsSetField(Tags.MDEntryType) == true ? NoMDEntriesGroup.MDEntryType.Obj : (char?)null,
        //            MDEntryPx_270 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPx) == true ? NoMDEntriesGroup.MDEntryPx.Obj : (decimal?)null,
        //            MDEntrySize_271 = NoMDEntriesGroup.IsSetField(Tags.MDEntrySize) == true ? NoMDEntriesGroup.MDEntrySize.Obj : (decimal?)null,
        //            NumberOfOrders_346 = NoMDEntriesGroup.IsSetField(Tags.NumberOfOrders) == true ? NoMDEntriesGroup.NumberOfOrders.Obj : (int?)null,
        //            MDEntryPositionNo_290 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPositionNo) == true ? NoMDEntriesGroup.MDEntryPositionNo.Obj : (int?)null,
        //            SettlType_63 = NoMDEntriesGroup.IsSetField(Tags.SettlType) == true ? NoMDEntriesGroup.SettlType.Obj : null,
        //        };
        //        marketDataRequestRecive.Description = string.Format("{0} - Price: {1} - Type: {2}", QFHelper.GetNameByValue(marketDataRequestRecive.MDEntryType_269, typeof(MDEntryType)), marketDataRequestRecive.MDEntryPx_270, QFHelper.GetNameByValue(marketDataRequestRecive.SettlType_63, typeof(SettlType)));
        //        OrderMarketDataRequestRecive.Add(marketDataRequestRecive);
        //    }
        //}

        //internal static void ParseMarketDataIncrementalRefreshMessage(Message message)
        //{
        //    for (int i = 0; i < Convert.ToInt32(message.GetField(Tags.NoMDEntries)); i++)
        //    {
        //        QuickFix.FIX50.MarketDataIncrementalRefresh.NoMDEntriesGroup NoMDEntriesGroup = (QuickFix.FIX50.MarketDataIncrementalRefresh.NoMDEntriesGroup)message.GetGroup(i + 1, Tags.NoMDEntries);
        //        MarketDataRequestRecive marketDataRequestRecive = new MarketDataRequestRecive()
        //        {
        //            Id = OrderMarketDataRequestRecive.Count(),
        //            MDEntryType_269 = NoMDEntriesGroup.IsSetField(Tags.MDEntryType) == true ? NoMDEntriesGroup.MDEntryType.Obj : (char?)null,
        //            MDEntryPx_270 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPx) == true ? NoMDEntriesGroup.MDEntryPx.Obj : (decimal?)null,
        //            MDEntrySize_271 = NoMDEntriesGroup.IsSetField(Tags.MDEntrySize) == true ? NoMDEntriesGroup.MDEntrySize.Obj : (decimal?)null,
        //            NumberOfOrders_346 = NoMDEntriesGroup.IsSetField(Tags.NumberOfOrders) == true ? NoMDEntriesGroup.NumberOfOrders.Obj : (int?)null,
        //            MDEntryPositionNo_290 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPositionNo) == true ? NoMDEntriesGroup.MDEntryPositionNo.Obj : (int?)null,
        //            SettlType_63 = NoMDEntriesGroup.IsSetField(Tags.SettlType) == true ? NoMDEntriesGroup.SettlType.Obj : null,
        //        };
        //        marketDataRequestRecive.Description = string.Format("{0} - Price: {1} - Type: {2}", QFHelper.GetNameByValue(marketDataRequestRecive.MDEntryType_269, typeof(MDEntryType)), marketDataRequestRecive.MDEntryPx_270, QFHelper.GetNameByValue(marketDataRequestRecive.SettlType_63, typeof(SettlType)));
        //        OrderMarketDataRequestRecive.Add(marketDataRequestRecive);
        //    }
        //}

        //internal static bool ParseExecutionReport(Message message)
        //{
        //    QuickFix.FIX50.ExecutionReport executionReport = (QuickFix.FIX50.ExecutionReport)message;

        //    bool changed = false;

        //    string OrdStatus = QFHelper.GetNameByValue(executionReport.OrdStatus.Obj, typeof(OrdStatus));
        //    if (message.IsSetField(Tags.Text))
        //    {
        //        OrdStatus += " - " + message.GetField(Tags.Text);
        //    }
        //    if (ChangeState(new Operacion()
        //    {
        //        ClOrdID_11 = executionReport.ClOrdID.Obj,
        //        OrdStatus_39 = OrdStatus,
        //        Price_44 = executionReport.IsSet(new Price()) == true ? executionReport.Price.Obj : 0,
        //        OrderQty_38 = executionReport.IsSet(new OrderQty()) == true ? executionReport.OrderQty.Obj : 0,
        //        LastPx_31 = executionReport.IsSet(new LastPx()) == true ? executionReport.LastPx.Obj : 0,
        //        LastQty_32 = executionReport.IsSet(new LastQty()) == true ? executionReport.LastQty.Obj : 0,
        //        NetMoney_118 = executionReport.IsSet(new NetMoney()) == true ? executionReport.NetMoney.Obj : 0,
        //        LeavesQty_151 = executionReport.IsSet(new LeavesQty()) == true ? executionReport.LeavesQty.Obj : 0,
        //        Side_54 = executionReport.Side.Obj,
        //    }))
        //    {
        //        changed = true;
        //    }

        //    return changed;
        //}

        //internal static bool ParseTradeCaptureReportMessage(Message message)
        //{
        //    QuickFix.FIX50.TradeCaptureReport tradeCaptureReport = (QuickFix.FIX50.TradeCaptureReport)message;
        //    bool changed = false;

        //    for (int i = 0; i < Convert.ToInt32(tradeCaptureReport.NoSides.Obj); i++)
        //    {
        //        QuickFix.FIX50.TradeCaptureReport.NoSidesGroup noSidesGroup = (QuickFix.FIX50.TradeCaptureReport.NoSidesGroup)tradeCaptureReport.GetGroup(i + 1, Tags.NoSides);
        //        string OrdStatus = "Finalizado";
        //        if (message.IsSetField(Tags.OrdStatus))
        //        {
        //            OrdStatus += " " + QFHelper.GetNameByValue(message.GetField(Tags.OrdStatus), typeof(OrdStatus));
        //        }


        //        if (ChangeState(new Operacion() {
        //            ClOrdID_11 = noSidesGroup.ClOrdID.Obj.ToString(),
        //            OrdStatus_39 = OrdStatus,
        //            //Price_44 = tradeCaptureReport.IsSetField(Tags.Price) == true ? tradeCaptureReport.Price.Obj : 0,
        //            OrderQty_38 = tradeCaptureReport.IsSetField(Tags.OrderQty) == true ? tradeCaptureReport.OrderQty.Obj : 0,
        //            LastPx_31 = tradeCaptureReport.LastPx.Obj,
        //            LastQty_32 = tradeCaptureReport.LastQty.Obj,
        //            NetMoney_118 = noSidesGroup.NetMoney.Obj,
        //            LeavesQty_151 = message.IsSetField(new LeavesQty()) == true ? Convert.ToDecimal(message.GetField(Tags.LeavesQty)) : 0,
        //            Side_54 = noSidesGroup.Side.Obj
        //        }))
        //        {
        //            changed = true;
        //        }
        //    }
        //    return changed;
        //}

        //private static bool ChangeState(Operacion operacion)
        //{
        //    bool changed = false;
        //    switch (operacion.Side_54)
        //    {
        //        case Side.BUY:
        //            ListCompra.Add(operacion);
        //            changed = true;
        //            break;
        //        case Side.SELL:
        //            ListVenta.Add(operacion);
        //            changed = true;
        //            break;
        //        default:
        //            break;
        //    }
        //    return changed;
        //}
    }
}

