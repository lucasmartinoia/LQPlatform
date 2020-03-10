using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using System.Security.Authentication;

namespace Huobi.Market.WebSocketAPI
{
    public static class HuobiMarket
    {
        #region 私有属性
        private static WebSocket websocket;
        private static Dictionary<string, string> topicDic = new Dictionary<string, string>();
        private static bool isOpened = false;
        private const string HUOBI_WEBSOCKET_API = "wss://api.huobi.pro/ws";
        #endregion
        #region  市场信息常量
        public const string MARKET_KLINE = "market.{0}.kline.{1}";
        public const string MARKET_DEPTH = "market.{0}.depth.{1}";
        public const string MARKET_TRADE_DETAIL = "market.{0}.trade.detail";
        public const string MARKET_DETAIL = "market.{0}.detail";
        #endregion

        public static event EventHandler<HuoBiMessageReceivedEventArgs> OnMessage;
        public static Func<string, Task> OnMessageReceive { get; set; }
        public static Func<Task> OnConnect { get; set; }
        public static Func<Task> OnDisconnected { get; set; }

        public static bool Init()
        {
            try
            {
                websocket = new WebSocket(HUOBI_WEBSOCKET_API, sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls,receiveBufferSize: 32768);

                websocket.Error += (sender, e) =>
                {
                    //Logger.Error("HuobiWebSocketAPI Error:" + e.Exception.Message.ToString() + " " + e.Exception.StackTrace);
                };

                websocket.DataReceived += ReceviedMsg;
                websocket.Opened += OnOpened;
                websocket.Closed += OnClosed;

                websocket.Open();

            }
            catch (Exception ex)
            {
                //Logger.Error("HuobiWebSocketAPI Error:" + ex.Message.ToString() + " " + ex.StackTrace);
            }
            return true;
        }

        public static bool Init(Func<string, Task> messageCallback, Func<Task> connectCallback = null, Func<Task> disconnectCallback = null)
        {
            bool bReturn = false;

            OnMessageReceive = messageCallback;
            OnConnect = connectCallback;
            OnDisconnected = disconnectCallback; 

            bReturn = Init();

            if(bReturn==true)
            {

            }

            return bReturn;
        }

        //public IWebSocket ConnectWebSocket
        //(
        //    string url,
        //    Func<IWebSocket, byte[], Task> messageCallback,
        //    WebSocketConnectionDelegate connectCallback = null,
        //    WebSocketConnectionDelegate disconnectCallback = null
        //)
        //{
        //    if (messageCallback == null)
        //    {
        //        throw new ArgumentNullException(nameof(messageCallback));
        //    }

        //    string fullUrl = BaseUrlWebSocket + (url ?? string.Empty);
        //    ExchangeSharp.ClientWebSocket wrapper = new ExchangeSharp.ClientWebSocket
        //    {
        //        Uri = new Uri(fullUrl),
        //        OnBinaryMessage = messageCallback
        //    };
        //    if (connectCallback != null)
        //    {
        //        wrapper.Connected += connectCallback;
        //    }
        //    if (disconnectCallback != null)
        //    {
        //        wrapper.Disconnected += disconnectCallback;
        //    }
        //    wrapper.Start();
        //    return wrapper;
        //}


        #region Opened&心跳响应&触发消息事件
        /// <summary>
        /// 连通WebSocket，发送订阅消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnOpened(object sender, EventArgs e)
        {
            //Console.WriteLine($"OnOpened Topics Count:{topicDic.Count}");
            isOpened = true;

            OnConnect?.Invoke();

            foreach (var item in topicDic)
            {
                SendSubscribeTopic(item.Value);
            }

        }

        public static void OnClosed(object sender, EventArgs e)
        {
            isOpened = false;

            // Clear suscriptions
            topicDic = new Dictionary<string, string>();

            OnDisconnected?.Invoke();

            // Try to connect again and to suscribe all topics
            Init();
        }

        /// <summary>
        /// 响应心跳包&接收消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void ReceviedMsg(object sender, DataReceivedEventArgs args)
        {
            //var msg = GZipHelper.GZipDecompressString(args.Data);
            //if (msg.IndexOf("ping") != -1) //响应心跳包
            //{
            //    var reponseData = msg.Replace("ping", "pong");
            //    websocket.Send(reponseData);
            //}
            //else//接收消息
            //{
            //    OnMessage?.Invoke(null, new HuoBiMessageReceivedEventArgs(msg));
            //    OnMessageReceive?.Invoke(msg);
            //}

        }
        #endregion


        #region 订阅相关
        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="id"></param>
        public static void Subscribe(string topic, string id)
        {
            if (topicDic.ContainsKey(topic))
                return;
            var msg = $"{{\"sub\":\"{topic}\",\"id\":\"{id}\"}}";
            topicDic.Add(topic, msg);
            if (isOpened)
            {
                SendSubscribeTopic(msg);
            }
        }


        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="id"></param>

        public static void UnSubscribe(string topic, string id)
        {
            if (!topicDic.ContainsKey(topic) || !isOpened)
                return;
            var msg = $"{{\"unsub\":\"{topic}\",\"id\":\"{id}\"}}";
            topicDic.Remove(topic);
            SendSubscribeTopic(msg);
            //Console.WriteLine($"UnSubscribed, Topics Count:{topicDic.Count}");

        }
        private static void SendSubscribeTopic(string msg)
        {
            websocket.Send(msg);
            //Console.WriteLine(msg);
        }
        #endregion


    }
    /// <summary>
    /// 事件内容
    /// </summary>
    public class HuoBiMessageReceivedEventArgs : EventArgs
    {
        public HuoBiMessageReceivedEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
