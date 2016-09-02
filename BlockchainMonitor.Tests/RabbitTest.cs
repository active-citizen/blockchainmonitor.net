using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainMonitor.Tests.Data;
using BlockchainMonitor.DataModels.Blockchain;
using RabbitMQ.Client;
using BlockchainMonitor.RabbitClient;
using System.Threading.Tasks;
using Autofac;
using System.Threading;
using System.Collections.Generic;
using BlockchainMonitor.TestData;

namespace BlockchainMonitor.Tests
{
    [TestClass]
    public class RabbitTest
    {
        ConnectionFactory _factory = new ConnectionFactory() { HostName = "localhost" };
        [TestInitialize]
        void Initialize()
        {
        }

        [TestMethod]
        public void PublishTransaction()
        {
            List<Transaction> trs = new List<Transaction>
            {
                Examples.RandomTransaction,
                Examples.RandomTransaction,
                Examples.RandomTransaction,
            };

            Publisher publisher = new Publisher(_factory);
            publisher.PublishMessage(trs);
        }

        [TestMethod]
        public void PublishAndRecieveTransaction()
        {
            PublishTransaction();

            var builder = new ContainerBuilder();
            var handler = new TransactionHandler();
            builder.RegisterInstance(handler).As<IMessageHandler<Transaction>>();
            var container = builder.Build();

            Subscriber subscriber = new Subscriber(_factory, container);
            subscriber.Start();
            Thread.Sleep(10000);

            Assert.IsNotNull(handler.Transactions.Count > 0);
        }
    }
}
