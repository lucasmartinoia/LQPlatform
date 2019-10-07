using INOM.Support;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace INOM.Entities
{
    public static class Retrieve
    {

        public static List<InstrumentByma> GetInstrumentsBymaFromBymaOrder(BymaOrder bymaOrder)
        {
            using (var db = new DBContext())
            {
                var instrumentByma = (from InstrumentByma in db.InstrumentsByma
                                      where  InstrumentByma.Symbol == bymaOrder.Symbol
                                      select InstrumentByma
                                 ).ToList();
                return instrumentByma;
            }
        }

        public static MaeOrder GetMaeOrderFromID(int orderID)
        {
            //TODO
            throw new NotImplementedException();
        }

        //TODO 
        //EL NOMBRE DE ESTA FUNCION ESTA MAL!!!!!
        public static OrderFund GetOrderIDFromMarketID(int marketOrderID)
        {
            using (var db = new DBContext())
            {
                var orderFund = (from marketOrders in db.MarketOrders
                                 join orden in db.OrderFunds on marketOrders.OrderID equals orden.OrderID
                                 where marketOrders.MarketOrderID == marketOrderID
                                 select orden
                                 ).FirstOrDefault();
                return orderFund;
            }
        }

        public static OrderBondEquity GetOrderBondEquityFromMarketOrderID(int marketOrderID)
        {
            using (var db = new DBContext())
            {
                var orderBondEquity = (from marketOrders in db.MarketOrders
                                 join orden in db.OrderBondEquities on marketOrders.OrderID equals orden.OrderID
                                 where marketOrders.MarketOrderID == marketOrderID
                                 select orden
                                 ).FirstOrDefault();
                return orderBondEquity;
            }
        }

        public static OrderFund GetOrderIDFromMarketTradeID(int marketTradeID)
        {
            using (var db = new DBContext())
            {
                var orderFund = (from fundsTrades in db.FundsTrades
                                 join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                 join orden in db.OrderFunds on marketOrders.OrderID equals orden.OrderID
                                 where fundsTrades.MarketTradeID == marketTradeID
                                 select orden
                                 ).FirstOrDefault();
                return orderFund;
            }
        }

        public static MarketOrder GetMarketOrderFromMarketOrderID(int marketOrderID)
        {
            using (var db = new DBContext())
            {
                MarketOrder marketOrder = db.MarketOrders.FirstOrDefault(t => t.MarketOrderID == marketOrderID);
                return (marketOrder);
            }
        }
        public static MarketOrder GetMarketOrderFromMarketOrderByOrderID(int orderID)
        {
            using (var db = new DBContext())
            {
                MarketOrder marketOrder = db.MarketOrders.FirstOrDefault(t => t.OrderID == orderID);
                return (marketOrder);
            }
        }

        public static int GetMarketIDFromName(string marketName)
        {
            using (var db = new DBContext())
            {
                var marketID = (from markets in db.Markets
                                   where markets.Name == marketName
                                   select markets.MarketID
                                   ).FirstOrDefault();
                return marketID;
            }
        }

        public static MarketOrder GetMarketOrderFromMarketTradeID(int marketTradeID)
        {
            using (var db = new DBContext())
            {
                var marketOrder = (from fundsTrades in db.FundsTrades
                                   join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                   where fundsTrades.MarketTradeID == marketTradeID
                                   select marketOrders                
                                   ).FirstOrDefault();
                return marketOrder;
            }
        }
        public static FundsTrade GetFundsTradeFromMarketOrderID(int marketOrderID)
        {
            using (var db = new DBContext())
            {
                FundsTrade fundsTrade = db.FundsTrades.FirstOrDefault(t => t.MarketOrderID == marketOrderID);
                return fundsTrade;
            }
        }
        public static FundsTrade GetFundsTradeFromMarketTradeID(int marketTradeID)
        {
            using (var db = new DBContext())
            {
                FundsTrade fundsTrade = db.FundsTrades.Find(marketTradeID);
                return fundsTrade;
            }
        }
        public static FundsTrade GetFundsTradeFromBackOfficeTradeID(int backOfficeTradeID)
        {
            using (var db = new DBContext())
            {
                FundsTrade fundsTrade = db.FundsTrades.FirstOrDefault(t => t.BackOfficeTradeID == backOfficeTradeID);
                return fundsTrade;
            }
        }
        public static FundsOrder GetFundsOrderFromOrderID(int OrderID)
        {
            //no se si anda.... esto hace Find por FundsOrderID.
            using (var db = new DBContext())
            {
                FundsOrder fundsOrder = db.FundsOrders.Include(a => a.MarketOrder).FirstOrDefault(t => t.MarketOrder.OrderID == OrderID);
                return fundsOrder;
            }
        }

        public static FundsOrder GetFundsOrderFromMarketOrderID(int MarketOrderID)
        {
            //no se si anda.... esto hace Find por FundsOrderID.
            using (var db = new DBContext())
            {
                //      FundsOrder fundsOrder = db.FundsOrders.Find(OrderID);
                FundsOrder fundsOrder = db.FundsOrders.FirstOrDefault(t => t.MarketOrderID == MarketOrderID);
                return fundsOrder;
            }
        }

        public static OrderFund GetOrderFundFromOrderID(int OrderID)
        {
            using (var db = new DBContext())
            {
                OrderFund OrderFund = db.OrderFunds
                                     .Include(a => a.Broker)
                                     .Include(a => a.Settlements)
                                     .Where(a => a.OrderID == OrderID)
                                     .FirstOrDefault();
                return OrderFund;
            }
        }

        public static List<InstrumentMae> GetInstrumentsMaeFromMaeOrder(MaeOrder maeOrder)
        {
            //TODO
            throw new NotImplementedException();
        }

        public static OrderFund GetOrderFromOrderID(int OrderID)
        {
            using (var db = new DBContext())
            {
                OrderFund OrderFund = db.OrderFunds
                                     .Include(a => a.Broker)
                                     .Include(a => a.Settlements)
                                     .Where(a => a.OrderID == OrderID)
                                     .FirstOrDefault();
                return OrderFund;
            }
        }



        public static OrderFund GetOrderFundFromOrderNumber(int OrderNumber)
        {
            using (var db = new DBContext())
            {
                OrderFund OrderFund = db.OrderFunds
                                     .Include(a => a.Broker)
                                     .Include(a => a.Settlements)
                                     .Where(a => a.OrderNumber == OrderNumber)
                                     .FirstOrDefault();
                return OrderFund;
            }
        }

        public static OrderFund GetOrderFundFromBackOfficeInputID(int BackOfficeInputID)
        {
            using (var db = new DBContext())
            {
                OrderFund OrderFund = db.OrderFunds
                                     .Include(a => a.Broker)
                                     .Include(a => a.Settlements)
                                     .Where(a => a.BackOfficeInputID == BackOfficeInputID)
                                     .FirstOrDefault();
                return OrderFund;
            }
        }

        public static List<OrderFund> GetOrderFundFromInstructionID(int InstructionID)
        {
            using (var db = new DBContext())
            {
                var OrderFund = db.OrderFunds
                                     .Include(a => a.Broker)
                                     .Include(a => a.Settlements)
                                     .Where(a => a.InstructionID == InstructionID)
                                     .ToList();
                return OrderFund;
            }
        }

        public static List<FundsTrade> GetMarketTradeToBackOffice()
        {
            using (var db = new DBContext())
            {
                IEnumerable<FundsTrade> model = (from fundsTrades in db.FundsTrades
                                                 join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                                 join orderFunds in db.OrderFunds on marketOrders.OrderID equals orderFunds.OrderID
                                                 where fundsTrades.BackOfficeCommStatus == "P" && orderFunds.InstructionID == null
                                                 && fundsTrades.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                                 select fundsTrades
                                                ).ToList();
                return model.ToList();
            }
        }

        public static List<int> GetInstructionCancelMarketTradeToBackOffice()
        {
            using (var db = new DBContext())
            {
                IEnumerable<int> model = (from fundsTrades in db.FundsTrades
                                          join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                          join instruction in db.InstructionFundsCancelOrders on marketOrders.OrderID equals instruction.OrderID
                                          from CalypsoResponse in instruction.CalypsoResponses.DefaultIfEmpty()
                                          where fundsTrades.Status != "A"
                                                && marketOrders.Status != "A"
                                                && instruction.Status == "P"
                                                && instruction.InstructionID != CalypsoResponse.InstructionID
                                                && instruction.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                          select instruction.InstructionID
                                         ).ToList();
                return model.ToList();
            }
        }

        public static List<int> GetInstructionAmendMarketTradeToBackOffice()
        {
            using (var db = new DBContext())
            {
                IEnumerable<int> model = (from orders in db.OrderFunds
                                          join instruction in db.InstructionFundsAmendOrders on orders.OrderID equals instruction.OrderID
                                          from CalypsoResponse in instruction.CalypsoResponses.DefaultIfEmpty()
                                          where orders.Action == "A"
                                                && instruction.Status == "P"
                                                && instruction.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                          select instruction.InstructionID
                                         ).ToList();
                return model.ToList();
            }
        }

        public static List<int> GetMissingInstructionCancelToSM()
        {
            using (var db = new DBContext())
            {
                IEnumerable<int> model = (from instructionCancel in db.InstructionFundsCancelOrders
                                          join order in db.OrderFunds on instructionCancel.OrderID equals order.OrderID
                                          join marketOrders in db.MarketOrders on instructionCancel.OrderID equals marketOrders.OrderID
                                          where                                            
                                                  marketOrders.Status != "A"
                                                  && instructionCancel.Status == "C"
                                                  && order.Status == "A"
                                                  && marketOrders.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                          select instructionCancel.InstructionID
                                        ).ToList();
                return model.ToList();
            }
        }
        public static List<int> GetMissingInstructionCancelToMF()
        {
            using (var db = new DBContext())
            {
                IEnumerable<int> model = (from instructionCancel in db.InstructionFundsCancelOrders
                                          join order in db.OrderFunds on instructionCancel.OrderID equals order.OrderID
                                          join marketOrders in db.MarketOrders on instructionCancel.OrderID equals marketOrders.OrderID
                                          from fundsTrades in marketOrders.FundsOrder.FundsTrades.DefaultIfEmpty()
                                          where
                                              fundsTrades.Status != "A"
                                              && fundsTrades.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                              && instructionCancel.Status == "C"
                                              && order.Status == "A"
                                              && marketOrders.Status == "A"
                                          select instructionCancel.InstructionID
                                        ).ToList();
                return model.ToList();
            }
        }

        public static MaeOrder GetMaeOrderFromClOrdID(string obj)
        {
            //TODO
            throw new NotImplementedException();
        }

        public static List<CalypsoResponse> GetInstructionAllNotFinish()
        {
            using (var db = new DBContext())
            {
                IEnumerable<CalypsoResponse> model = (from marketOrders in db.MarketOrders //on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                                                                           //join orderFunds in db.OrderFunds on marketOrders.OrderID equals orderFunds.OrderID
                                                      join calypsoResponses in db.CalypsoResponses on marketOrders.OrderID equals calypsoResponses.OrderID
                                                      join instruction in db.Instructions on calypsoResponses.InstructionID equals instruction.InstructionID
                                                      where instruction.Status == "P"
                                                      && calypsoResponses.Status == "E"
                                                      && calypsoResponses.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                                      select new CalypsoResponse
                                                      {
                                                          InstructionID = calypsoResponses.InstructionID,
                                                          Status = calypsoResponses.Status

                                                      }).ToList();
                return model.ToList();
            }
        }

        public static List<CalypsoResponse> GetInstructionFundsTradeNotFinish()
        {
            //ver si se usa
            using (var db = new DBContext())
            {
                IEnumerable<CalypsoResponse> model = (from fundsTrades in db.FundsTrades
                                                      join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                                      join calypsoResponses in db.CalypsoResponses on marketOrders.OrderID equals calypsoResponses.OrderID
                                                      join instruction in db.Instructions on calypsoResponses.InstructionID equals instruction.InstructionID
                                                      where fundsTrades.Status != "A"
                                                      && calypsoResponses.Status == "C"
                                                       && calypsoResponses.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                                      select new CalypsoResponse
                                                      {
                                                          InstructionID = calypsoResponses.InstructionID,
                                                          Status = calypsoResponses.Status

                                                      }).ToList();
                return model.ToList();
            }
        }

        public static List<CalypsoResponse> GetInstructionMarketOrderNotFinish()
        {
            //ver si se usa
            using (var db = new DBContext())
            {
                IEnumerable<CalypsoResponse> model = (from fundsTrades in db.FundsTrades
                                                      join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                                      join calypsoResponses in db.CalypsoResponses on marketOrders.OrderID equals calypsoResponses.OrderID
                                                      join instruction in db.Instructions on calypsoResponses.InstructionID equals instruction.InstructionID
                                                      where fundsTrades.Status == "A" && marketOrders.Status == "P"
                                                     && fundsTrades.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                                      select new CalypsoResponse
                                                      {
                                                          InstructionID = calypsoResponses.InstructionID,
                                                          Status = calypsoResponses.Status

                                                      }).ToList();
                return model.ToList();
            }
        }
        public static List<CalypsoResponse> GetInstructionlOrderFundNotFinish()
        {
            using (var db = new DBContext())
            {
                IEnumerable<CalypsoResponse> model = (from marketOrders in db.MarketOrders
                                                      join orderFunds in db.OrderFunds on marketOrders.OrderID equals orderFunds.OrderID
                                                      join instruction in db.Instructions on orderFunds.InstructionID equals instruction.InstructionID
                                                      join calypsoResponses in db.CalypsoResponses on instruction.InstructionID equals calypsoResponses.InstructionID
                                                      where marketOrders.Status == "A" && instruction.Status == "P"
                                                       && marketOrders.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                                      select new CalypsoResponse
                                                      {
                                                          InstructionID = calypsoResponses.InstructionID,
                                                          Status = calypsoResponses.Status

                                                      }).ToList();
                return model.ToList();
            }
        }
        public static List<CalypsoResponse> GetFundsTradeNotFinish()
        {
            using (var db = new DBContext())
            {
                var orderFund = (from fundsTrades in db.FundsTrades
                                 join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                 join calypsoResponses in db.CalypsoResponses on fundsTrades.MarketTradeID equals calypsoResponses.MarketTradeID
                                 where
                                 fundsTrades.BackOfficeCommStatus == "C"
                                 && fundsTrades.Status != calypsoResponses.Status
                                 && fundsTrades.Status != "A"
                                 && calypsoResponses.InstructionID == null
                                 && fundsTrades.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                 select new CalypsoResponse
                                 {
                                     MarketTradeID = calypsoResponses.MarketTradeID,
                                     Status = calypsoResponses.Status

                                 }).ToList();
                return orderFund.ToList();
            }
        }
        public static List<MarketOrder> GetMarketOrderNotFinish()
        {
            using (var db = new DBContext())
            {
                var orderFund = (from fundsTrades in db.FundsTrades
                                 join marketOrders in db.MarketOrders on fundsTrades.MarketOrderID equals marketOrders.MarketOrderID
                                 join calypsoResponses in db.CalypsoResponses on fundsTrades.MarketTradeID equals calypsoResponses.MarketTradeID
                                 where
                                 marketOrders.Status == "P"
                                 && fundsTrades.BackOfficeCommStatus == "C"
                                 && fundsTrades.Status == calypsoResponses.Status
                                 && marketOrders.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                 select new MarketOrder
                                 {
                                     MarketOrderID = marketOrders.MarketOrderID,
                                     Status = calypsoResponses.Status
                                 }).ToList();
                return orderFund.ToList();
            }
        }

        public static List<OrderFund> GetOrdersNotFinish()
        {
            using (var db = new DBContext())
            {
                var orderFund = (from orders in db.OrderFunds
                                 join marketOrders in db.MarketOrders on orders.OrderID equals marketOrders.OrderID
                                 join fundsTrades in db.FundsTrades on marketOrders.MarketOrderID equals fundsTrades.MarketOrderID
                                 join calypsoResponses in db.CalypsoResponses on fundsTrades.MarketTradeID equals calypsoResponses.MarketTradeID
                                 where
                                 marketOrders.Status != "P"
                                 && orders.Status == "P"
                                 && orders.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                 select new OrderFund
                                 {
                                     OrderID = marketOrders.OrderID,
                                     Status = calypsoResponses.Status
                                 }).ToList();
                return orderFund.ToList();
            }
        }
        public static List<OrderFund> GetOrdersNotInMarketOrders()
        {
            using (var db = new DBContext())
            {
                IEnumerable<OrderFund> model = (from order in db.OrderFunds
                                                from marketOrder in order.MarketOrders.DefaultIfEmpty()
                                                where marketOrder.OrderID == null
                                                    && order.Status != "A"
                                                    && order.Status != "E"
                                                    && order.Scheduled == false
                                                    && order.OnlyMigration == 0
                                                    && order.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                                select new OrderFund
                                                {
                                                    OrderID = order.OrderID
                                                }).ToList();
                return model.ToList();
            }
        }
        public static List<MarketOrder> GetMarketOrdersNotInFundsOrders()
        {
            using (var db = new DBContext())
            {
                IEnumerable<MarketOrder> model = db.MarketOrders
                                                    .Where
                                                    (
                                                        c => !db.FundsOrders
                                                        .Select(b => b.MarketOrderID)
                                                        .Contains(c.MarketOrderID)
                                                    )
                                                    .Where
                                                    (
                                                        s => s.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay)
                                                       && s.Status == "P"
                                                    )
                                                    .ToList();

                return model.ToList();
            }
        }

        public static Broker GetBrokerFromID(string ID)
        {
            using (var db = new DBContext())
            {
                Broker oBroker = db.Brokers.Find(ID);
                return oBroker;
            }
        }

        public static List<OrderFund> GetOrdersByFilter(OrderFundSearch item)
        {
            using (var db = new DBContext())
            {

                IEnumerable<OrderFund> model = db.OrderFunds.Where(
                                                b => b.BrokerID == item.BrokerID
                                                && (b.ChannelID == item.ChannelID || item.ChannelID == null || item.ChannelID == "")
                                                && (b.OperatorID == item.OperatorID || item.OperatorID == null || item.OperatorID == "")
                                                && (b.ClientID == item.ClientID || item.ClientID == null || item.ClientID == "")
                                                && (b.ProductType == item.ProductType || item.ProductType == null || item.ProductType == "")
                                                && (b.Status == item.Status || item.Status == null || item.Status == "")
                                                && (b.OrderDateTime.Date >= item.DateFrom || item.DateFrom == null)
                                                && (b.OrderDateTime.Date <= item.DateTo || item.DateTo == null)
                                                && (b.OrderID >= item.OrderIDFrom || item.OrderIDFrom == 0)
                                                && (b.OrderID <= item.OrderIDTo || item.OrderIDTo == 0)
                                                && (b.FundID == item.FundID || item.FundID == null || item.FundID == "")
                                                && (b.CustodyAccountNo == item.CustodyAccountNo || item.CustodyAccountNo == null || item.CustodyAccountNo == "")
                                                && (b.OrderType == item.OrderType || item.OrderType == null || item.OrderType == "")
                                                && (
                                                     (item.NotBackOffice == null)
                                                   || (item.NotBackOffice == false)
                                                   || (item.NotBackOffice == true &&
                                                         (b.MarketOrders.Count == 0 || b.MarketOrders[0].FundsOrder == null
                                                            || (b.MarketOrders[0].FundsOrder.FundsTrades.Count == 0
                                                                || (b.MarketOrders[0].FundsOrder.FundsTrades.Count > 0 && b.MarketOrders[0].FundsOrder.FundsTrades[0].BackOfficeTradeID == 0))
                                                         )
                                                       )
                                                   )
                                                )
                                                .Include("MarketOrders")
                                                .Include("MarketOrders.FundsOrder")
                                                .Include("MarketOrders.FundsOrder.FundsTrades")
                                                .ToList();
                return model.ToList();
            }
        }

        //    UIGetOrdersForInstruction

        public static List<UIOrderResult> UIGetOrdersForInstruction(OrderFundSearch item)
        {

            if (item.InstructionID > 0)
            {
                UIInstructionSearch itemInstruction = new UIInstructionSearch { InstruccionIDFrom = item.InstructionID, InstruccionIDTo = item.InstructionID };

                List<UIInstructionResult> ListaInstruccionDeLaOrden = UIGetInstructionsByFilters(itemInstruction);
                if (ListaInstruccionDeLaOrden.Count > 0)
                {
                    OrderFundSearch _OrderSearch = new OrderFundSearch();
                    if (ListaInstruccionDeLaOrden[0].Discriminator == "InstructionFundsCancelOrder")
                    {
                        _OrderSearch.OrderIDFrom = (int)ListaInstruccionDeLaOrden[0].InstructionFundsCancelOrder_OrderID;
                        _OrderSearch.OrderIDTo = (int)ListaInstruccionDeLaOrden[0].InstructionFundsCancelOrder_OrderID;
                    }
                    else
                    {
                        _OrderSearch.InstructionID = item.InstructionID;

                    }
                    return UIGetOrders(_OrderSearch);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public static List<UIOrderResult> UIGetOrders(OrderFundSearch item)
        {
            var DB = new DBContext();
            string SQL = "select  ";
            SQL += "o.Action,";
            SQL += "o.Amount,";
            SQL += "o.BrokerID,";
            SQL += "o.OrderNumber,";
            SQL += "o.ChannelID,";
            SQL += "o.ClientID,";
            SQL += "o.Comments,";
            SQL += "o.Currency,";
            SQL += "o.CustodyAccountNo,";
            SQL += "o.ExecutionDate,";
            SQL += "o.LastUpdate,";
            SQL += "o.OrderDateTime,";
            SQL += "o.Shares,";
            SQL += "o.FundID,";
            SQL += "o.LinkOrderID,";
            SQL += "o.OnlyMigration,";
            SQL += "o.OperationsStockTicket,";
            SQL += "o.OperatorID,";
            SQL += "o.OrderID,";
            SQL += "o.OrderType,";
            SQL += "o.Prenote,";
            SQL += "o.ExchangeRate,";
            SQL += "o.ProductType,";
            SQL += "o.RescueType,";
            SQL += "o.Scheduled,";
            SQL += " r.Link,";
            SQL += " case";
            SQL += " when o.Status = 'C' then 'assets/C.png' ";
            SQL += " when o.Status = 'E' then 'assets/E.png' ";
            SQL += " when o.Status = 'A' then 'assets/A.png' ";
            SQL += " when o.Status = 'P' then case ";
            SQL += " when o.Scheduled = 1 then 'assets/S.png' ";
            SQL += " else 'assets/P.png' ";
            SQL += " end ";
            SQL += " else  'assets/N.png' ";
            SQL += " end ";
            SQL += " as Status,";
            SQL += "m.MarketOrderID,";
            SQL += "f.BackOfficeTradeID,";
            SQL += "o.ExternalReference,";
            SQL += "cf.Denominacion 'FundDescription',";
            SQL += " case ";
            SQL += " when o.Status = 'C' then 'Completada (nro de operación: ' + cast(f.BackOfficeTradeID as varchar) + ')'";
            SQL += " when o.Status = 'E' then 'Error al ingresar a Calypso'";
            SQL += " when o.Status = 'A' then case";
            SQL += " when f.BackOfficeTradeID is null  then 'Orden Cancelada'";
            SQL += " when f.BackOfficeTradeID is not null  then 'Orden Cancelada (nro. operacion: ' + cast(f.BackOfficeTradeID as varchar) + ')'";
            SQL += " else   'Orden Cancelada'";
            SQL += " end";
            SQL += " when o.Status = 'P' then case ";
            SQL += " when o.Scheduled = 1 then 'Orden Programada' ";
            SQL += " else 'Orden Pendiente' ";
            SQL += " end ";
            SQL += " else  'Error, sin estado' ";
            SQL += " end ";
            SQL += " as DescriptionStatus,  ";
            SQL += " case ";
            SQL += " when o.OrderType = 'R' then  ";
            SQL += " case  ";
            SQL += " when o.Amount > 0 then cf.Denominacion + '-Rescate por ' + o.Currency + CAST(o.Amount as varchar) + '.' ";
            SQL += " else cf.Denominacion + '-Rescate por ' + cast(o.Shares as varchar) + ' partes.' ";
            SQL += " end ";
            SQL += " when o.OrderType = 'S' then case ";
            SQL += " when o.Amount > 0 then cf.Denominacion + '-Suscripcion por ' + o.Currency + CAST(o.Amount as varchar) + '.' ";
            SQL += " else cf.Denominacion + '-Suscripcion por ' + cast(o.Shares as varchar) + ' partes.' ";
            SQL += " end ";
            SQL += " else ' ' ";
            SQL += " end as   'DescriptionOrder' ";
            SQL += " from orders o left join  MarketOrders m on m.OrderID = o.OrderID left join FundsTrades f on f.MarketOrderID = m.MarketOrderID";
            SQL += " left outer join CalypsoInstruments cf on o.FundID = cf.ID left outer join Receipts r on o.OrderID = r.OrderID ";
            SQL += UISQLMakeWhereForOrders(item);
            SQL += " order by o.OrderID desc";
            var result = DB.UIOrderResults
            .FromSql(SQL)
            .AsNoTracking().ToList();
            return result;
        }

        /// <summary>
        /// Arma el where para hacer una query de get orders con los parametros requeridos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<OrderBondEquityOutput> GetOrders(OrderFundSearch item)
        {
            bool scheduled = false;
            if (item.Scheduled != null)
            {
                if (item.Scheduled == 0)
                    scheduled = false;
                if (item.Scheduled == 1)
                    scheduled = true;
            }
            int NotBackOffice = 1;
            if (item.NotBackOffice != null)
            {
                if ((bool)item.NotBackOffice)
                    NotBackOffice = 0;
                else
                    NotBackOffice = 1;
            }

            DateTime DateFrom = DateTime.Now.AddYears(10);
            if (item.DateFrom != null)
                DateFrom = (DateTime)item.DateFrom;

            DateTime DateTo = DateTime.Now.AddYears(-10);
            if (item.DateTo != null)
                DateTo = (DateTime)item.DateTo;

            using (var db = new DBContext())
            {
                IEnumerable<OrderBondEquityOutput> model = (from order in db.OrderFunds
                                                  join market in db.MarketOrders on order.OrderID equals market.OrderID into marketGroup
                                                  from m in marketGroup.DefaultIfEmpty()
                                                  join fund in db.FundsTrades on m.MarketOrderID equals fund.MarketOrderID into fundGroup
                                                  from f in fundGroup.DefaultIfEmpty()
                                                  join calypso in db.CalypsoInstruments on order.FundID equals calypso.Id.ToString() into CalypsoGroup
                                                  from c in CalypsoGroup.DefaultIfEmpty()
                                                  where
                                                   (
                                                    item.OrderList != null && item.OrderList.Any() && item.OrderList.Contains(order.OrderID)
                                                    && item.BrokerID == order.BrokerID
                                                    && (order.ChannelID == item.ChannelID || item.ChannelID == null)
                                                   )
                                                   ||
                                                   (
                                                    !(item.OrderList != null && item.OrderList.Any()) && (item.ExternalReferenceList != null && item.ExternalReferenceList.Any()) && item.ExternalReferenceList.Contains(order.ExternalReference)
                                                    && item.BrokerID == order.BrokerID
                                                    && (order.ChannelID == item.ChannelID || item.ChannelID == null)
                                                   )
                                                   ||
                                                   (
                                                      !(item.OrderList != null && item.OrderList.Any()) && !(item.ExternalReferenceList != null && item.ExternalReferenceList.Any()) &&
                                                      (order.BrokerID == item.BrokerID) &&
                                                      (order.ChannelID == item.ChannelID || item.ChannelID == null) &&
                                                      (order.ClientID == item.ClientID || item.ClientID == null) &&
                                                      (order.CustodyAccountNo == item.CustodyAccountNo || item.CustodyAccountNo == null) &&
                                                      ((order.OrderDateTime >= DateFrom.Date ) || item.DateFrom == null) &&
                                                      ((order.OrderDateTime <= DateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) || item.DateTo == null ) &&
                                                      (order.FundID == item.FundID || item.FundID == null) &&
                                                      (order.OperatorID == item.OperatorID || item.OperatorID == null) &&
                                                      (order.OrderID >= item.OrderIDFrom || item.OrderIDFrom == 0) &&
                                                      (order.OrderID <= item.OrderIDTo || item.OrderIDTo == 0) &&
                                                      (order.OrderNumber >= item.OrderNumberFrom || item.OrderNumberFrom == 0) &&
                                                      (order.OrderNumber <= item.OrderNumberTo || item.OrderNumberTo == 0) &&
                                                      (order.Amount >= item.AmountFrom || item.AmountFrom == 0) &&
                                                      (order.Amount <= item.AmountTo || item.AmountTo == 0) &&
                                                      (order.ProductType == item.ProductType || item.ProductType == null) &&
                                                      (order.CustodyAccountNo == item.CustodyAccountNo || item.CustodyAccountNo == null) &&
                                                      ((order.OrderType == item.OrderType && item.OrderType != "T") || item.OrderType == null) &&
                                                      (order.Scheduled == scheduled || item.Scheduled == 99 || item.Scheduled == null) &&
                                                      (item.Status == null || item.Status.Contains(order.Status)) &&
                                                      (f.BackOfficeTradeID == NotBackOffice || item.NotBackOffice == null || NotBackOffice == 1) &&
                                                      (order.ExternalReference >= item.ExternalReferenceFrom || item.ExternalReferenceFrom == 0) &&
                                                      (order.ExternalReference <= item.ExternalReferenceTo || item.ExternalReferenceTo == 0) &&
                                                      (f.BackOfficeTradeID >= item.BOTradeIDFrom || item.BOTradeIDFrom == 0) &&
                                                      (f.BackOfficeTradeID <= item.BOTradeIDTo || item.BOTradeIDTo == 0) &&
                                                      (order.OnlyMigration == 0) &&
                                                      (c.DenominacionDelFondo == item.FundParentName || item.FundParentName == null)
                                                  )
                                                  select new OrderBondEquityOutput
                                                  {
                                                      ID = order.OrderID,
                                                      OrderNumber = order.OrderNumber ?? 0,
                                                      OrderType = order.OrderType,
                                                      Action = order.Action,
                                                      Amount = order.Amount,
                                                      BrokerID = order.BrokerID,
                                                      ChannelID = order.ChannelID,
                                                      ClientID = order.ClientID,
                                                      Comments = order.Comments,
                                                      Currency = order.Currency,
                                                      CustodyAccountNo = order.CustodyAccountNo,
                                                      ExecutionDate = order.ExecutionDate,
                                                      LastUpdate = order.LastUpdate,
                                                      OrderDateTime = order.OrderDateTime,
                                                      Shares = (decimal)order.Shares,
                                                      FundID = order.FundID,
                                                      LinkOrderID = order.LinkOrderID,
                                                      OperationsStockTicket = order.OperationsStockTicket,
                                                      OperatorID = order.OperatorID,
                                                      OrderID = order.OrderID,
                                                      Prenote = order.Prenote,
                                                      ExchangeRate = order.ExchangeRate,
                                                      ProductType = order.ProductType,
                                                      RescueType = order.RescueType,
                                                      Scheduled = order.Scheduled,
                                                      Status = order.Status,
                                                      MarketOrderID = m.MarketOrderID,
                                                      BackOfficeTradeID = f.BackOfficeTradeID,
                                                      ExternalReference = order.ExternalReference,
                                                      FundDescription = c.Denominacion,
                                                      TypeTransfer = (int)order.TypeTransfer,
                                                      InstrumentCode = c.CodigoEspecie,
                                                      SettleTerm = c.PlazoRescate,
                                                      Settlements = (from r in db.Settlements where r.OrderID == order.OrderID select r).ToList(),
                                                      Receipts = (from r in db.Receipts where r.OrderID == order.OrderID select new ReceiptResult { ReceiptID = r.ReceiptID, Link = r.Link, ReceiptType = r.ReceiptType, StorageID = r.StorageID }).ToList()
                                                  }
                         ).ToList();
                return model.ToList();
            }
        }

        

        public static List<UIChartOrdenesPorEstadoResult> UIPostProportionOrdersByStatus(ChartOrdenesSearch item)
        {

            using (var db = new DBContext())
            {
                  return (from o in db.Orders
                         join b in db.Brokers on o.BrokerID equals b.BrokerID
                         where (o.OrderDateTime > DateTime.Today)
                         group o by o.Status into gcs
                         orderby gcs.Count() ascending
                         select new UIChartOrdenesPorEstadoResult
                         {
                             Status = getStatus(gcs.Key, gcs.Count()),
                             Count = gcs.Count(),                           

                         }).ToList();
                
            }
            
        }

        public static List<UIChartOrdenesPorBrokerResult> UIGetBroker(ChartOrdenesSearch item)
        {

            using (var db = new DBContext())
            {

                return  (from o in db.Orders
                        join b in db.Brokers on o.BrokerID equals b.BrokerID
                        where (o.OrderDateTime > DateTime.Today)
                        group o by o.BrokerID into g
                        orderby g.Count() ascending
                        select new UIChartOrdenesPorBrokerResult
                        {
                            Status = getBroker(g.Key, g.Count()),
                            Count = g.Count(),

                        }).ToList();
            }
        }

        public static List<UIChartOrdenesDateTimeResult> UIGetOrderDatetime(ChartOrdenesSearch item)
        {

            using (var db = new DBContext())
            {

                return  (from order in db.Orders
                         where (order.OrderDateTime.Date.ToString() == DateTime.Today.ToString())
                         group order by order.OrderDateTime.Hour.ToString() into g
                         orderby g.Key ascending 
                         select new UIChartOrdenesDateTimeResult
                         {
                             Hora = g.Key,
                             Count = g.Count()

                         }).ToList();
            }
        }

        public static List<UIChartOrdenesDateTimeResult> UIGetOrderByMonth(ChartOrdenesSearch item)
        {

                using (var db = new DBContext())
                {
                
                    return  (from order in db.Orders
                            where (order.OrderDateTime.Date >= DateTime.Today.AddDays(-30))
                            group order by order.OrderDateTime.Date into c
                            orderby getDateMonth(c.FirstOrDefault().OrderDateTime), getDateDay(c.FirstOrDefault().OrderDateTime) ascending
                            select new UIChartOrdenesDateTimeResult
                            {

                                 OrderDateTime = c.FirstOrDefault().OrderDateTime.Date,
                                 Count = c.Count(),
                                 Mes = getDateMonth(c.FirstOrDefault().OrderDateTime),
                                 Dia = getDateDay(c.FirstOrDefault().OrderDateTime)

                            }).ToList();
                }
        }

        public static string UISQLMakeWhereForOrders(OrderFundSearch item)
        {
            string temp = "";
            string sqlWhere = "";


            if (!(item.BrokerID == null || item.BrokerID.Trim() == ""))
            {
                temp = " o.BrokerID ='" + item.BrokerID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.ChannelID == null || item.ChannelID.Trim() == ""))
            {
                temp = " o.channelID ='" + item.ChannelID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.Status == null || item.Status.Trim() == ""))
            {
                temp = " o.Status ='" + item.Status + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.ClientID == null || item.ClientID.Trim() == ""))
            {
                temp = " o.clientID  = '" + item.ClientID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.CustodyAccountNo == null || item.CustodyAccountNo.Trim() == ""))
            {
                temp = " o.CustodyAccountNo  = '" + item.CustodyAccountNo + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.DateFrom != null)
            {
                temp = "o.OrderDateTime  >= '" + getDateFormatSqlServerFrom(item.DateFrom) + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.DateTo != null)
            {
                temp = "o.OrderDateTime  < '" + getDateFormatSqlServerTo(item.DateTo) + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.FundID == null || item.FundID == "" || item.FundID == " "))
            {
                temp = "o.fundID = '" + item.FundID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.Comments == null || item.Comments == "" || item.Comments == " "))
            {
                temp = "o.Comments like '%" + item.Comments + "%'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.OperatorID == null || item.OperatorID.Trim() == ""))
            {
                temp = "o.operatorID = '" + item.OperatorID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.OrderIDFrom > 0)
            {
                temp = "o.orderID >= " + item.OrderIDFrom;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.AmountFrom > 0)
            {
                temp = "o.amount >= " + item.AmountFrom;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.AmountTo > 0)
            {
                temp = "o.Amount <= " + item.AmountTo;

                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.OrderIDTo > 0)
            {
                temp = "o.orderID <= " + item.OrderIDTo;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.ProductType == null || item.ProductType.Trim() == ""))
            {
                temp = "o.productType = '" + item.ProductType + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.CustodyAccountNo == null || item.CustodyAccountNo == "" || item.CustodyAccountNo == " "))
            {
                temp = "o.custodyAccountNo = '" + item.CustodyAccountNo + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.OrderType == null || item.OrderType.Trim() == "" || item.OrderType == "T"))
            {
                temp = "o.orderType = '" + item.OrderType + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.Scheduled == null || item.Scheduled == 99))
            {
                temp = "o.Scheduled = " + item.Scheduled;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.NotBackOffice == true)
            {
                temp = "ISNULL(f.BackOfficeTradeID,0) = 0";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.ExternalReferenceFrom > 0)
            {
                temp = " o.ExternalReference  = " + item.ExternalReferenceFrom;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.ExternalReferenceTo > 0)
            {
                temp = " o.ExternalReference  = " + item.ExternalReferenceTo;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.BOTradeIDFrom > 0)
            {
                temp = " f.BackOfficeTradeID  >= " + item.BOTradeIDFrom;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.BOTradeIDTo > 0)
            {
                temp = " f.BackOfficeTradeID  <= " + item.BOTradeIDTo;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.InstructionID != null && item.InstructionID > 0)
            {
                temp = "o.InstructionID = " + item.InstructionID;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            return sqlWhere;
        }

        static string getDateFormatSqlServerFrom(DateTime? _fecha)
        {
            if (_fecha == null)
                return null;

            DateTime fecha = (DateTime)_fecha;

            string day = "";
            string month = "";
            if (fecha.Day.ToString().Length < 2)
                day = "0" + fecha.Day.ToString();
            else
                day = fecha.Day.ToString();

            if (fecha.Month.ToString().Length < 2)
                month = "0" + fecha.Month.ToString();
            else
                month = fecha.Month.ToString();

            return fecha.Year.ToString() + month + day;

        }

        static string getDateFormatSqlServerTo(DateTime? _fecha)
        {
            if (_fecha == null)
                return null;

            DateTime fecha = (DateTime)_fecha;
            fecha = fecha.AddDays(1);
            string day = "";
            string month = "";

            if (fecha.Day.ToString().Length < 2)
                day = "0" + fecha.Day.ToString();
            else
                day = fecha.Day.ToString();

            if (fecha.Month.ToString().Length < 2)
                month = "0" + fecha.Month.ToString();
            else
                month = fecha.Month.ToString();


            return fecha.Year.ToString() + month + day;
          

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_InstructionTrackingID"></param>
        /// <returns></returns>
        public static List<InstructionTracking> GetTrackingInstructionsByID(int _InstructionTrackingID)
        {

            string SQL;
            SQL = "SELECT InstructionTrackingID";
            SQL += ",Component";
            SQL += ",Event";
            SQL += ",EventInfo";
            SQL += ",InstructionID";
            SQL += ",MarketInstructionID";
            SQL += ",MarketTradeID";
            SQL += ",[When]";
            SQL += "FROM InstructionsTracking WHERE InstructionID = " + Convert.ToString(_InstructionTrackingID);
            using (var db = new DBContext())
            {
                var result = db.InstructionsTracking
               .FromSql(SQL)
               .AsNoTracking().ToList();
                return result;
            }

        }
        /// <summary>
        /// Arma el where para hacer una query de get orders con los parametros requeridos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SQLMakeWhereForUIInstructions(UIInstructionSearch item)
        {
            string temp = "";
            string sqlWhere = "";

            //if (item.brokerID > 0)
            //{
            //    sqlWhere += " WHERE i.brokerID = " + item.brokerID;
            //}


            if (!(item.brokerID == null || item.brokerID == "" || item.brokerID == " "))
            {
                temp = " i.brokerID ='" + item.brokerID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.channelID == null || item.channelID == "" || item.channelID == " "))
            {
                temp = " i.channelID ='" + item.channelID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.ClientID == null || item.ClientID == "" || item.ClientID == " "))
            {
                temp = " i.clientID  = '" + item.ClientID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.discriminator == null || item.discriminator == "Todas"))
            {
                temp = " i.Discriminator  = '" + item.discriminator + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }


            if (!(item.CustodyAccountNo == null || item.CustodyAccountNo == "" || item.CustodyAccountNo == " "))
            {
                temp = " i.CustodyAccountNo  = '" + item.CustodyAccountNo + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }


            if (item.DateFrom != null)
            {
                temp = "i.InstructionDateTime  >= '" + getDateFormatSqlServerFrom(item.DateFrom) + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
 

            if (item.DateTo != null)
            {
                temp = "i.InstructionDateTime  < '" + getDateFormatSqlServerTo(item.DateTo) + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.status == null || item.status == "" || item.status == " "))
            {
                temp = "i.status = '" + item.status + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.operatorID == null || item.operatorID == "" || item.operatorID == " "))
            {
                temp = "i.operatorID = '" + item.operatorID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (item.orderID > 0)
            {
                temp = "i.orderID = " + item.orderID;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.InstruccionIDFrom > 0)
            {
                temp = "i.InstructionID = " + item.InstruccionIDFrom;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }


            if (!(item.CustodyAccountNo == null || item.CustodyAccountNo == "" || item.CustodyAccountNo == " "))
            {
                temp = "i.custodyAccountNo = '" + item.CustodyAccountNo + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            return sqlWhere;
        }

        /// <summary>
        /// Arma el where para hacer una query de get orders con los parametros requeridos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SQLMakeWhereForInstructions(InstructionSearch item)
        {
            string temp = "";
            string sqlWhere = "";

            if (item.brokerID.Length > 0)
            {
                sqlWhere += " WHERE i.brokerID = " + item.brokerID;
            }

            if (!(item.channelID == null || item.channelID == "" || item.channelID == " "))
            {
                temp = " i.channelID ='" + item.channelID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.ClientID == null || item.ClientID == "" || item.ClientID == " "))
            {
                temp = " i.clientID  = '" + item.ClientID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.discriminator == null || item.discriminator == "Todas"))
            {
                temp = " i.Discriminator  = '" + item.discriminator + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.CustodyAccountNo == null || item.CustodyAccountNo == "" || item.CustodyAccountNo == " "))
            {
                temp = " i.CustodyAccountNo  = '" + item.CustodyAccountNo + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (item.DateFrom != null)
            {
                temp = "i.InstructionDateTime  >= '" + getDateFormatSqlServerFrom(item.DateFrom) + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (item.DateTo != null)
            {
                temp = "i.InstructionDateTime  < '" + getDateFormatSqlServerTo(item.DateTo) + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (!(item.status == null || item.status == "" || item.status == " "))
            {
                temp = "i.status = '" + item.status + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (!(item.operatorID == null || item.operatorID == "" || item.operatorID == " "))
            {
                temp = "i.operatorID = '" + item.operatorID + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }

            if (item.orderID > 0)
            {
                temp = "i.orderID = " + item.orderID;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            if (item.InstruccionIDFrom > 0)
            {
                temp = "i.InstructionID = " + item.InstruccionIDFrom;
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }


            if (!(item.CustodyAccountNo == null || item.CustodyAccountNo == "" || item.CustodyAccountNo == " "))
            {
                temp = "i.custodyAccountNo = '" + item.CustodyAccountNo + "'";
                if (sqlWhere == "")
                {
                    sqlWhere += " WHERE " + temp;
                }
                else
                {
                    sqlWhere += " AND " + temp;
                }
            }
            return sqlWhere;
        }

        /// <summary>
        /// Trae las instrucciones por filtro
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<InstructionResult> GetInstructionsByFilters(InstructionSearch item)
        {
            using (var db = new DBContext())
            {
                var model = db.InstructionFundsPromoteClasses.Join(db.CalypsoInstruments, instruction => instruction.TargetFundID, calypsoInstruments => calypsoInstruments.Id,
                                  (instruction, calypsoInstruments) => new { Instruction = instruction, CalypsoInstruments = calypsoInstruments }).
                                   Where(instruction => (item.brokerID.Length > 0 ? instruction.Instruction.BrokerID == item.brokerID : true) &&
                                  ((item.channelID != null && item.channelID.Trim() != "") ? instruction.Instruction.ChannelID == item.channelID : true) &&
                                  ((item.ClientID != null && item.ClientID.Trim() != "") ? instruction.Instruction.ClientID == item.ClientID : true) &&
                                  // (item.discriminator != null && item.discriminator != "Todas") ? instruction.Instruction.Discriminator == item.discriminator : true &&
                                  ((item.CustodyAccountNo != null && item.CustodyAccountNo.Trim() != "") ? instruction.Instruction.CustodyAccountNo == item.CustodyAccountNo : true) &&
                                  ((item.DateFrom != null) ? instruction.Instruction.InstructionDateTime >= item.DateFrom : true) &&
                                  ((item.DateTo != null) ? instruction.Instruction.InstructionDateTime <= item.DateTo : true) &&
                                  ((item.status != null && item.status.Trim() != "") ? instruction.Instruction.Status == item.status : true) &&
                                  ((item.operatorID != null && item.operatorID.Trim() != "") ? instruction.Instruction.OperatorID == item.operatorID : true) &&
                                   // (item.orderID > 0) ? instruction.Instruction.OrderID == item.orderID : true &&
                                  ((item.InstructionNumber != null && item.InstructionNumber > 0) ? instruction.Instruction.InstructionNumber == item.InstructionNumber : true) &&
                                  ((item.InstruccionIDFrom != null && item.InstruccionIDFrom > 0) ? instruction.Instruction.InstructionID >= item.InstruccionIDFrom : true) &&
                                  ((item.InstruccionIDTo != null && item.InstruccionIDTo > 0) ? instruction.Instruction.InstructionID <= item.InstruccionIDTo : true) &&
                                  ((item.FundParentName != null && item.FundParentName.Trim() != "") ? instruction.CalypsoInstruments.DenominacionDelFondo == item.FundParentName : true)).
                                  Select(instruction => new InstructionResult
                                  {
                                      InstructionID = instruction.Instruction.InstructionID,
                                      BrokerID = instruction.Instruction.BrokerID,
                                      ChannelID = instruction.Instruction.ChannelID,
                                      ClientID = instruction.Instruction.ClientID,
                                      Comments = instruction.Instruction.Comments,
                                      // Discriminator = instruction.Instruction.Discriminator,
                                      InstructionDateTime = instruction.Instruction.InstructionDateTime,
                                      InstructionExecutionDateTime = instruction.Instruction.InstructionExecutionDateTime,
                                      LastUpdate = instruction.Instruction.LastUpdate,
                                      OperatorID = instruction.Instruction.OperatorID,
                                      OrdersCount = instruction.Instruction.OrdersCount,
                                      ParentInstructionID = instruction.Instruction.ParentInstructionID,
                                      Scheduled = instruction.Instruction.Scheduled,
                                      Status = instruction.Instruction.Status,
                                      //  OrderID = instruction.Instruction.OrderID,
                                      CustodyAccountNo = instruction.Instruction.CustodyAccountNo,
                                      TargetFundID = instruction.Instruction.TargetFundID,
                                      TargetFundParentName = item.FundParentName
                                  }).ToList();

                return model;
            }
        }

        /// <summary>
        /// Trae las instrucciones por filtro
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<UIInstructionResult> UIGetInstructionsByFilters(UIInstructionSearch item)
        {
            var DB = new DBContext();
            string SQL = "select ";
            SQL += "InstructionID,";
            SQL += "BrokerID,";
            SQL += "channelID,";
            SQL += "clientID,";
            SQL += "Comments,";
            SQL += "Discriminator,";
            SQL += "InstructionDateTime,";
            SQL += "InstructionExecutionDateTime,";
            SQL += "LastUpdate,";
            SQL += "operatorID,";
            SQL += "OrdersCount,";
            SQL += "ParentInstructionID,";
            SQL += "InstructionFundsCancelOrder_OrderID,";
            SQL += "Scheduled,";
            //            SQL += "Status,";
            //            SQL += " case ";
            //            SQL += " when status = 'P' then 'Pendiente' ";
            //            SQL += " when status = 'E' then 'Error' ";
            //            SQL += " when status = 'C' then 'Cancelada' ";
            //            SQL += " else ' ' ";
            //            SQL += " end as Status, "; 
            SQL += "Status,";
            SQL += "OrderID,";
            SQL += "case ";
            SQL += " when CustodyAccountNo is not null then CustodyAccountNo ";
            SQL += " else OriginCustodyAccountNo ";
            SQL += " end as custodyAccountNo,";
            SQL += "targetCustodyAccountNo,";
            SQL += "TargetFundID,";
            SQL += "case ";
            SQL += " when discriminator = 'InstructionFundsCancelOrder' then '         Cancelación de la Solicitud Número :' + cast(InstructionFundsCancelOrder_OrderID as varchar) ";
            SQL += " when discriminator = 'InstructionFundsPromoteClass' then 'Promoción de Clase, ' +";
            SQL += " COALESCE( ( select top 1 cf.Denominacion ";
            SQL += " from  CalypsoInstruments cf where cf.id = i.TargetFundID ),' ') + ' por ' + COALESCE(cast(i.OriginShares as varchar), ' ') + ' cuotas partes'";
            SQL += " when Discriminator = 'InstructionFundsTransferFund' then 'Suscripcion de ' + ";
            SQL += " COALESCE((select top 1 cf.Denominacion  from CalypsoInstruments cf where cf.id = i.OriginFundID ),' ') +' por ' + ";
            SQL += " COALESCE(cast(i.OriginShares as varchar), ' ') + ' Cuotas Partes a ' + COALESCE((select top 1 cf.Denominacion  from CalypsoInstruments cf where cf.id = i.TargetFundID ),' ') ";
            SQL += " when discriminator = 'InstructionFundsPromoteClass' then 'Promoción de Clase, ' +";
            SQL += " COALESCE( ( select top 1 cf.Denominacion";
            SQL += " from  CalypsoInstruments cf where cf.id = i.TargetFundID ),' ') + ' por ' + COALESCE(cast(i.OriginShares as varchar), ' ') + ' cuotas partes'";
            SQL += " else ";
            SQL += " Discriminator";
            SQL += " end  as Descripcion_extendida,";
            SQL += "TypeTransfer";
            SQL += " from Instructions i";
            SQL += SQLMakeWhereForUIInstructions(item);
            SQL += " order by InstructionID desc";
            var result = DB.UIInstructionResults
           .FromSql(SQL)
           .AsNoTracking().ToList();
            return result;

        }

        public static ClientStatistics GetClientStatistics(OrderStatistics item)
        {

            bool? scheduled = null;
            if (item.Scheduled != null)
            {
                if (item.Scheduled.ToUpper() == "TRUE")
                    scheduled = true;
                if (item.Scheduled.ToUpper() == "FALSE")
                    scheduled = false;
            }
            using (var db = new DBContext())
            {
                IEnumerable<OrderFund> model = (from order in db.OrderFunds
                                        .Where(
                                                b => b.BrokerID == item.BrokerID
                                                && (b.ClientID == item.ClientID)
                                                && (b.ChannelID == item.ChannelID || item.ChannelID == null || item.ChannelID == "")
                                                && (b.OrderType == item.OrderType || item.OrderType == null || item.OrderType == "")
                                                && (b.FundID == item.FundID || item.FundID == null || item.FundID == "")
                                                && (b.Scheduled == scheduled || scheduled == null)
                                                && (b.Status == item.Status || item.Status == null || item.Status == "")
                                                && (b.OrderDateTime.Date >= item.DateFrom)
                                                && (b.OrderDateTime.Date <= item.DateTo || item.DateTo == null)
                                            )
                                                select new OrderFund
                                                {
                                                    OrderType = order.OrderType
                                                }
                         ).ToList();

                ClientStatistics clienteStatistics = new ClientStatistics()
                {
                    OrdersCount = model.Count(),
                    SuscriptionsCount = model.Where(b => b.OrderType.ToUpper() == "S").Count(),
                    RescuesCount = model.Where(b => b.OrderType.ToUpper() == "R").Count()
                };

                return clienteStatistics;
            }
        }
        public static List<OrderTracking> GetOrderTracking(int OrderID)
        {
            using (var db = new DBContext())
            {

                IEnumerable<OrderTracking> model = db.OrdersTracking.Where(
                                                b => b.OrderID == OrderID
                                                ).OrderBy(b => b.OrderTrackingID).ToList();
                return model.ToList();
            }
        }
        public static List<Broker> GetBrokers()
        {
            using (var db = new DBContext())
            {
                IEnumerable<Broker> model = db.Brokers.OrderBy(b => b.BrokerID).ToList();
                return model.ToList();
            }
        }
        public static Broker GetBrokerById(string BrokerID)
        {
            using (var db = new DBContext())
            {

                Broker model = db.Brokers.Where( b => b.BrokerID == BrokerID
                                                ).ToList().FirstOrDefault();
                return model;
            }
        }
        public static List<ErrorLog> GetErrorsByOrderID(int OrderID)
        {
            using (var db = new DBContext())
            {
                IEnumerable<ErrorLog> model = db.ErrorLogs.Where(x => x.OrderID == OrderID).OrderBy(x => x.ErrorLogID).ToList();
                return model.ToList();
            }
        }
        public static List<ErrorLog> GetErrorsByInstructionID(int InstructionID)
        {
            using (var db = new DBContext())
            {
                IEnumerable<ErrorLog> model = db.ErrorLogs.Where(x => x.InstructionID == InstructionID).OrderBy(x => x.ErrorLogID).ToList();
                return model.ToList();
            }
        }
        public static string GetUserProfiles()
        {
            string profileGroup = "";
            using (var db = new DBContext())
            {
                List<UserProfile> userProfiles = db.UserProfiles.ToList();
                foreach (UserProfile userProfile in userProfiles)
                {
                    if (profileGroup != "")
                        profileGroup += ",";
                    profileGroup += userProfile.ProfileGroup;
                }
            }
            return profileGroup;
        }

        public static List<OrderFund> GetProgrammerPendingOrders()
        {
            //   DateTime aa = DateTime.Now.AddMinutes(GlobalSettings.MinutesDelay);
            using (var db = new DBContext())
            {
                IEnumerable<OrderFund> model = (from order in db.OrderFunds
                                                 .Include(a => a.Settlements)
                                                    //  from marketOrder in order.MarketOrders.DefaultIfEmpty()
                                                where// marketOrder.OrderID == null                                                && 
                                                order.Scheduled == true
                                                && order.Status == "P"
                                                 && order.Prenote == null
                                                //  && order.ExecutionDate >= DateTime.Now.Date
                                                && ((DateTime)order.ExecutionDate).Date == DateTime.Now.Date
                                                //&& order.ExecutionDate.Month == DateTime.Now.Month
                                                //&& order.ExecutionDate.Year == DateTime.Now.Year
                                                && ((((DateTime)order.ExecutionDate).Hour <= DateTime.Now.Hour && ((DateTime)order.ExecutionDate).Minute <= DateTime.Now.Minute)
                                                 || ((DateTime)order.ExecutionDate).Hour < DateTime.Now.Hour)
                                                //   && order.ExecutionDate <= order.LastUpdate
                                                select order
                                                ).ToList();
                return model.ToList();
            }
        }

        public static List<OrderFund> GetPendingOrders()
        {
            //   DateTime aa = DateTime.Now.AddMinutes(GlobalSettings.MinutesDelay);
            using (var db = new DBContext())
            {
                IEnumerable<OrderFund> model = (from order in db.OrderFunds
                                                 .Include(a => a.Settlements)
                                                where
                                                (order.Status == "P" && order.Scheduled == false ) || 
                                                (order.Status == "P" && order.Scheduled == true && order.ExecutionDate <= DateTime.Now.Date)
                                                select order ).ToList();
                return model.ToList();
            }
        }

        public static OrderFund GetOrdersById(int OrderId)
        {
            using (var db = new DBContext())
            {
                OrderFund model = (from order in db.OrderFunds
                                                 .Include(a => a.Settlements)
                                                where order.OrderID == OrderId
                                                select order).FirstOrDefault();
                return model;
            }
        }

        public static List<ErrorLog> GetErrorLogs()
        {
            using (var db = new DBContext())
            {
                IEnumerable<ErrorLog> model = (from errorLog in db.ErrorLogs
                                               where
                                               (errorLog.When.Day == DateTime.Now.Day)
                                               select errorLog).ToList();
                return model.ToList();
            }
        }

        //obtengo los canales de BG_Canal

        public static UserAccess GetUserAccessByID(string userID)
        {
            using (var db = new DBContext())
            {
                UserAccess userAccess = db.UserAccesses.FirstOrDefault(t => t.UserID == userID);
                return (userAccess);
            }
        }

        public static Instruction GetInstructionFromInstructionID(int InstructionID)
        {
            using (var db = new DBContext())
            {
                Instruction instruction = db.Instructions
                                        .Include(a => a.Orders)
                                     .Where(a => a.InstructionID == InstructionID)
                                     .FirstOrDefault();
                return instruction;
            }
        }
        public static FeeSettlementFund GetFeeSettlementFundFromFeeSettlementID(int FeeSettlementID)
        {
            using (var db = new DBContext())
            {
                FeeSettlementFund feeSettlement = db.FeeSettlementFund
                                     .Where(a => a.FeeSettlementID == FeeSettlementID)
                                     .FirstOrDefault();
                return feeSettlement;
            }
        }
        public static MarketInstruction GetMarketInstructionFromMarketInstructionID(int MarketInstructionID)
        {
            using (var db = new DBContext())
            {
                MarketInstruction marketInstruction = db.MarketInstructions
                                     //   .Include(a => a.Broker)
                                     .Where(a => a.MarketInstructionID == MarketInstructionID)
                                     .FirstOrDefault();
                return marketInstruction;
            }
        }
        public static FundsTrade GetFundTradeFromOrderID(int orderID)
        {
            using (var db = new DBContext())
            {
                var fundsTrade = (from marketOrders in db.MarketOrders
                                  join funds in db.FundsTrades on marketOrders.MarketOrderID equals funds.MarketOrderID
                                  where marketOrders.OrderID == orderID
                                  select funds
                                 ).FirstOrDefault();
                return fundsTrade;
            }
        }

        public static FundsTrade GetFundTradeFromBackOfficeTradeID(long boTradeID)
        {
            using (var db = new DBContext())
            {
                var fundsTrade = (from fundsTrades in db.FundsTrades
                                  where fundsTrades.BackOfficeTradeID == boTradeID
                                  select fundsTrades
                                 ).FirstOrDefault();
                return fundsTrade;
            }
        }

        public static InstructionFundsCancelOrder GetInstructionCancelFromOrderID(int OrderID)
        {
            using (var db = new DBContext())
            {
                InstructionFundsCancelOrder instruction = db.InstructionFundsCancelOrders
                                     //   .Include(a => a.Broker)
                                     .Where(a => a.OrderID == OrderID && (a.Status == "P" || a.Status == "C"))
                                     .FirstOrDefault();
                return instruction;
            }
        }
        public static InstructionFundsPromoteClass GetInstructionByID(int ID)
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstructionFundsPromoteClasses// .Include(a => a.Orders)
                        where data.InstructionID == ID
                        select data).FirstOrDefault();
            }
        }

        public static Instruction GetInstructionGenericByID(int ID)
        {
            using (var db = new DBContext())
            {
                var x = (from data in db.Instructions
                        where data.InstructionID == ID
                        select data).FirstOrDefault();

                return x;
            }
        }

        public static List<InstructionFundsPromoteClass> GetAllInstruction()
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstructionFundsPromoteClasses select data).ToList();
            }
        }
        public static List<UIChannel> UIGetChannels()
        {
            using (var db = new DBContext())
            {
                return (from c in db.Mappings
                        where c.ExternalField == "BG_Canal"
                        select new UIChannel { localvalue = c.LocalValue, externalvalue = c.ExternalValue }
                ).ToList();
            }
        }

        public static int GetInstructionCountOKFromTargetFunds(int TargetFundsID)
        {
            using (var db = new DBContext())
            {
                int cant = db.InstructionFundsPromoteClasses
                            .Where(a => a.TargetFundID == TargetFundsID && a.Status == "C")
                            .Count();
                return cant;
            }
        }

        public static Parameter GetParameterValue(string name)
        {
            using (var db = new DBContext())
            {
                var res = db.Parameters.Where(a => a.Name == name).FirstOrDefault();
                return res;
            }
        }

        public static InstructionFundsAmendOrder GetInstructionAmendFromOrderID(int OrderID)
        {
            using (var db = new DBContext())
            {
                InstructionFundsAmendOrder instruction = db.InstructionFundsAmendOrders
                                     .Where(a => a.OrderID == OrderID && a.Status == "P")
                                     .FirstOrDefault();
                return instruction;
            }
        }
        public static int GetInstructionIDFromToday(OrderFund orderfun)
        {
            using (var db = new DBContext())
            {
                OrderFund model = (from order in db.OrderFunds
                                   join intruction in db.InstructionFundsPromoteClasses on order.InstructionID equals intruction.InstructionID
                                   where
                                   order.CustodyAccountNo == orderfun.CustodyAccountNo
                                   && order.FundID == orderfun.FundID
                                   && (order.Status == "C" || order.Status == "P")
                                   && order.LastUpdate.Day == DateTime.Now.Day
                                   && order.LastUpdate.Month == DateTime.Now.Month
                                   && order.LastUpdate.Year == DateTime.Now.Year
                                   select new OrderFund
                                   {
                                       InstructionID = order.InstructionID
                                   }).OrderBy(x => x.InstructionID).LastOrDefault();

                return (model == null) ? 0 : (int)model.InstructionID;
            }
        }



        public static int GetOrderIDByExternalReference(OrderFund item)
        {
            using (var db = new DBContext())
            {
                OrderFund order = db.OrderFunds
                                     .Where(a => a.BrokerID == item.BrokerID && a.ChannelID == item.ChannelID && a.ExternalReference == item.ExternalReference)
                                     .FirstOrDefault();
                return (order == null) ? 0 : (int)order.OrderID;
            }
        }

        public static List<InstructionFundsCancelOrder> GetMissingInstructionCancel()
        {
            using (var db = new DBContext())
            {
                List<InstructionFundsCancelOrder> instruction = db.InstructionFundsCancelOrders
                                      //   .Include(a => a.Broker)
                                      .Where(a => a.Status == "P" && a.LastUpdate < DateTime.Now.AddMinutes(-GlobalSettings.MinutesDelay))
                                      .ToList();
                return instruction;
            }
        }
        public static int GetNextSequenceValue()
        {
            using (var db = new DBContext())
            {
                return db.GetNextSequenceValue();
            }
        }
        public static List<CalypsoInstrumentEntity> GetCalypsoInstrumentsWithSameParentFund(int FundID)
        {
            using (var db = new DBContext())
            {
                IEnumerable<CalypsoInstrumentEntity> model = db.CalypsoInstruments
                                .Where(calypso => db.CalypsoInstruments.Where(dh => dh.Id == FundID)
                                .Select(dh => dh.DenominacionDelFondo)
                                .Contains(calypso.DenominacionDelFondo))
                                .Select(calypso => new CalypsoInstrumentEntity
                                {
                                    denominacionDelFondo = calypso.DenominacionDelFondo,
                                    Id = calypso.Id,
                                    clase = calypso.Clase
                                }).ToList();

                return model.ToList();
            }
        }

        public static ErrorLog ErrorExisted(ErrorLog error)
        {
            ErrorLog oErrorLog = null;

            using (var db = new DBContext())
            {
                oErrorLog = db.ErrorLogs
                                .Where(a => a.ComponentSource == error.ComponentSource
                                && a.ErrorMessage == error.ErrorMessage
                                && a.ErrorType == error.ErrorType
                                && a.ErrorCode == error.ErrorCode
                                && a.ErrorExceptionMessage == error.ErrorExceptionMessage
                                && a.ComponentTarget == error.ComponentTarget
                                && a.MarketOrderID == error.MarketOrderID
                                && a.MarketTradeID == error.MarketTradeID
                                && a.OrderID == error.OrderID
                                && a.InstructionID == error.InstructionID
                                && a.ProcedureName == error.ProcedureName
                                && a.When.Year == error.When.Year
                                && a.When.Month == error.When.Month
                                && a.When.Day == error.When.Day).FirstOrDefault();

                return oErrorLog;
            }
        }

        public static DateTime ResetTimeToStartOfDay(this DateTime dateTime)
        {
            return new DateTime(
               dateTime.Year,
               dateTime.Month,
               dateTime.Day,
               0, 0, 0, 0);
        }

        public static DateTime ResetTimeToEndOfDay(this DateTime dateTime)
        {
            return new DateTime(
               dateTime.Year,
               dateTime.Month,
               dateTime.Day,
               23, 59, 59, 999);
        }
        public static List<OrderToReceipt> GetOrderToReceipt()
        {
            using (var db = new DBContext())
            {
                IEnumerable<OrderToReceipt> model = (from ordertoReceive in db.OrderToReceipts
                                                     .Include(a => a.Order)
                                                     .Include(a => a.Order.Settlements)
                                                     join order in db.Orders on ordertoReceive.OrderID equals order.OrderID
                                                     join receipt in db.Receipts on order.OrderID equals receipt.OrderID into receiptGroup
                                                     from m in receiptGroup.DefaultIfEmpty().Where(rec => rec == null)
                                                     select ordertoReceive
                                                    ).ToList();
                return model.ToList();
            }
        }
        public static List<InstructionToReceipt> GetInstructionToReceipt()
        {
            using (var db = new DBContext())
            {
                IEnumerable<InstructionToReceipt> model = (from instructionToReceive in db.InstructionToReceipts
                                                     .Include(a => a.Instruction)
                                                     .Include(a => a.Instruction.Orders)
                                                     join instruction in db.Instructions on instructionToReceive.InstructionID equals instruction.InstructionID
                                                     join receipt in db.Receipts on instruction.InstructionID equals receipt.InstructionID into receiptGroup
                                                     from m in receiptGroup.DefaultIfEmpty().Where(rec => rec == null)
                                                     select instructionToReceive
                                                    ).ToList();
                return model.ToList();
            }
        }
        /// <summary>
        /// Arma el where para hacer una query de get FeeSettlementFunds con los parametros requeridos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<FeeSettlementFund> GetFeeSettlementFund(FeeSettlementsSearch item)
        {
            DateTime DateFrom = DateTime.Now.AddYears(10);
            if (item.DateFrom != null)
                DateFrom = (DateTime)item.DateFrom;

            DateTime DateTo = DateTime.Now.AddYears(-10);
            if (item.DateTo != null)
                DateTo = (DateTime)item.DateTo;

            using (var db = new DBContext())
            {
                IEnumerable<FeeSettlementFund> model = (from feeSettlementFund in db.FeeSettlementFund.Include(a => a.FeeSettlementErrorLog)
                                                   where
                                                   (
                                                    item.ExternalReference != null && item.ExternalReference.Any() && item.ExternalReference.Contains(feeSettlementFund.ExternalReference)
                                                   )
                                                   ||
                                                   (
                                                    !(item.ExternalReference != null && item.ExternalReference.Any()) && (item.FeeSettlementIDs != null && item.FeeSettlementIDs.Any()) && item.FeeSettlementIDs.Contains(feeSettlementFund.FeeSettlementID)
                                                   )
                                                   ||
                                                   (
                                                      !(item.ExternalReference != null && item.ExternalReference.Any()) && !(item.FeeSettlementIDs != null && item.FeeSettlementIDs.Any()) &&
                                                      (feeSettlementFund.BrokerID == item.BrokerID || item.BrokerID == null) &&
                                                      (feeSettlementFund.TradeCounterParty == item.TradeCounterParty || item.TradeCounterParty == null) &&
                                                      (feeSettlementFund.TradeBook == item.TradeBook || item.TradeBook == null) &&
                                                      (feeSettlementFund.FundID == item.FundID || item.FundID == 0) &&
                                                      (
                                                        (feeSettlementFund.FeeSettlementDate.Day >= DateFrom.Day && feeSettlementFund.FeeSettlementDate.Month >= DateFrom.Month && feeSettlementFund.FeeSettlementDate.Year >= DateFrom.Year)
                                                        || item.DateFrom == null) &&
                                                      (
                                                        (feeSettlementFund.FeeSettlementDate.Day <= DateTo.Day && feeSettlementFund.FeeSettlementDate.Month <= DateTo.Month && feeSettlementFund.FeeSettlementDate.Year <= DateTo.Year)
                                                        || item.DateTo == null) &&
                                                      (feeSettlementFund.Status == item.Status || item.Status == null) &&
                                                      (feeSettlementFund.CustodyBrokerID == item.CustodyBrokerID || item.CustodyBrokerID == null)
                                                   )
                                                   select feeSettlementFund ).ToList();
                return model.ToList();
            }
        }

        static string getDateMonth(DateTime? _fecha)
        {
            if (_fecha == null)
                return null;

            DateTime fecha = (DateTime)_fecha;
            string month = "";

            if (fecha.Month.ToString().Length < 2)
                month = "0" + fecha.Month.ToString();
            else
                month = fecha.Month.ToString();

            return month.ToString();

        }

        static string getDateDay(DateTime? _fecha)
        {
            if (_fecha == null)
                return null;

            DateTime fecha = (DateTime)_fecha;
            string day = "";

            if (fecha.Day.ToString().Length < 2)
                day = "0" + fecha.Day.ToString();
            else
                day = fecha.Day.ToString();

            return day.ToString();
        }

        static string getStatus(string status, int count)
        {
            if (status == null)
                return null;

            if (status == "E")
                status = "Error: " + count;
            if (status == "C")
                status = "Completado: " + count;
            if (status == "P")
                status = "Pendiente: " + count;
            if (status == "A")
                status = "Anulado: " + count;

            return status;
        }

        static string getBroker(string nameBroker, int count)
        {
            if (nameBroker == null)
                return null;

            string description = "Broker: ";

            return description + nameBroker + ", Cantidad: " + count;
        }

        public static OrderBondEquity GetOrderBondEquityFromOrderID(int ID)
        {
            using (var db = new DBContext())
            {
                var bymaOrder = (from OrderBondEquity in db.OrderBondEquities
                                 where OrderBondEquity.OrderID == ID
                                 select OrderBondEquity
                                  ).FirstOrDefault();
                return bymaOrder;
            }
        }

        public static string GetOrderTypeFromID(int ID)
        {
            using (var db = new DBContext())
            {
                string discriminator = (from Orders in db.Orders
                                 where Orders.OrderID == ID
                                 select Orders.Discriminator
                                  ).FirstOrDefault();
                return discriminator;
            }
        }


        public static BymaOrder GetBymaOrderFromID(int ID)
        {
            using (var db = new DBContext())
            {
                var bymaOrder = (from BymaOrder in db.BymaOrders
                                 where BymaOrder.BymaOrderID == ID
                                 select BymaOrder
                                  ).FirstOrDefault();
                return bymaOrder;
            }
        }

        public static BymaOrder GetBymaOrderFromClOrdID(string ClOrdID)
        {
            using (var db = new DBContext())
            {
                var bymaOrder = (from BymaOrder in db.BymaOrders
                                 where BymaOrder.ClOrdID == ClOrdID
                                 select BymaOrder
                                  ).FirstOrDefault();
                return bymaOrder;
            }
        }

        public static BymaOrderCancellation GetBymaOrderCancellationFromID(int ID)
        {
            using (var db = new DBContext())
            {
                var bymaOrderCancellation = (from BymaOrderCancellation in db.BymaOrderCancellations
                                 where BymaOrderCancellation.BymaOrderID == ID
                                 select BymaOrderCancellation
                                  ).FirstOrDefault();
                return bymaOrderCancellation;
            }
        }

        public static int GetMarketSequence()
        {
            using (var db = new DBContext())
            {
                return db.GetMarketSequence();
            }
        }
        public static Instrument GetInstrumentById(int id)
        {
            using (var db = new DBContext())
            {
                var instrument = (from instruments in db.Instruments
                                 where instruments.IdEspecie == id
                                 select instruments
                                  ).FirstOrDefault();
                return instrument;
            }
        }
    }
}