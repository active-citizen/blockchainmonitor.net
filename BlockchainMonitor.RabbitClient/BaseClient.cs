using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RabbitClient
{
    public abstract class BaseClient
    {
        protected const string _blockchainTransaction = "Blockchain.Transaction";

        protected void EnsureQueue(IModel channel, string queueName)
        {
            channel.QueueDeclare(   queue: queueName,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }
    }
}
