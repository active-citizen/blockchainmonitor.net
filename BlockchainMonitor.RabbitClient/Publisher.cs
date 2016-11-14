using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataModels.Blockchain;
using Newtonsoft.Json;
using BlockchainMonitor.RabbitClient.Model;
using EasyNetQ;
using EasyNetQ.Topology;
using IConnectionFactory = RabbitMQ.Client.IConnectionFactory;

namespace BlockchainMonitor.RabbitClient
{
    public class Publisher : BaseClient, IPublisher
    {
        //private readonly IConnectionFactory _factory;

        private readonly IAdvancedBus _bus;

        public Publisher(IAdvancedBus bus)
        {
            //_factory = factory;
            _bus = bus;
        }

        public void PublishMessage<T>(T obj)
        {
            //using (var connection = _factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        EnsureQueue(channel, _blockchainQueue);

            //        var message = new RabbitMessage
            //        {
            //            JsonObject = JsonConvert.SerializeObject(obj),
            //            ObjType = typeof(T),
            //        };

            //        var json = JsonConvert.SerializeObject(message);

            //        var body = Encoding.UTF8.GetBytes(json);
            //        var properties = channel.CreateBasicProperties();
            //        properties.Persistent = true;

            //        channel.BasicPublish(   exchange: "",
            //                                routingKey: _blockchainQueue,
            //                                basicProperties: properties,
            //                                body: body);
            //    }
            //}

            var message = new RabbitMessage
            {
                JsonObject = JsonConvert.SerializeObject(obj),
                ObjType = typeof(T),
            };

            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);

            var properties = new MessageProperties();

            _bus.Publish(Exchange.GetDefault(), _blockchainQueue, false, properties, body);

            //_bus.Dispose();
        }
    }
}
