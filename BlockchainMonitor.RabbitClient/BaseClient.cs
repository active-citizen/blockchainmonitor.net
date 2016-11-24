using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;

namespace BlockchainMonitor.RabbitClient
{
    public abstract class BaseClient
    {
        protected const string _blockchainQueue = "Blockchain.Main";

        protected void EnsureQueue(IModel channel, string queueName)
        {
            channel.QueueDeclare(queue: queueName,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }

        protected void EnsureQueue(IAdvancedBus bus, string queueName)
        {
            bus.QueueDeclare(name: queueName, durable: true, exclusive: false, autoDelete: false);
        }
    }
}
