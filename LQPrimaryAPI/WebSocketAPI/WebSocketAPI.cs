using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Linq;
using Newtonsoft.Json;
using LatamQuants.PrimaryAPI.Models;
using LatamQuants.PrimaryAPI.Models.Websocket;
using System.Reflection;
using ServiceStack;
using System.Threading;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI.WebSocket;

namespace LatamQuants.PrimaryAPI
{
    public static class WebSocketAPI
    {
        public static Uri baseUri;
        public static string accessToken;

        /// <summary>
        /// Create a Market Data web socket to receive real-time market data.
        /// </summary>
        /// <param name="instruments">Instruments to watch.</param>
        /// <param name="entries">Market data entries to watch.</param>
        /// <param name="level"></param>
        /// <param name="depth">Depth of the book.</param>
        /// <param name="cancellationToken">Custom cancellation token to end the socket task.</param>
        /// <returns>The market data web socket.</returns>
        public static MarketDataWebSocket CreateMarketDataSocket(IEnumerable<Models.InstrumentId> instruments,
                                                          IEnumerable<Entry> entries,
                                                          uint level, uint depth,
                                                          CancellationToken cancellationToken
        )
        {
            var wsScheme = (baseUri.Scheme == "https" ? "wss" : "ws");
            var url = new UriBuilder(baseUri) { Scheme = wsScheme };

            var marketDataToRequest = new MarketDataInfo()
            {
                Depth = depth,
                Entries = entries.ToArray(),
                Level = level,
                Products = instruments.ToArray()
            };

            return new MarketDataWebSocket(marketDataToRequest, url.Uri, accessToken, cancellationToken);
        }

        /// <summary>
        /// Create a Order Data web socket to receive real-time orders data.
        /// </summary>
        /// <param name="accounts">Accounts to get order events from.</param>
        /// <returns>The order data web socket.</returns>
        public static OrderDataWebSocket CreateOrderDataSocket(IEnumerable<string> accounts)
        {
            return CreateOrderDataSocket(accounts, new CancellationToken());
        }

        /// <summary>
        /// Create a Market Data web socket to receive real-time market data.
        /// </summary>
        /// <param name="accounts">Accounts to get order events from.</param>
        /// <param name="cancellationToken">Custom cancellation token to end the socket task.</param>
        /// <returns>The order data web socket.</returns>
        public static OrderDataWebSocket CreateOrderDataSocket(IEnumerable<string> accounts,
                                                        CancellationToken cancellationToken
        )
        {
            var wsScheme = (baseUri.Scheme == "https" ? "wss" : "ws");
            var url = new UriBuilder(baseUri) { Scheme = wsScheme };

            var request = new Request
            {
                Accounts = accounts.Select(a => new Models.Websocket.OrderStatus.AccountId() { Id = a }).ToArray()
            };

            return new OrderDataWebSocket(request, url.Uri, accessToken, cancellationToken);
        }
    }
}