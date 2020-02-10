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
    }
}
