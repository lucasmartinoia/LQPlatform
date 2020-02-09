using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace LatamQuants.Support
{
    public static class CommWebService
    {
        public static string CallWebService(string sURL, string sSoapMessage)
        {

            //string sURL = GlobalSettings.PolicySystem;

            //string sWSNamespace = @"http://CalypsoPolicySystem_lib/service/PolicySystem";
            //string sMethodVerb = "policySystem";
            //string sMethodName = "PolicySystem";
        //    string sSoapMessage = @"<?xml version=""1.0"" encoding=""utf-8""?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:pol=""http://CalypsoPolicySystem_lib/service/PolicySystem"">";

        //    sSoapMessage = sSoapMessage + "<soapenv:Header />";
        //    sSoapMessage = sSoapMessage + "<soapenv:Body>";
        //  //  sSoapMessage = sSoapMessage + "<pol:PolicySystem>";
        ////    sSoapMessage = sSoapMessage + "<in_policySystem>";

        //    // Completar con los objetos a enviar.

        //    sSoapMessage = sSoapMessage + sSoapMessageBody;

        //    //sSoapMessage = sSoapMessage + "</in_policySystem>";
        //  //  sSoapMessage = sSoapMessage + "</pol:PolicySystem>";
        //    sSoapMessage = sSoapMessage + "</soapenv:Body>";
        //    sSoapMessage = sSoapMessage + "</soapenv:Envelope>";

  
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sURL);
            req.Headers.Add("SOAPAction", "\"http://tempuri.org/"); // + "policySystem123" + "/" + "PolicySystem55" + "\"");
            req.Headers.Add("To", sURL);
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";

            using (Stream stm = req.GetRequestStream())
            {
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(sSoapMessage);
                }
            }

            WebResponse response = req.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);

            string strResponse = sr.ReadToEnd();
            return strResponse;
        }

        public static string CallWebService(string sURL, XmlDocument soapEnvelopeXml)
        {
            HttpWebRequest webRequest = CreateWebRequest(sURL, "\"http://tempuri.org/");
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                return soapResult;
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }   
}
