using Entity;
using QuickFix;
using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BymaFixTester.WinForm
{
    public static class MessageParser
    {
        public static List<OrderMarketDataRecive> OrderMarketDataRecives { get; set; }
        public static List<MarketDataRequestRecive> OrderMarketDataRequestRecive { get; set; }
        public static BindingList<Operacion> ListCompra { get; set; } = new BindingList<Operacion>();
        public static BindingList<Operacion> ListVenta { get; set; } = new BindingList<Operacion>();

        internal static void ParseSecurityListMessage(Message message)
        {
            for (int i = 0; i < Convert.ToInt32(message.GetField(Tags.NoRelatedSym)); i++)
            {
                QuickFix.FIX50.SecurityList.NoRelatedSymGroup noRelatedSymGroup = (QuickFix.FIX50.SecurityList.NoRelatedSymGroup)message.GetGroup(i + 1, Tags.NoRelatedSym);
                OrderMarketDataRecive orderMarketDataRecive = new OrderMarketDataRecive()
                {
                    Symbol_55 = noRelatedSymGroup.IsSetField(Tags.Symbol) == true ? noRelatedSymGroup.Symbol.Obj : null,
                    Currency_15 = noRelatedSymGroup.IsSetField(Tags.Currency) == true ? noRelatedSymGroup.Currency.Obj : null,
                    SecurityID_48 = noRelatedSymGroup.IsSetField(Tags.SecurityID) == true ? noRelatedSymGroup.SecurityID.Obj : null,
                    NoSecurityAltID_454 = noRelatedSymGroup.IsSetField(Tags.NoSecurityAltID) == true ? noRelatedSymGroup.NoSecurityAltID.Obj : (int?)null,
                    CFICode_461 = noRelatedSymGroup.IsSetField(Tags.CFICode) == true ? noRelatedSymGroup.CFICode.Obj : null,
                    SecurityType_167 = noRelatedSymGroup.IsSetField(Tags.SecurityType) == true ? noRelatedSymGroup.SecurityType.Obj : null,
                    SecurityExchange_207 = noRelatedSymGroup.IsSetField(Tags.SecurityExchange) == true ? noRelatedSymGroup.SecurityExchange.Obj : null,
                    SecurityStat_965 = noRelatedSymGroup.IsSetField(Tags.SecurityStat) == true ? noRelatedSymGroup.SecurityStat.Obj : null,
                    TradingSessionID_336 = noRelatedSymGroup.IsSetField(Tags.TradingSessionID) == true ? noRelatedSymGroup.TradingSessionID.Obj : null,
                    NoUnderlyings_711 = noRelatedSymGroup.IsSetField(Tags.NoUnderlyings) == true ? noRelatedSymGroup.NoUnderlyings.Obj : (int?)null,
                    //NoTradingSessionRules_1309 = noRelatedSymGroup.IsSetField(Tags.NoTradingSessionRules)  == true ? noRelatedSymGroup.GetInt(Tags.NoTradingSessionRules) : (int?)null,
                };
                if (orderMarketDataRecive.NoSecurityAltID_454 != null)
                {
                    for (int y = 0; y < orderMarketDataRecive.NoSecurityAltID_454; y++)
                    {
                        QuickFix.FIX50.SecurityList.NoRelatedSymGroup.NoSecurityAltIDGroup noSecurityAltIDGroup = (QuickFix.FIX50.SecurityList.NoRelatedSymGroup.NoSecurityAltIDGroup)noRelatedSymGroup.GetGroup(y + 1, 454);
                        orderMarketDataRecive.SecurityAltID_455 = noSecurityAltIDGroup.IsSetField(Tags.SecurityAltID) == true ? noSecurityAltIDGroup.SecurityAltID.Obj : null;
                        orderMarketDataRecive.SecurityAltIDSource_456 = noSecurityAltIDGroup.IsSetField(Tags.SecurityAltIDSource) == true ? noSecurityAltIDGroup.SecurityAltIDSource.Obj : null;
                    }
                }

                Group noTradingSessionRules = noRelatedSymGroup.GetGroup(1, Tags.NoTradingSessionRules);
                orderMarketDataRecive.NoOrdTypeRules_1237 = noTradingSessionRules.GetInt(Tags.NoOrdTypeRules);
                orderMarketDataRecive.OrdType_40 = new char[(int)orderMarketDataRecive.NoOrdTypeRules_1237];
                for (int y = 0; y < orderMarketDataRecive.NoOrdTypeRules_1237; y++)
                {
                    orderMarketDataRecive.OrdType_40[y] = noTradingSessionRules.GetGroup(y + 1, Tags.NoOrdTypeRules).GetChar(Tags.OrdType);
                }

                orderMarketDataRecive.NoTimeInForceRules_1239 = noTradingSessionRules.GetInt(Tags.NoTimeInForceRules);
                orderMarketDataRecive.TimeInForce_59 = new char[(int)orderMarketDataRecive.NoTimeInForceRules_1239];
                for (int y = 0; y < orderMarketDataRecive.NoTimeInForceRules_1239; y++)
                {
                    orderMarketDataRecive.TimeInForce_59[y] = noTradingSessionRules.GetGroup(y + 1, Tags.NoTimeInForceRules).GetChar(Tags.TimeInForce);
                }
                orderMarketDataRecive.Id = OrderMarketDataRecives.Count();
                orderMarketDataRecive.Description = string.Format("{0} - {1} - {2}", orderMarketDataRecive.SecurityID_48, orderMarketDataRecive.CFICode_461, orderMarketDataRecive.Symbol_55);
                OrderMarketDataRecives.Add(orderMarketDataRecive);
            }
        }

        internal static void AddVenta(string clOrdID, Decimal price, Decimal quantity, string estado)
        {
            ListVenta.Add(new Operacion() { ClOrdID_11 = clOrdID, Side_54 = Side.SELL, Price_44 = price, OrderQty_38 = quantity, NetMoney_118 = price * quantity, OrdStatus_39 = estado });
        }
        internal static void AddCompra(string clOrdID, Decimal price, Decimal quantity, string estado)
        {
            ListCompra.Add(new Operacion() { ClOrdID_11 = clOrdID, Side_54 = Side.BUY, Price_44 = price, OrderQty_38 = quantity, NetMoney_118 = price * quantity, OrdStatus_39 = estado });
        }

        internal static void ParseMarketDataSnapShotFullRefreshMessage(Message message)
        {
            for (int i = 0; i < Convert.ToInt32(message.GetField(Tags.NoMDEntries)); i++)
            {
                QuickFix.FIX50.MarketDataSnapshotFullRefresh.NoMDEntriesGroup NoMDEntriesGroup = (QuickFix.FIX50.MarketDataSnapshotFullRefresh.NoMDEntriesGroup)message.GetGroup(i + 1, Tags.NoMDEntries);
                MarketDataRequestRecive marketDataRequestRecive = new MarketDataRequestRecive()
                {
                    Id = OrderMarketDataRequestRecive.Count(),
                    MDEntryType_269 = NoMDEntriesGroup.IsSetField(Tags.MDEntryType) == true ? NoMDEntriesGroup.MDEntryType.Obj : (char?)null,
                    MDEntryPx_270 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPx) == true ? NoMDEntriesGroup.MDEntryPx.Obj : (decimal?)null,
                    MDEntrySize_271 = NoMDEntriesGroup.IsSetField(Tags.MDEntrySize) == true ? NoMDEntriesGroup.MDEntrySize.Obj : (decimal?)null,
                    NumberOfOrders_346 = NoMDEntriesGroup.IsSetField(Tags.NumberOfOrders) == true ? NoMDEntriesGroup.NumberOfOrders.Obj : (int?)null,
                    MDEntryPositionNo_290 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPositionNo) == true ? NoMDEntriesGroup.MDEntryPositionNo.Obj : (int?)null,
                    SettlType_63 = NoMDEntriesGroup.IsSetField(Tags.SettlType) == true ? NoMDEntriesGroup.SettlType.Obj : null,
                };
                marketDataRequestRecive.Description = string.Format("{0} - Price: {1} - Type: {2}", QFHelper.GetNameByValue(marketDataRequestRecive.MDEntryType_269, typeof(MDEntryType)), marketDataRequestRecive.MDEntryPx_270, QFHelper.GetNameByValue(marketDataRequestRecive.SettlType_63, typeof(SettlType)));
                OrderMarketDataRequestRecive.Add(marketDataRequestRecive);
            }
        }

        internal static void ParseMarketDataIncrementalRefreshMessage(Message message)
        {
            for (int i = 0; i < Convert.ToInt32(message.GetField(Tags.NoMDEntries)); i++)
            {
                QuickFix.FIX50.MarketDataIncrementalRefresh.NoMDEntriesGroup NoMDEntriesGroup = (QuickFix.FIX50.MarketDataIncrementalRefresh.NoMDEntriesGroup)message.GetGroup(i + 1, Tags.NoMDEntries);
                MarketDataRequestRecive marketDataRequestRecive = new MarketDataRequestRecive()
                {
                    Id = OrderMarketDataRequestRecive.Count(),
                    MDEntryType_269 = NoMDEntriesGroup.IsSetField(Tags.MDEntryType) == true ? NoMDEntriesGroup.MDEntryType.Obj : (char?)null,
                    MDEntryPx_270 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPx) == true ? NoMDEntriesGroup.MDEntryPx.Obj : (decimal?)null,
                    MDEntrySize_271 = NoMDEntriesGroup.IsSetField(Tags.MDEntrySize) == true ? NoMDEntriesGroup.MDEntrySize.Obj : (decimal?)null,
                    NumberOfOrders_346 = NoMDEntriesGroup.IsSetField(Tags.NumberOfOrders) == true ? NoMDEntriesGroup.NumberOfOrders.Obj : (int?)null,
                    MDEntryPositionNo_290 = NoMDEntriesGroup.IsSetField(Tags.MDEntryPositionNo) == true ? NoMDEntriesGroup.MDEntryPositionNo.Obj : (int?)null,
                    SettlType_63 = NoMDEntriesGroup.IsSetField(Tags.SettlType) == true ? NoMDEntriesGroup.SettlType.Obj : null,
                };
                marketDataRequestRecive.Description = string.Format("{0} - Price: {1} - Type: {2}", QFHelper.GetNameByValue(marketDataRequestRecive.MDEntryType_269, typeof(MDEntryType)), marketDataRequestRecive.MDEntryPx_270, QFHelper.GetNameByValue(marketDataRequestRecive.SettlType_63, typeof(SettlType)));
                OrderMarketDataRequestRecive.Add(marketDataRequestRecive);
            }
        }

        internal static bool ParseExecutionReport(Message message)
        {
            QuickFix.FIX50.ExecutionReport executionReport = (QuickFix.FIX50.ExecutionReport)message;

            bool changed = false;

            string OrdStatus = QFHelper.GetNameByValue(executionReport.OrdStatus.Obj, typeof(OrdStatus));
            if (message.IsSetField(Tags.Text))
            {
                OrdStatus += " - " + message.GetField(Tags.Text);
            }
            if (ChangeState(new Operacion()
            {
                ClOrdID_11 = executionReport.ClOrdID.Obj,
                OrdStatus_39 = OrdStatus,
                Price_44 = executionReport.IsSet(new Price()) == true ? executionReport.Price.Obj : 0,
                OrderQty_38 = executionReport.IsSet(new OrderQty()) == true ? executionReport.OrderQty.Obj : 0,
                LastPx_31 = executionReport.IsSet(new LastPx()) == true ? executionReport.LastPx.Obj : 0,
                LastQty_32 = executionReport.IsSet(new LastQty()) == true ? executionReport.LastQty.Obj : 0,
                NetMoney_118 = executionReport.IsSet(new NetMoney()) == true ? executionReport.NetMoney.Obj : 0,
                LeavesQty_151 = executionReport.IsSet(new LeavesQty()) == true ? executionReport.LeavesQty.Obj : 0,
                Side_54 = executionReport.Side.Obj,
            }))
            {
                changed = true;
            }

            return changed;
        }

        internal static bool ParseTradeCaptureReportMessage(Message message)
        {
            QuickFix.FIX50.TradeCaptureReport tradeCaptureReport = (QuickFix.FIX50.TradeCaptureReport)message;
            bool changed = false;

            for (int i = 0; i < Convert.ToInt32(tradeCaptureReport.NoSides.Obj); i++)
            {
                QuickFix.FIX50.TradeCaptureReport.NoSidesGroup noSidesGroup = (QuickFix.FIX50.TradeCaptureReport.NoSidesGroup)tradeCaptureReport.GetGroup(i + 1, Tags.NoSides);
                string OrdStatus = "Finalizado";
                if (message.IsSetField(Tags.OrdStatus))
                {
                    OrdStatus += " " + QFHelper.GetNameByValue(message.GetField(Tags.OrdStatus), typeof(OrdStatus));
                }


                if (ChangeState(new Operacion()
                {
                    ClOrdID_11 = noSidesGroup.ClOrdID.Obj.ToString(),
                    OrdStatus_39 = OrdStatus,
                    //Price_44 = tradeCaptureReport.IsSetField(Tags.Price) == true ? tradeCaptureReport.Price.Obj : 0,
                    OrderQty_38 = tradeCaptureReport.IsSetField(Tags.OrderQty) == true ? tradeCaptureReport.OrderQty.Obj : 0,
                    LastPx_31 = tradeCaptureReport.LastPx.Obj,
                    LastQty_32 = tradeCaptureReport.LastQty.Obj,
                    NetMoney_118 = noSidesGroup.NetMoney.Obj,
                    LeavesQty_151 = message.IsSetField(new LeavesQty()) == true ? Convert.ToDecimal(message.GetField(Tags.LeavesQty)) : 0,
                    Side_54 = noSidesGroup.Side.Obj
                }))
                {
                    changed = true;
                }
            }
            return changed;
        }

        private static bool ChangeState(Operacion operacion)
        {
            bool changed = false;

            try
            {
                switch (operacion.Side_54)
                {
                    case Side.BUY:
                        ListCompra.Add(operacion);
                        changed = true;
                        break;
                    case Side.SELL:
                        ListVenta.Add(operacion);
                        changed = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }

            return changed;
        }
    }
}
