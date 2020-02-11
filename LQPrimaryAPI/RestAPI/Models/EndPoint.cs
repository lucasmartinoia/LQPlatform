using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    class EndPoint
    {
        public const string baseURL = "http://api.remarkets.primary.com.ar";
        public const string getToken = "/auth/getToken"; //OK
        public const string removeToken = "/auth/removeToken"; //OK
        public const string getSegments = "/rest/segment/all"; //OK
        public const string getInstruments = "/rest/instruments/all"; //OK
        public const string getInstrumentsDetails = "/rest/instruments/details"; //OK
        public const string getOneInstrumentDetails = "/rest/instruments/detail?"; //OK
        
        // TODO: TO IMPLEMENT
        public const string getInstrumentsByCFICode = "/rest/instruments/byCFICode?"; //OK
        public const string getInstrumentsBySegment = "/rest/instruments/bySegment?"; //OK
        public const string getCurrencies = "/rest/risk/currency/getAll"; //OK
        public const string getMarketDataInstrumentRealTime = "/rest/marketdata/get?";
        public const string getMarketDataInstrumentHistoric = "/rest/data/getTrades?";
        public const string getOrdersActive = "/rest/order/actives?";
        public const string getOrdersFilled = "/rest/order/filleds?";
        public const string getOrdersByAccount = "/rest/order/all?";
        public const string getOrderStatusByExecutionID = "/rest/order/byExecId?";
        public const string getOrderByOrderID = "/rest/order/byOrderId?";
        public const string getOrderLastStatusByCliendOrderID = "/rest/order/id?";
        public const string getOrderAllStatusByCliendOrderID = "/rest/order/allById?";
        public const string newSingleOrder = "/rest/order/newSingleOrder?";
        public const string replaceOrderByClientOrderID = "/rest/order/replaceById?";
        public const string cancelOrderByClientOrderID = "/rest/order/cancelById?";
        public const string getAccountPositions = "/rest/risk/position/getPositions/";
        public const string getAccountPositionsDetails = "/rest/risk/detailedPosition/";
        public const string getAccountReport = "/rest/risk/accountReport/";
    }
}
