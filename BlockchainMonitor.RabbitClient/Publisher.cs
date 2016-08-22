using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using BlockchainMonitor.DataModels.Blockchain;
using Newtonsoft.Json;

namespace BlockchainMonitor.RabbitClient
{
    public class Publisher : BaseClient, IPublisher
    {
        private readonly IConnectionFactory _factory;
        public Publisher(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public void AddTransaction(Transaction transaction)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    EnsureQueue(channel, _blockchainTransaction);

                    string json = JsonConvert.SerializeObject(transaction);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(   exchange: "",
                                            routingKey: _blockchainTransaction,
                                            basicProperties: null,
                                            body: body);
                }
            }
        }
    }
}
