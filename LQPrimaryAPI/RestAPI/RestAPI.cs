using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using LatamQuants.Support;
using RestSharp;
using System.Linq;


namespace LatamQuants.PrimaryAPI
{
    public static class RestAPI
    {
        // Private variables
        private static Authentication m_auth=new Authentication();

        public static bool Login(string pUser, string pPassword)
        {
            bool bResult = false;

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

            var client = new RestClient(Models.EndPoint.baseURL+Models.EndPoint.getToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic "+ Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(m_auth.User + ":" + m_auth.Password)));
            IRestResponse response = client.Execute(request);

            // Get Token from header
            sReturn = (string)response.Headers.Cast<RestSharp.Parameter>().SingleOrDefault(x => x.Name == m_auth.TokenKey).Value;

            return sReturn;
        }

        public static bool RemoveToken()
        {
            bool bReturn = false;

            var client = new RestClient(Models.EndPoint.baseURL + Models.EndPoint.getToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(m_auth.User + ":" + m_auth.Password)));
            request.AddHeader(m_auth.TokenKey, m_auth.TokenValue);
            IRestResponse response = client.Execute(request);
            bReturn = (response.StatusCode== System.Net.HttpStatusCode.OK);

            return bReturn;
        }
    }
}
