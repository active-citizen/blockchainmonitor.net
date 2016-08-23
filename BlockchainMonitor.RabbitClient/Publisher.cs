using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using BlockchainMonitor.DataModels.Blockchain;
using Newtonsoft.Json;
using BlockchainMonitor.RabbitClient.Model;

namespace BlockchainMonitor.RabbitClient
{
    public class Publisher : BaseClient, IPublisher
    {
        private readonly IConnectionFactory _factory;
        public Publisher(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public void PublishMessage<T>(T obj)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    EnsureQueue(channel, _blockchainQueue);

                    var message = new RabbitMessage
                    {
                        JsonObject = JsonConvert.SerializeObject(obj),
                        ObjType = typeof(T),
                    };

                    var json = JsonConvert.SerializeObject(message);

                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(   exchange: "",
                                            routingKey: _blockchainQueue,
                                            basicProperties: null,
                                            body: body);
                }
            }
        }
    }
}
