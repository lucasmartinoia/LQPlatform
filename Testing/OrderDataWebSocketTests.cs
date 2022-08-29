using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using LatamQuants.PrimaryAPI;
using LatamQuants.PrimaryAPI.Models;
using LatamQuants.PrimaryAPI.Models.Websocket;

namespace PrimaryAPI.Tests
{
    [TestFixture]
    internal class OrderDataWebSocketTests
    {
        [OneTimeSetUp]
        public async Task Login()
        {
            string Username = "<user name>";
            string Password = "<password>";
            string Account = "<account no>";

            RestAPI.Login(Username, Password, Account,1);
        }
    }
}
