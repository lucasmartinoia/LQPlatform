using QuickFix.Fields;
using QuickFix.FIX50SP2;
using System;
using Entity;

namespace LQ.Primary
{
    public class QuickFixMessages
    {

        internal static NewOrderSingle NewOrderSingle(BymaOrder bymaOrder)
        {
            Console.WriteLine("NewOrderSingle");

            OrdType ordType = new OrdType(Convert.ToChar(bymaOrder.OrdType));
            NewOrderSingle newOrderSingle = new NewOrderSingle(new ClOrdID(bymaOrder.ClOrdID), new Side(Convert.ToChar(bymaOrder.Side)), new TransactTime(DateTime.UtcNow), ordType)
            {
                OrderQty = new OrderQty(bymaOrder.OrderQty),
                TimeInForce = new TimeInForce(Convert.ToChar(bymaOrder.TimeInForce)),
                Currency = new Currency(bymaOrder.Currency),
                Account = new Account(bymaOrder.Account),//falta
                Symbol = new Symbol(bymaOrder.Symbol),
                SecurityType = new SecurityType(bymaOrder.SecurityType),
                SecurityExchange = new SecurityExchange(bymaOrder.SecurityExchange),
                CFICode = new CFICode(bymaOrder.CFICode),
                OrderCapacity = new OrderCapacity(Convert.ToChar(bymaOrder.OrderCapacity)),
            };

            if (Convert.ToChar(bymaOrder.TimeInForce) == TimeInForce.GOOD_TILL_DATE)
            {
                newOrderSingle.ExpireDate = new ExpireDate(bymaOrder.ExpireDate.ToString());
            }

            switch (ordType.getValue())
            {
                case OrdType.LIMIT:
                    newOrderSingle.Set(new Price((decimal)bymaOrder.Price));
                    break;
                case OrdType.STOP_LIMIT:
                    newOrderSingle.Set(new Price((decimal)bymaOrder.Price));
                    newOrderSingle.Set(new StopPx((decimal)bymaOrder.StopPx));
                    break;
                case OrdType.STOP:
                    newOrderSingle.Set(new StopPx((decimal)bymaOrder.StopPx));
                    break;
                case OrdType.MARKET:
                    //newOrderSingle.Set(new Price(0));
                    break;
                default:
                    break;
            }

            NewOrderSingle.NoPartyIDsGroup parties = new NewOrderSingle.NoPartyIDsGroup
            {
                PartyID = new PartyID(bymaOrder.PartyID),//falta
                PartyIDSource = new PartyIDSource(Convert.ToChar(bymaOrder.PartyIDSource)),//falta
                PartyRole = new PartyRole(bymaOrder.PartyRole)
            };

            newOrderSingle.AddGroup(parties);

            newOrderSingle.SetField(new SettlType(bymaOrder.SettlType));//falta---
            newOrderSingle.SetField(new CharField(29501, Convert.ToChar(bymaOrder.TradeFlag)));

            return newOrderSingle;
        }

        internal static SecurityListRequest SecurityListRequest(string securityReqID)
        {
            SecurityListRequest message = new SecurityListRequest(new SecurityReqID(securityReqID), new SecurityListRequestType(SecurityListRequestType.ALL_SECURITIES))
            {
                SubscriptionRequestType = new SubscriptionRequestType(SubscriptionRequestType.SNAPSHOT),
                SecurityListType = new SecurityListType(2)
            };
            return message;
        }

        internal static OrderCancelRequest OrderCancelRequest(BymaOrderCancellation bymaOrderCancelation)
        {
            OrderCancelRequest orderCancelRequest = new OrderCancelRequest(
                new ClOrdID(bymaOrderCancelation.ClOrdID),
                new Side(Convert.ToChar(bymaOrderCancelation.Side)),
                new TransactTime(DateTime.UtcNow))
            {
                //OrigClOrdID = new OrigClOrdID(bymaOrderCancelation.OrigClOrdID),
                //SecurityID = new SecurityID(bymaOrderCancelation.SecurityID),
                Symbol = new Symbol(bymaOrderCancelation.Symbol),
                //SecurityType = new SecurityType(bymaOrderCancelation.SecurityType)
            };
            orderCancelRequest.SetField(new Currency(bymaOrderCancelation.Currency));
            //orderCancelRequest.SetField(new SettlType(bymaOrderCancelation.SettlType));


            TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup partyIdsGrp = new TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup
            {
                //PartyID = new PartyID(bymaOrderCancelation.PartyID),
                //PartyIDSource = new PartyIDSource(Convert.ToChar(bymaOrderCancelation.PartyIDSource)),
                //PartyRole = new PartyRole(bymaOrderCancelation.PartyRole)
            };

            orderCancelRequest.AddGroup(partyIdsGrp);
            return orderCancelRequest;
        }

