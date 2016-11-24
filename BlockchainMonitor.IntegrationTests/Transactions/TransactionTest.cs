using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.RabbitClient;
using BlockchainMonitor.TestData;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.IntegrationTests.Transactions
{
    class TransactionTest
    {
        //Skip DataCollector and add transactions directly to the RabbitMQ
        public void AddRandomTransactions(int count)
        {
            //IConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            //Publisher rabbit = new Publisher(factory);

            //List<Transaction> transactions = new List<Transaction>();

            //for (int i = 0; i < count; i++) transactions.Add(Examples.RandomTransaction);
            //rabbit.PublishMessage<List<Transaction>>(transactions);
        }
    }
}
