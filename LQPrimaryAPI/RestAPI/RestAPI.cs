using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Linq;
using Newtonsoft.Json;
using LatamQuants.PrimaryAPI.Models;

namespace LatamQuants.PrimaryAPI
{
    public static class RestAPI
    {
        // Private variables
        private static Authentication m_auth=new Authentication();
        private static string m_baseURL = Models.EndPoint.baseURL;
        private static string m_account = "";

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

            var client = new RestClient(m_baseURL+Models.EndPoint.getToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic "+ Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(m_auth.User + ":" + m_auth.Password)));
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

            return sReturn;
        }

        public static bool RemoveToken()
        {
            bool bReturn = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(m_auth.User + ":" + m_auth.Password)));
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
            IRestResponse response = client.Execute(request);
            bReturn = (response.StatusCode== System.Net.HttpStatusCode.OK);

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

            var client = new RestClient(m_baseURL + Models.EndPoint.getInstruments);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getInstrumentsResponse.RootObject>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }

            return oReturn;
        }

        public static Models.getInstrumentsDetailsResponse.RootObject GetInstrumentsDetails()
        {
            Models.getInstrumentsDetailsResponse.RootObject oReturn = null;
            bool bResult = false;

            var client = new RestClient(m_baseURL + Models.EndPoint.getInstrumentsDetails);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getInstrumentsDetailsResponse.RootObject>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }

            return oReturn;
        }

        public static Models.getOneInstrumentDetailsResponse.RootObject GetOneInstrumentDetails(string pMarketID, string pSymbol)
        {
            Models.getOneInstrumentDetailsResponse.RootObject oReturn = null;
            bool bResult = false;

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

                if(oReturn.status=="ERROR")
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
            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getAccountReportResponse.RootObject>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
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
            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getAccountPositionsResponse.RootObject>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
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
            IRestResponse response = client.Execute(request);
            bResult = (response.StatusCode == System.Net.HttpStatusCode.OK);

            if (bResult)
            {
                oReturn = JsonConvert.DeserializeObject<Models.getAccountPositionsDetailsResponse.RootObject>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
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

            return oReturn;
        }
    }
}
