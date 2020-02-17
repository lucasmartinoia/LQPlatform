using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using LatamQuants.PrimaryAPI;
using RestSharp;

namespace Testing
{
    [TestClass]
    public class PrimaryAPI
    {
        [TestMethod]
        public void Init()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            bResult = RestAPI.RemoveToken();

            Assert.IsTrue(bResult);
        }

        [TestMethod]
        public void getSegments()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getSegmentsResponse.RootObject oResponse = RestAPI.GetSegments();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstruments()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsResponse.RootObject oResponse = RestAPI.GetInstruments();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstrumentsDetails()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsDetailsResponse.RootObject oResponse = RestAPI.GetInstrumentsDetails();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getOneInstrumentDetails()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getOneInstrumentDetailsResponse.RootObject oResponse = RestAPI.GetOneInstrumentDetails("ROFX", "DONov20");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstrumentsByCFICode()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsByCFICodeResponse.RootObject oResponse = RestAPI.getInstrumentsByCFICode("FXXXSX");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstrumentsBySegment()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsBySegmentResponse.RootObject oResponse = RestAPI.GetInstrumentsBySegment("DDA", "ROFX");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getCurrencies()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getCurrenciesResponse.RootObject oResponse = RestAPI.GetCurrencies();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getAccountReport()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.RootObject oResponse = RestAPI.GetAccountReport();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetMarketDataInstrumentHistoric()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getMarketDataInstrumentHistoricResponse.RootObject oResponse = RestAPI.GetMarketDataInstrumentHistoric("ROFX", "DONov20",DateTime.Now.AddDays(-60),DateTime.Now,false, "REMARKETS");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetMarketDataInstrumentRealTime()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getMarketDataInstrumentRealTimeResponse.RootObject oResponse = RestAPI.GetMarketDataInstrumentRealTime("ROFX", "DONov20", "BI,OF,LA,OP,CL,SE,OI",3);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAccountPositions()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getAccountPositionsResponse.RootObject oResponse = RestAPI.GetAccountPositions();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAccountPositionsDetails()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+", "REM1545");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getAccountPositionsDetailsResponse.RootObject oResponse = RestAPI.GetAccountPositionsDetails();

            Assert.IsTrue(true);
        }
    }
}