        internal static OrderStatusRequest OrderStatusRequest(BymaOrder bymaOrder)
        {
            OrderStatusRequest message = new OrderStatusRequest(new Side(Convert.ToChar(bymaOrder.Side)))
            {
                ClOrdID = new ClOrdID(bymaOrder.ClOrdID)
            };
            OrderStatusRequest.NoPartyIDsGroup partyIdsGrp = new OrderStatusRequest.NoPartyIDsGroup
            {
                PartyID = new PartyID(bymaOrder.PartyID),
                PartyIDSource = new PartyIDSource(Convert.ToChar(bymaOrder.PartyIDSource)),
                PartyRole = new PartyRole(bymaOrder.PartyRole)
            };

            message.AddGroup(partyIdsGrp);
            return message;
        }

        //internal Message CancelOrderRequestFIX50SP2(BymaOrder orderCancelSend)
        //{
        //    OrderCancelRequest orderCancelRequest = new OrderCancelRequest(
        //        new ClOrdID(orderCancelSend.ClOrdID),
        //        new Side(orderCancelSend.Side),
        //        new TransactTime(DateTime.UtcNow))
        //    {
        //        OrigClOrdID = new OrigClOrdID(orderCancelSend.OrigClOrdID),
        //        SecurityID = new SecurityID(orderCancelSend.SecurityID),
        //        Symbol = new Symbol(orderCancelSend.Symbol),
        //        SecurityType = new SecurityType(orderCancelSend.SecurityType)
        //    };
        //    orderCancelRequest.SetField(new Currency(orderCancelSend.Currency));
        //    orderCancelRequest.SetField(new SettlType(orderCancelSend.SettlType));


        //    TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup partyIdsGrp = new TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup
        //    {
        //        PartyID = new PartyID(orderCancelSend.PartyID),
        //        PartyIDSource = new PartyIDSource(Convert.ToChar(orderCancelSend.PartyIDSource)),
        //        PartyRole = new PartyRole(orderCancelSend.PartyRole)
        //    };

        //    orderCancelRequest.AddGroup(partyIdsGrp);
        //    return orderCancelRequest;
        //}


        ////internal void QueryCancelOrder(OrderCancelSend orderCancelSend)
        ////{

        ////    OrderCancelRequest m = QueryOrderCancelRequestFIX50SP2(orderCancelSend);

        ////    if (m != null)
        ////        SendMessage(m);
        ////}

        //internal Message OrderStatusRequest(OrderStatusRequestSend orderStatusRequestSend)
        //{
        //    Console.WriteLine("QueryOrderStatusRequest");

        //    OrderStatusRequest message = new OrderStatusRequest(new Side(orderStatusRequestSend.Side_54));

        //    message.ClOrdID = new ClOrdID(orderStatusRequestSend.ClOrdID_11);
        //    OrderStatusRequest.NoPartyIDsGroup partyIdsGrp = new OrderStatusRequest.NoPartyIDsGroup
        //    {
        //        PartyID = new PartyID(orderStatusRequestSend.PartyID_448),
        //        PartyIDSource = new PartyIDSource(orderStatusRequestSend.PartyIDSource_447),
        //        PartyRole = new PartyRole(orderStatusRequestSend.PartyRole_452)
        //    };

        //    message.AddGroup(partyIdsGrp);

        //    return message;

        //}
        //internal Message SecurityDefinition(SecurityDefinitionSend securityDefinitionSend)
        //{
        //    Console.WriteLine("SecurityDefinition");

        //    SecurityDefinitionRequest message = new SecurityDefinitionRequest
        //    {
        //        SecurityReqID = new SecurityReqID(securityDefinitionSend.SecurityReqID_320),
        //        SecurityExchange = new SecurityExchange(securityDefinitionSend.SecurityExchange_207),
        //        SecurityID = new SecurityID(securityDefinitionSend.SecurityID_48),
        //        Symbol = new Symbol(securityDefinitionSend.Symbol_55),
        //        SecurityType = new SecurityType(securityDefinitionSend.SecurityType_167),
        //        SecurityRequestType = new SecurityRequestType(SecurityRequestType.REQUEST_SECURITY_IDENTITY_AND_SPECIFICATIONS)
        //    };

        //    return message;
        //}
        ////private void QueryReplaceOrder(string origClOrdID, string clOrdID, string symbol, char side, char ordType, decimal quantity)
        ////{
        ////    Console.WriteLine("CancelReplaceRequest");

