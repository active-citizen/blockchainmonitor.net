using BlockchainMonitor.IntegrationTests.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.IntegrationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args?.Length == 0) return;
            switch (args[0])
            {
                case "add_transactions":
                    var test = new TransactionTest();
                    test.AddRandomTransactions(args.Length > 1 ? Int32.Parse(args[1]) : 3);
                    break;
            }
        }
    }
}
