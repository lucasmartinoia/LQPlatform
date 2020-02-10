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
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+");

            Assert.IsTrue(bResult);

            bResult = RestAPI.RemoveToken();

            Assert.IsTrue(bResult);
        }

        [TestMethod]
        public void getSegments()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getSegmentsResponse.RootObject oResponse = RestAPI.GetSegments();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstruments()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsResponse.RootObject oResponse = RestAPI.GetInstruments();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstrumentsDetails()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsDetailsResponse.RootObject oResponse = RestAPI.GetInstrumentsDetails();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getOneInstrumentDetails()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getOneInstrumentDetailsResponse.RootObject oResponse = RestAPI.GetOneInstrumentDetails("ROFX", "DONov20");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstrumentsByCFICode()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsByCFICodeResponse.RootObject oResponse = RestAPI.getInstrumentsByCFICode("FXXXSX");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void getInstrumentsBySegment()
        {
            bool bResult = RestAPI.Login("lucasmartinoia1545", "erwonZ2+");

            Assert.IsTrue(bResult);

            LatamQuants.PrimaryAPI.Models.getInstrumentsBySegmentResponse.RootObject oResponse = RestAPI.getInstrumentsBySegment("DDA", "ROFX");

            Assert.IsTrue(true);
        }
    }
}