        ////    OrderCancelReplaceRequest m = QueryCancelReplaceRequestFIX50SP2(origClOrdID, clOrdID, symbol, side, ordType, quantity);

        ////    if (m != null)
        ////        SendMessage(m);
        ////}
        //internal Message MarketDataRequest(MarketDataRequestSend marketDataRequestSend)
        //{
        //    Console.WriteLine("MarketDataRequest");

        //    //MessageParser.OrderMarketDataRequestRecive = new List<MarketDataRequestRecive>();


        //    //QuickFix.FIX50SP2.Message m = QueryMarketDataRequestFIX50SP2(new string[] { "OCTGA28FEB20", "LUCH", "ARS", SecurityType.CASH }, SubscriptionRequestType.SNAPSHOT);
        //    //Message message = new QuickFix.FIX50SP2.Message();
        //    MarketDataRequest mdr = new MarketDataRequest();

        //    mdr.Set(new MDReqID(DateTime.UtcNow.ToString("ddMMyyyyHHmmss"))); //PARA QUE SE UNICO

        //    mdr.Set(new SubscriptionRequestType(marketDataRequestSend.SubscriptionRequestType_263));
        //    mdr.Set(new MDUpdateType(MDUpdateType.FULL_REFRESH)); //required if above type is SNAPSHOT_PLUS_UPDATES
        //                                                          //1=Top of Book, 0 = full book, other integer equals number of levels
        //    mdr.Set(new MarketDepth(1));
        //    mdr.Set(new AggregatedBook(true));

        //    //mdr.Set(new DeliverToCompID("FGW")); //Para Millennium el valor será “FGW” y para futuros “UMDF” y para futuros “UMDF”

        //    // Define instrument
        //    MarketDataRequest.NoRelatedSymGroup sgroup = new MarketDataRequest.NoRelatedSymGroup();
        //    sgroup.Set(new Symbol(marketDataRequestSend.Symbol_55)); //Instrumento
        //    sgroup.Set(new SecurityType(marketDataRequestSend.SecurityType_167)); //Instrumento
        //    //sgroup.Set(new SecurityExchange(marketDataRequestSend.SecurityExchange_207)); //RUEDA
        //    sgroup.Set(new Currency(marketDataRequestSend.Currency_15)); //MONEDA
        //    sgroup.Set(new SettlType(marketDataRequestSend.SettlType_63)); //CASH
        //    //sgroup.Set(new Product(Product.INDEX)); //7 INDEX 12 OTHER (used for Statistics)

        //    mdr.AddGroup(sgroup);

        //    MarketDataRequest.NoMDEntryTypesGroup tgroup = new MarketDataRequest.NoMDEntryTypesGroup();//.NoMDEntryTypes();
        //    tgroup.Set(new MDEntryType(MDEntryType.BID));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.OFFER));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.TRADE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.INDEX_VALUE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.OPENING_PRICE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.CLOSING_PRICE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.SETTLEMENT_PRICE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.TRADING_SESSION_HIGH_PRICE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.TRADING_SESSION_LOW_PRICE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.IMBALANCE));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.TRADE_VOLUME));
        //    mdr.AddGroup(tgroup);
        //    tgroup.Set(new MDEntryType(MDEntryType.AUCTION_CLEARING_PRICE));
        //    mdr.AddGroup(tgroup);

        //    return mdr;

        //}
        ////internal void QuerySecurityListRequest(string uniqueID)
        ////{
        ////    Console.WriteLine("QuerySecurityListRequest");

        ////    QuickFix.Message m = QuerySecurityList(uniqueID);

        ////    //MessageParser.OrderMarketDataRecives = new List<OrderMarketDataRecive>();
        ////    // DeliverToCompID (128) Para Millennium el valor será “FGW”

        ////    if (m != null)
        ////        SendMessage(m);
        ////}
        //internal Message TradeCaptureReportRequest(string tradeRequestID, string partyId, char partyIDSource, int partyRole)
        //{
        //    Console.WriteLine("QuerySecurityListRequest");

        //    TradeCaptureReportRequest m = new TradeCaptureReportRequest(
        //        new TradeRequestID(tradeRequestID),
        //        new TradeRequestType(TradeRequestType.ALL_TRADES)
        //        );


        //    TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup partyIdsGrp = new TradeCaptureReport.NoSidesGroup.NoPartyIDsGroup
        //    {
        //        PartyID = new PartyID(partyId),
        //        PartyIDSource = new PartyIDSource(partyIDSource),
        //        PartyRole = new PartyRole(partyRole)
        //    };

