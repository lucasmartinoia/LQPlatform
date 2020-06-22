using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using LatamQuants.PrimaryAPI;
using LatamQuants.PrimaryAPI.Models;
using LatamQuants.PrimaryAPI.WebSocket.Net;

namespace PrimaryAPI.Tests
{
    [TestFixture]
    internal class MarketDataWebSocketTests
    {
        [OneTimeSetUp]
        public async Task Login()
        {
            string Username = "77590";
            string Password = "Lucas20+";
            string Account = "77590";

            RestAPI.Login(Username, Password, Account);
        }

        [Test]
        [Timeout(10000)]
        public async Task SubscriptionToMarketDataCanBeCreated()
        {
            // Get a dollar future
            List<Instrument> instruments = RestAPI.GetInstruments().instruments;
            Instrument instrument = instruments.Last( i => i.instrumentId.symbol == Build.DollarFutureSymbol() );

            // Subscribe to all entries
            using var socket = WebSocketAPI.CreateMarketDataSocket(new[] { instrument.instrumentId }, AllEntries, 1, 1);
            socket.OnDataReceived += new WebSocket<MarketDataInfo, MarketData>.OnDataReceivedEventHandler(OnDataReceived);

            //MarketData retrievedData = null;
            //socket.OnData = (marketData => retrievedData = marketData);

            await socket.Start();

            //// Wait until data arrives
            //while (retrievedData == null)
            //{
            //    Thread.Sleep(100);
            //}

        }

        private void OnDataReceived(Object sender, WebSocket<MarketDataInfo, LatamQuants.PrimaryAPI.Models.MarketData>.OnDataReceivedArgs e)
        {
            LatamQuants.PrimaryAPI.Models.MarketData oNewMarketData = (LatamQuants.PrimaryAPI.Models.MarketData)e.oResponse;
            Assert.That(oNewMarketData.Instrument.marketId, Is.Not.Null.And.Not.Empty);
            Assert.That(oNewMarketData.Instrument.symbol, Is.Not.Null.And.Not.Empty);
            Assert.That(oNewMarketData.Timestamp, Is.Not.EqualTo(default(long)));
        }

        [Test]
        [Timeout(10000)]
        public async Task SubscriptionToMarketDataCanBeCancelled()
        {
            // Get a dollar future
            List<Instrument> instruments = RestAPI.GetInstruments().instruments;
            var instrument = instruments.Last( i => i.instrumentId.symbol == Build.DollarFutureSymbol() );

            // Subscribe to bids and offers
            var entries = new[] { Entry.Bids, Entry.Offers };

            // Used to cancel the task
            using var cancellationSource = new CancellationTokenSource();

            // Create and start the web socket
            using var socket = WebSocketAPI.CreateMarketDataSocket(new[] { instrument.instrumentId }, entries, 1, 1, cancellationSource.Token);
            Assert.That(!socket.IsRunning);

            var socketTask = await socket.Start();

            // Wait until it is running
            while (!socket.IsRunning)
            {
                Thread.Sleep(10);
            }

            cancellationSource.Cancel();

            try
            {
                await socketTask;
                Assert.Fail();
            }
            catch (OperationCanceledException)
            {
                Assert.That(!socket.IsRunning);
            }
        }

        public static Entry[] AllEntries = { 
            Entry.Bids,
            Entry.Offers,
            Entry.Last,
            Entry.Open,
            Entry.Close,
            Entry.SettlementPrice,
            Entry.SessionHighPrice,
            Entry.SessionLowPrice,
            Entry.Volume,
            Entry.OpenInterest,
            Entry.IndexValue,
            Entry.EffectiveVolume,
            Entry.NominalVolume
        };
    }
}
