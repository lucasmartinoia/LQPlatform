using System;
using System.Threading;
using LatamQuants.PrimaryAPI.WebSocket.Net;
using LatamQuants.PrimaryAPI.Models;

namespace LatamQuants.PrimaryAPI.WebSocket
{
    public class MarketDataWebSocket : WebSocket<MarketDataInfo, MarketData>
    {
        internal MarketDataWebSocket(MarketDataInfo marketDataToRequest, Uri url, string accessToken,
                                     CancellationToken cancelToken)
        : 
        base(marketDataToRequest, url, accessToken, cancelToken)
        {}
    }
}