        //    m.AddGroup(partyIdsGrp);
        //    /* OrderBook - Tag 30001
        //     * 1 Regular
        //     * 2 Off Book
        //     * 3 Odd Lot
        //     * 4 Block Trade
        //     * 6 Early Settlement
        //     * 7 Auctions
        //    */
        //    m.SetField(new IntField(30001, 1));

        //    return m;
        //}
        //private QuickFix.Message QuerySecurityList(string uniqueID)
        //{
        //    SecurityListRequest message = new SecurityListRequest(new SecurityReqID("SLRGAL"), new SecurityListRequestType(SecurityListRequestType.ALL_SECURITIES))
        //    {
        //        SubscriptionRequestType = new SubscriptionRequestType(SubscriptionRequestType.SNAPSHOT),
        //        SecurityListType = new SecurityListType(2)
        //    };
        //    return message;
        //}

        //private OrderCancelReplaceRequest QueryCancelReplaceRequestFIX50SP2(string origClOrdID, string clOrdID, string symbol, char side, char orderType, decimal quantity)
        //{
        //    OrderCancelReplaceRequest ocrr = new OrderCancelReplaceRequest(
        //        new ClOrdID(clOrdID),
        //        //QueryOrigClOrdID(origClOrdID),
        //        new Side(side),
        //        new TransactTime(DateTime.UtcNow),
        //        //QuerySymbol(symbol),
        //        new OrdType(orderType));

        //    ocrr.Set(new HandlInst('1'));
        //    //if (QueryConfirm("New price"))
        //    ocrr.Set(new Price(quantity));
        //    //if (QueryConfirm("New quantity"))
        //    ocrr.Set(new OrderQty(quantity));

        //    return ocrr;
        //}
        //private MarketDataRequest QueryMarketDataRequest44()
        //{
        //    //“Campo requerido si el mensaje surge de un pedido mediante un mensaje MarkeDataRequest. Es el único
        //    //Identificador de la solicitud(copia el valor desde el mensaje MarketDataRequest).”
        //    MDReqID mdReqID = new MDReqID("SuscripcionBYMA_MD64");

        //    //1 (**) Snapshot + Updates (Subscribe) 
        //    //2 (**) Unsubscribe (not supported for DMA)
        //    SubscriptionRequestType subType = new SubscriptionRequestType(SubscriptionRequestType.SNAPSHOT_PLUS_UPDATES);

        //    //“Profundidad del Mercado tanto para capturas de libro, como actualizaciones incrementales.
        //    //Para el caso de los futuros este valor es fijo y debe ser 100”
        //    MarketDepth marketDepth = new MarketDepth(5);



        //    MarketDataRequest.NoMDEntryTypesGroup marketDataEntryGroup = new MarketDataRequest.NoMDEntryTypesGroup();
        //    marketDataEntryGroup.Set(new MDEntryType(MDEntryType.BID));

        //    //55 OCTGA28FEB20 “Especies”
        //    MarketDataRequest.NoRelatedSymGroup symbolGroup = new MarketDataRequest.NoRelatedSymGroup();
        //    symbolGroup.Set(new Symbol("OCTGA28FEB20"));

        //    MarketDataRequest message = new MarketDataRequest(mdReqID, subType, marketDepth);
        //    message.AddGroup(marketDataEntryGroup);
        //    message.AddGroup(symbolGroup);

        //    // ”Este campo es requerido si el tag (263) SubscriptionRequestType
        //    //= Snapshot + Updates(1).El servicio FIX de BYMA no soporta el valor 1 en el tag 263, por lo tanto este campo no es requerido.”
        //    message.MDUpdateType = new MDUpdateType(MDUpdateType.FULL_REFRESH);

        //    //266   Y Aggregated  N Disaggregated
        //    message.AggregatedBook = new AggregatedBook(AggregatedBook.YES);

        //    //207 LUCH "rueda"
        //    SecurityExchange securityExchange = new SecurityExchange("LUCH");
        //    message.SetField(securityExchange);

        //    //15 ARS "Moneda"
        //    Currency currency = new Currency("ARS");
        //    message.SetField(currency);


        //    return message;
        //}
        //private RequestForPositions QueryRequestForPositionFIX50SP2(string posReqID, int posReqType)
        //{
        //    return new RequestForPositions(new PosReqID(posReqID), new PosReqType(posReqType), new ClearingBusinessDate(DateTime.UtcNow.ToString("yyyyMMdd")), new TransactTime(DateTime.UtcNow));
        //}
        //private OrderStatusRequest QueryGatewayStatus(char c)
        //{
        //    OrderStatusRequest message = new OrderStatusRequest(new Side(c));

        //    return message;
        //}
    }
}
