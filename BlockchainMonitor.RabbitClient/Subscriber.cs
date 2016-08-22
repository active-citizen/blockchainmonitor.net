using BlockchainMonitor.DataModels.Blockchain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockchainMonitor.RabbitClient
{
    public class Subscriber : BaseClient, ISubscriber
    {
        private readonly IConnectionFactory _factory;
        public Subscriber(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public Task Start()
        {
            Task task = new Task(() =>
            {
                using (var connection = _factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        EnsureQueue(channel, _blockchainTransaction);

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            string json = Encoding.UTF8.GetString(body);
                            var transaction = JsonConvert.DeserializeObject<Transaction>(json);

                            TransactionReceived(transaction);
                        };
                        Thread.Sleep(10000000);
                    }
                }
            });
            return task;
        }

        public delegate void GetTransactionDelegate(Transaction transaction);

        public event GetTransactionDelegate TransactionReceived;
    }
}
