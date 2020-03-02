using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Linq;
using Newtonsoft.Json;
using LatamQuants.PrimaryAPI.Models;
using System.Reflection;

namespace LatamQuants.PrimaryAPI
{
    public static class RestAPI
    {
        // Private variables
        public static Authentication m_auth=new Authentication();
        private static string m_baseURL = Models.EndPoint.baseURL;
        public static string m_account = "";
        public static bool SandBoxMode = false;

        public static bool Login(string pUser, string pPassword, string pAccount, string pBaseURL = null)
        {
            bool bResult = false;

            if (pBaseURL != null)
                m_baseURL = pBaseURL;

            m_account = pAccount;

            m_auth.User = pUser;
            m_auth.Password = pPassword;
            m_auth.TokenKey = "X-Auth-Token";
            m_auth.TokenValue = GetToken(m_auth.User, m_auth.Password);
            bResult = true;

            return bResult;
        }

        private static string GetToken(string pUser, string pPassword)
        {
            string sReturn = "";

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getToken);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(m_auth.User + ":" + m_auth.Password)));
                IRestResponse response = client.Execute(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusDescription);
                }
                else
                {
                    // Get Token from header
                    sReturn = (string)response.Headers.Cast<RestSharp.Parameter>().SingleOrDefault(x => x.Name == m_auth.TokenKey).Value;
                }
            }
            else
            {
                // Custom SandBox
                sReturn = "<TOKEN DEL SANDBOX>";
            }

            return sReturn;
        }

        public static bool RemoveToken()
        {
            bool bReturn = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getToken);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(m_auth.User + ":" + m_auth.Password)));
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bReturn = (response.StatusCode == System.Net.HttpStatusCode.OK);
            }
            else
            {
                bReturn = true;
            }

            return bReturn;
        }

        public static Models.getSegmentsResponse.RootObject GetSegments()
        {
            Models.getSegmentsResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getSegments);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if(bResult)
            {
                oReturn= JsonConvert.DeserializeObject<Models.getSegmentsResponse.RootObject>(response.Content);

                if (oReturn.status == "ERROR")
                {
                    throw new Exception(oReturn.description);
                }
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }

            return oReturn;
        }

        public static Models.getInstrumentsResponse.RootObject GetInstruments()
        {
            Models.getInstrumentsResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getInstruments);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getInstrumentsResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn=SandBox.Service.GetResponse<Models.getInstrumentsResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getInstrumentsDetailsResponse.RootObject GetInstrumentsDetails()
        {
            Models.getInstrumentsDetailsResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getInstrumentsDetails);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getInstrumentsDetailsResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getInstrumentsDetailsResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOneInstrumentDetailsResponse.RootObject GetOneInstrumentDetails(string pMarketID, string pSymbol)
        {
            Models.getOneInstrumentDetailsResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOneInstrumentDetails);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

                // Add parameters
                request.AddParameter("marketId", pMarketID);
                request.AddParameter("symbol", pSymbol);

                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOneInstrumentDetailsResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOneInstrumentDetailsResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getInstrumentsByCFICodeResponse.RootObject getInstrumentsByCFICode(string pCFICode)
        {
            Models.getInstrumentsByCFICodeResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getInstrumentsByCFICode);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            // Add parameters
            request.AddParameter("CFICode", pCFICode);

            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getInstrumentsByCFICodeResponse.RootObject>(response.Content);

                if (oReturn.status == "ERROR")
                {
                    throw new Exception(oReturn.description);
                }
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }

            return oReturn;
        }

        public static Models.getInstrumentsBySegmentResponse.RootObject GetInstrumentsBySegment(string pMarketSegmentID, string pMarketID)
        {
            Models.getInstrumentsBySegmentResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getInstrumentsBySegment);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            // Add parameters
            request.AddParameter("MarketSegmentID", pMarketSegmentID);
            request.AddParameter("MarketID", pMarketID);

            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getInstrumentsBySegmentResponse.RootObject>(response.Content);

                if (oReturn.status == "ERROR")
                {
                    throw new Exception(oReturn.description);
                }
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }

            return oReturn;
        }

        public static Models.getCurrenciesResponse.RootObject GetCurrencies()
        {
            Models.getCurrenciesResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getCurrencies);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getCurrenciesResponse.RootObject>(response.Content);

                if (oReturn.status == "ERROR")
                {
                    throw new Exception(oReturn.description);
                }
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }

            return oReturn;
        }

        public static Models.getAccountReportResponse.RootObject GetAccountReport()
        {
            Models.getAccountReportResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getAccountReport + m_account);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getAccountReportResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getAccountReportResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }
            return oReturn;
        }

        public static Models.getMarketDataInstrumentHistoricResponse.RootObject GetMarketDataInstrumentHistoric(string pMarketID, string pSymbol, DateTime pDateFrom, DateTime pDateTo, bool pExternal, string pEnvironment)
        {
            Models.getMarketDataInstrumentHistoricResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getMarketDataInstrumentHistoric);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            // Add parameters
            request.AddParameter("marketId", pMarketID);
            request.AddParameter("symbol", pSymbol);
            request.AddParameter("dateFrom", pDateFrom.ToString("yyyy-MM-dd"));
            request.AddParameter("dateTo", pDateTo.ToString("yyyy-MM-dd"));
            request.AddParameter("external", pExternal);
            request.AddParameter("environment", pEnvironment);

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getMarketDataInstrumentHistoricResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getMarketDataInstrumentHistoricResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getMarketDataInstrumentRealTimeResponse.RootObject GetMarketDataInstrumentRealTime(string pMarketID, string pSymbol, string pEntries, int pDepth)
        {
            Models.getMarketDataInstrumentRealTimeResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getMarketDataInstrumentRealTime);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            // Add parameters
            request.AddParameter("marketId", pMarketID);
            request.AddParameter("symbol", pSymbol);
            request.AddParameter("entries", pEntries);
            request.AddParameter("depth", pDepth);

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getMarketDataInstrumentRealTimeResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getMarketDataInstrumentRealTimeResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getAccountPositionsResponse.RootObject GetAccountPositions()
        {
            Models.getAccountPositionsResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getAccountPositions + m_account);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getAccountPositionsResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getAccountPositionsResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getAccountPositionsDetailsResponse.RootObject GetAccountPositionsDetails()
        {
            Models.getAccountPositionsDetailsResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getAccountPositions + m_account);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getAccountPositionsDetailsResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getAccountPositionsDetailsResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.newSingleOrderResponse.RootObject newSingleOrder(Models.newSingleOrderRequest pOrderRequest)
        {
            Models.newSingleOrderResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.newSingleOrder);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            // Add parameters

            // Required
            request.AddParameter("marketId", pOrderRequest.instrumentId.marketId);
            request.AddParameter("symbol", pOrderRequest.instrumentId.symbol);
            request.AddParameter("orderQty", pOrderRequest.orderQty);
            request.AddParameter("ordType", pOrderRequest.ordType);
            request.AddParameter("side", pOrderRequest.side);
            request.AddParameter("account", pOrderRequest.account);
            request.AddParameter("timeInForce", pOrderRequest.timeInForce);

            // Price
            if (pOrderRequest.ordType=="Limit")
                request.AddParameter("price", pOrderRequest.price);


            // Expire Date
            if(pOrderRequest.timeInForce=="GTD")
                request.AddParameter("expireDate", pOrderRequest.expireDate);

            // Cancel Previous
            if(pOrderRequest.cancelPrevious??false)
                request.AddParameter("cancelPrevious", pOrderRequest.cancelPrevious);

            // Iceberg
            if (pOrderRequest.iceberg?? false)
            {
                request.AddParameter("iceberg", pOrderRequest.iceberg);
                request.AddParameter("displayQty", pOrderRequest.displayQty);
            }

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.newSingleOrderResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.newSingleOrderResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.cancelOrderByClientOrderIDResponse.RootObject CancelOrderByClientOrderID(string pClientOrderID, string pProprietary)
        {
            Models.cancelOrderByClientOrderIDResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.cancelOrderByClientOrderID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            // Add parameters

            // Required
            request.AddParameter("clOrdId", pClientOrderID);
            request.AddParameter("proprietary", pProprietary);

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.cancelOrderByClientOrderIDResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.cancelOrderByClientOrderIDResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.replaceOrderByClientOrderIDResponse.RootObject ReplaceOrderByClientOrderID(string pClientOrderID, string pProprietary, double pOrderQuantity, double pPrice)
        {
            Models.replaceOrderByClientOrderIDResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.replaceOrderByClientOrderID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

            // Add parameters

            // Required
            request.AddParameter("clOrdId", pClientOrderID);
            request.AddParameter("proprietary", pProprietary);
            request.AddParameter("orderQty", pOrderQuantity);
            request.AddParameter("price", pPrice);

            if (SandBoxMode == false)
            {
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.replaceOrderByClientOrderIDResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.replaceOrderByClientOrderIDResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOrdersActiveResponse.RootObject GetActiveOrders()
        {
            Models.getOrdersActiveResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOrdersActive + "accountId=" + m_account);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOrdersActiveResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOrdersActiveResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOrderAllStatusByCliendOrderIDResponse.RootObject GetOrderAllStatusByCliendOrderID(string pClientOrderID, string pProprietary)
        {
            Models.getOrderAllStatusByCliendOrderIDResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOrderAllStatusByCliendOrderID);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);

                // Add parameters

                // Required
                request.AddParameter("clOrdId", pClientOrderID);
                request.AddParameter("proprietary", pProprietary);

                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOrderAllStatusByCliendOrderIDResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOrderAllStatusByCliendOrderIDResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOrderLastStatusByCliendOrderIDResponse.RootObject GetOrderLastStatusByCliendOrderID(string sClientOrderID)
        {
            Models.getOrderLastStatusByCliendOrderIDResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOrderLastStatusByCliendOrderID + "clOrdId=" + sClientOrderID);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOrderLastStatusByCliendOrderIDResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOrderLastStatusByCliendOrderIDResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOrderByOrderIDResponse.RootObject GetOrderByOrderID(string sOrderID)
        {
            Models.getOrderByOrderIDResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOrderByOrderID + "orderId=" + sOrderID);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOrderByOrderIDResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOrderByOrderIDResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOrderStatusByExecutionIDResponse.RootObject GetOrderStatusByExecutionID(string sExecID)
        {
            Models.getOrderStatusByExecutionIDResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOrderStatusByExecutionID + "execId=" + sExecID);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOrderStatusByExecutionIDResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOrderStatusByExecutionIDResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOrdersFilledResponse.RootObject GetOrdersFilled()
        {
            Models.getOrdersFilledResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOrdersFilled + "accountId=" + m_account);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOrdersFilledResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOrdersFilledResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }

        public static Models.getOrdersByAccountResponse.RootObject GetOrdersByAccount()
        {
            Models.getOrdersByAccountResponse.RootObject oReturn = null;
            bool bResult = false;

            if (SandBoxMode == false)
            {
                var client = new RestClient(m_baseURL + Models.EndPoint.getOrdersByAccount + "accountId=" + m_account);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
                IRestResponse response = client.Execute(request);
                bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

                if (bResult)
                {
                    oReturn = JsonConvert.DeserializeObject<Models.getOrdersByAccountResponse.RootObject>(response.Content);

                    if (oReturn.status == "ERROR")
                    {
                        throw new Exception(oReturn.description);
                    }
                }
                else
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
            else
            {
                oReturn = SandBox.Service.GetResponse<Models.getOrdersByAccountResponse.RootObject>(MethodBase.GetCurrentMethod().Name);
            }

            return oReturn;
        }


    }
}
