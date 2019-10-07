using Entity;
//using INOM.MarketByma;
using LQ.Support;
using LQ.Support.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LQ.PrimaryAPI.Models
{
    public static class Primary
    {
        public static CommWebApi.ResponseObject NewOrder(int MarketOrderID)
        {
            OrderBondEquity orderBondEquity = null;
            CommWebApi.ResponseObject item;
            try
            {
                orderBondEquity = Retrieve.GetOrderBondEquityFromMarketOrderID(MarketOrderID);
                //TRACKING
                OrderTracking.SaveTracking(orderBondEquity.OrderID, MarketOrderID);

                //MAPPING
                BymaOrder bymaOrder = Service.mapper.Map<OrderBondEquity, BymaOrder>(orderBondEquity);
                bymaOrder.MarketOrderID = MarketOrderID;

                //VALIDATION
                //item = ValidateInstrumentOrder(orderBondEquity.OrderID, bymaOrder, out InstrumentByma instrumentByma);
                item = ValidateFAKEInstrumentOrder(orderBondEquity.OrderID, bymaOrder, out InstrumentByma instrumentByma);
                
                if (item == null)
                {
                    bymaOrder.SecurityExchange = instrumentByma.SecurityExchange;
                    bymaOrder.SecurityType = instrumentByma.SecurityType;
                    bymaOrder.CFICode = instrumentByma.CFICode;
                    bymaOrder.ClOrdID = "BGBAN" + bymaOrder.MarketOrderID.ToString().PadLeft(14, '0');
                    bymaOrder.CommStatus = "P";
                    //SAVE BYMA ORDER 
                    BymaOrder.Save(bymaOrder);
                    try
                    {
                        //SEND BYMA ORDER
                        Service.QuickFixApp.NewOrderSingle(bymaOrder);

                        //UPDATE CommStatus
                        bymaOrder.CommStatus = "S"; //SEND
                        BymaOrder.Update(bymaOrder);

                    }
                    catch (Exception ex)
                    {
                        bymaOrder.CommStatus = "E"; //ERROR
                        BymaOrder.Update(bymaOrder);

                        item = Error(orderBondEquity.OrderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS9999,null,ex);
                    }
                }

            }
            catch (Exception ex)
            {
                int OrderId = 0;

                if (orderBondEquity != null)
                {
                    OrderId = orderBondEquity.OrderID;
                }

                item = Error(OrderId, MarketOrderID, EnumErrorCode.OMS9999, null, ex);
            }
            return item;
        }

        private static CommWebApi.ResponseObject ValidateInstrumentOrder(int orderID, BymaOrder bymaOrder, out InstrumentByma instrumentByma)
        {
            CommWebApi.ResponseObject item = null;
            //Valido que el instrumento este dentro de la tabla InstrumentsByma
            List<InstrumentByma> instrumentsByma = Retrieve.GetInstrumentsBymaFromBymaOrder(bymaOrder);
            instrumentByma = null;
            //SecurityType
            //SecurityStat = 1 Que esta activo
            //TimeInForce 
            //Currency
            //OrderType
            //SettlmntTyp 
            
                instrumentsByma = instrumentsByma.Where(ib => ib.TimeInForce.Contains(bymaOrder.TimeInForce)).ToList();
                if (instrumentsByma.Count > 0)
                {
                    instrumentsByma = instrumentsByma.Where(ib => ib.OrderType.Contains(bymaOrder.OrdType)).ToList();
                    if (instrumentsByma.Count > 0)
                    {
                        instrumentsByma = instrumentsByma.Where(ib => ib.Currency == bymaOrder.Currency).ToList();
                        if (instrumentsByma.Count > 0)
                        {
                            instrumentsByma = instrumentsByma.Where(ib => ib.SettlmntTyp == bymaOrder.SettlType).ToList();
                            if (instrumentsByma.Count > 0)
                            {
                                instrumentsByma = instrumentsByma.Where(ib => ib.SecurityStat == "1").ToList();
                                if (instrumentsByma.Count == 1)
                                {
                                    instrumentByma = instrumentsByma.FirstOrDefault();
                                }
                                else
                                {
                                    item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0100, "SecurityStat = 1");
                                    //ERROR SecurityStat
                                }
                            }
                            else
                            {
                                item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0105, "SettlType = " + bymaOrder.SettlType);
                                //ERROR SettlmntTyp
                            }
                        }
                        else
                        {
                            item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0101, "Currency = " + bymaOrder.Currency);
                            //ERROR Currency
                        }
                    }
                    else
                    {
                        item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0102, "OrdType = " + bymaOrder.OrdType);
                        //ERROR OrderType
                    }
                }
                else
                {
                    item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0103, "TimeInForce = " + bymaOrder.TimeInForce);
                    //ERROR TimeInForce
                }
           

            return item;
        }

        private static CommWebApi.ResponseObject ValidateFAKEInstrumentOrder(int orderID, BymaOrder bymaOrder, out InstrumentByma instrumentByma)
        {
            CommWebApi.ResponseObject item = null;
            //Valido que el instrumento este dentro de la tabla InstrumentsByma
            List<InstrumentByma> instrumentsByma = Retrieve.GetInstrumentsBymaFromBymaOrder(bymaOrder);
            instrumentByma = null;
            //SecurityType
            //SecurityStat = 1 Que esta activo
            //TimeInForce 
            //Currency
            //OrderType
            //SettlmntTyp 

                instrumentsByma = instrumentsByma.Where(ib => ib.TimeInForce.Contains(bymaOrder.TimeInForce)).ToList();
                if (instrumentsByma.Count > 0)
                {
                    instrumentsByma = instrumentsByma.Where(ib => ib.OrderType.Contains(bymaOrder.OrdType)).ToList();
                    if (instrumentsByma.Count > 0)
                    {
                        instrumentsByma = instrumentsByma.Where(ib => ib.Currency == bymaOrder.Currency).ToList();
                        if (instrumentsByma.Count > 0)
                        {
                            instrumentsByma = instrumentsByma.Where(ib => ib.SettlmntTyp == bymaOrder.SettlType).ToList();
                            if (instrumentsByma.Count == 1)
                            {
                                instrumentByma = instrumentsByma.FirstOrDefault();
                            }
                            else
                            {
                                if (instrumentsByma.Count > 0)
                                {
                                    instrumentByma = instrumentsByma.FirstOrDefault();
                                    //instrumentsByma = instrumentsByma.Where(ib => ib.SecurityStat == "1").ToList();
                                    //if (instrumentsByma.Count == 1)
                                    //{
                                    //    instrumentByma = instrumentsByma.FirstOrDefault();
                                    //}
                                    //else
                                    //{
                                    //    item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0100, "SecurityStat = 1");
                                    //    //ERROR SecurityStat
                                    //}
                                }
                                else
                                {
                                    item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0105, "SettlType = " + bymaOrder.SettlType);
                                    //ERROR SettlmntTyp
                                }
                            }
                          
                        }
                        else
                        {
                            item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0101, "Currency = " + bymaOrder.Currency);
                            //ERROR Currency
                        }
                    }
                    else
                    {
                        item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0102, "OrdType = " + bymaOrder.OrdType);
                        //ERROR OrderType
                    }
                }
                else
                {
                    item = Error(orderID, bymaOrder.MarketOrderID, EnumErrorCode.OMS0103, "TimeInForce = " + bymaOrder.TimeInForce);
                    //ERROR TimeInForce
                }

            return item;
        }


        internal static void SendBackSmartRouting(int MarketOrderID, string Status, bool HasOperations)
        {
            // Return MarketOrder OrderBondEquity Status
            char CharStatus = Convert.ToChar(Status);
            string ReturnStatus = "E";
            switch (CharStatus)
            {
                case QuickFix.Fields.OrdStatus.NEW:
                case QuickFix.Fields.OrdStatus.PENDING_NEW:
                    ReturnStatus = "M";
                    break;
                case QuickFix.Fields.OrdStatus.PARTIALLY_FILLED:
                    ReturnStatus = "W";
                    break;
                case QuickFix.Fields.OrdStatus.FILLED:
                    ReturnStatus = "C";
                    break;
                case QuickFix.Fields.OrdStatus.CANCELED:
                    ReturnStatus = "A";
                    break;
                case QuickFix.Fields.OrdStatus.REJECTED:
                    ReturnStatus = "X";
                    break;
                case QuickFix.Fields.OrdStatus.SUSPENDED:
                    ReturnStatus = "S";
                    break;
                case QuickFix.Fields.OrdStatus.EXPIRED:
                    if(HasOperations)
                    {
                        ReturnStatus = "Y";
                    }
                    else
                    {
                        ReturnStatus = "V";
                    }
                    break;
                default:
                    break;
            }

            CommWebApi.ResponseObject item = new CommWebApi.ResponseObject
            {
                ObjectID = MarketOrderID,
                Status = ReturnStatus
            };
            Service.SendRabbitBack(item);
        }

        private static CommWebApi.ResponseObject Error(int orderID, int marketOrderID, EnumErrorCode enumErrorCode, string description = null, Exception ex = null)
        {
            if(ex != null)
            {
                ErrorLog.Save(orderID, Assembly.GetEntryAssembly().GetName().Name, LogError.ReadErrorDescription(EnumErrorCode.OMS9999.ToString()), EnumErrorCode.OMS9999, ex, "NewBymaOrder(marketOrder);", marketOrderID);
                OrderTracking.SaveTracking(orderID, marketOrderID, 0, ex.Message);
            }
            else
            {
                OrderTracking.SaveTracking(orderID, marketOrderID, 0, LogError.ReadErrorDescription(enumErrorCode.ToString()));
            }

          
            CommWebApi.ResponseObject item = new CommWebApi.ResponseObject
            {
                ObjectID = marketOrderID,
                Status = "E",
                ErrorDescription = LogError.ReadErrorDescription(enumErrorCode.ToString()) + " " + description,
                ErrorCode = enumErrorCode.ToString()
            };
            return item;
        }

    }
}
