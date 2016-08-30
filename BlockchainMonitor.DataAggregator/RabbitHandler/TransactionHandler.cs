using BlockchainMonitor.DataAccess.Context;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.RabbitClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.RedisClient;

namespace BlockchainMonitor.DataAggregator.RabbitHandler
{
    public class TransactionHandler : MessageHandlerBase<List<Transaction>>
    {
        private readonly IBlockchainDbContext _database;
        private readonly IRepository _redis;
        public TransactionHandler(IBlockchainDbContext context, IRepository redis)
        {
            _database = context;
            _redis = redis;
        }

        public override void Handle(List<Transaction> transactions)
        {
            var newTransactions = transactions.Where(
                t => _database.Transactions.GetById(t.Id) == null).ToList();
            _database.Transactions.Insert(newTransactions);

            var lastTransactions = _database.Transactions.GetAll()
                .OrderByDescending(t => t.Time).Take(10).ToList();

            _redis.SetLastTransactions(lastTransactions);
        }
    }
}
