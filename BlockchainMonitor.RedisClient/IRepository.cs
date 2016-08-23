using BlockchainMonitor.DataModels.Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RedisClient
{
    public interface IRepository
    {
        void SetLastTransactions(List<Transaction> transactions);
        List<Transaction> GetLastTransactions();
    }
}
