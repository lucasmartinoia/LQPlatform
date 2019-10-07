using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace LQ.Support.Config
{
    public class MessageReceivedArgs : EventArgs
    {
        public string Message { get; set; }
    }
    public class RabbitService
    {
        private string Queue = "";
        public event EventHandler<MessageReceivedArgs> MessageReceived;
        public RabbitService(string sQueueName)
        {
            Queue = sQueueName;
            //    Read();
        }
        public void SendMessage(Int32 OjectId)
        {
            var factory = new ConnectionFactory()
            {
               
                //HostName = "127.0.0"
           //     Port=5572,
                HostName = "localhost",
                RequestedHeartbeat = 60,
                //Ssl =
                //{
                //    ServerName ="localhost",
                //    Enabled = false
                //}

            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //IBasicProperties basicProperties = channel.CreateBasicProperties();
                //basicProperties.Persistent = true;//
                //basicProperties.DeliveryMode = 2;

                channel.QueueDeclare(queue: Queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = OjectId.ToString();

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: Queue,
                                     basicProperties: null,
                                     body: body);
              //  //Console.WriteLine(" [x] Sent {0}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
            }
        }
        public  void SendMessage<T>(T param)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //IBasicProperties basicProperties = channel.CreateBasicProperties();
                //basicProperties.Persistent = true;//
                //basicProperties.DeliveryMode = 2;

                channel.QueueDeclare(queue: Queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

               // T value = default(T);
                string message = JsonConvert.SerializeObject(param);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: Queue,
                                     basicProperties: null,
                                     body: body);
            }
        }
        public void ReceiveMessage()
        {
            string message = "";
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: Queue,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        message = Encoding.UTF8.GetString(body);
                        MessageReceivedArgs args = new MessageReceivedArgs();
                        args.Message = message;
                        MessageReceived(this, args);
                  //      channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                        //      orderFund = JsonConvert.DeserializeObject<OrderFund>(message);
                        //orderFund = (OrderFund)JsonConvert.DeserializeObject(valor);
                    };
                    channel.BasicConsume(queue: Queue,autoAck: true,consumer: consumer);
                    Console.ReadLine();
                }
            }
        }
        //public T ReceiveMessage<T>()
        //{
        //    T value = default(T);
        //    var factory = new ConnectionFactory()
        //    {
        //        HostName = "localhost"
        //    };
        //    using (var connection = factory.CreateConnection())
        //    {
        //        using (var channel = connection.CreateModel())
        //        {
        //            channel.QueueDeclare(queue: Queue,
        //                                 durable: false,
        //                                 exclusive: false,
        //                                 autoDelete: false,
        //                                 arguments: null);
        //            var consumer = new EventingBasicConsumer(channel);
        //            consumer.Received += (model, ea) =>
        //            {
        //                var body = ea.Body;
        //                var message= Encoding.UTF8.GetString(body);
        //                value = JsonConvert.DeserializeObject<T>(message);
        //            };
        //            channel.BasicConsume(queue: Queue,
        //                                 autoAck: true,
        //                                 consumer: consumer);
        //        }
        //    }
        //    return value;
        //}
    }
}
