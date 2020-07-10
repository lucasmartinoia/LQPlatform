using System;
using System.Threading;
using Newtonsoft.Json;
using LatamQuants.PrimaryAPI.Models.Websocket;
using LatamQuants.PrimaryAPI.WebSocket.Net;

namespace LatamQuants.PrimaryAPI.WebSocket
{
    public struct Request
    {
        [JsonProperty("type", Order=-2)]
        public string Type => "os";

        [JsonProperty("accounts")]
        public OrderStatus.AccountId[] Accounts;
    }

    public struct Response
    {
        [JsonProperty("orderReport")]
        public OrderStatus OrderReport;

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class OrderDataWebSocket : WebSocket<Request, Response>
    {
        internal OrderDataWebSocket(Request orderDataToRequest, Uri url, string accessToken,
                                    CancellationToken cancelToken)
        : 
        base(orderDataToRequest, url, accessToken, cancelToken)
        {}
    }
}
