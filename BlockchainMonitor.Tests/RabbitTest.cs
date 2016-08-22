using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainMonitor.Tests.Data;
using BlockchainMonitor.DataModels.Blockchain;
using RabbitMQ.Client;
using BlockchainMonitor.RabbitClient;
using System.Threading.Tasks;

namespace BlockchainMonitor.Tests
{
    [TestClass]
    public class RabbitTest
    {
        Transaction _transaction = null;

        [TestMethod]
        public void PublishTransaction()
        {
            Transaction tr = Examples.RandomTransaction;
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost"};

            Publisher publisher = new Publisher(factory);
            publisher.AddTransaction(tr);

            Subscriber subscriber = new Subscriber(factory);
            subscriber.TransactionReceived += Subscriber_TransactionReceived;

            _transaction = null;
            Task task = subscriber.Start();
            task.Start();
            task.Wait(10000);
            Assert.IsNotNull(_transaction);
        }

        private void Subscriber_TransactionReceived(Transaction transaction)
        {
            _transaction = transaction;
        }
    }
}
