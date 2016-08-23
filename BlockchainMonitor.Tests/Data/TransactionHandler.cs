using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.RabbitClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.Tests.Data
{
    class TransactionHandler : IMessageHandler<Transaction>
    {
        public void Handle(Transaction message)
        {
            Transactions.Add(message);
        }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
