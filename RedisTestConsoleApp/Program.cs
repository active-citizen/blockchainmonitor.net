using BlockchainMonitor.RedisClient;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataModels.Aggregated;
using BlockchainMonitor.DataModels.Blockchain;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using Type = BlockchainMonitor.DataModels.Blockchain.Type;

namespace RedisTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationOptions config = new ConfigurationOptions();
            var m = ConnectionMultiplexer.Connect("localhost");

            Repository rep = new Repository(m);

            rep.SetStatisticsValue(StatisticsKey.BlocksCount, 1);

            Console.WriteLine(rep.GetStatisticsIntValue(StatisticsKey.BlocksCount));

            Transaction tr1 = new Transaction()
            {
                Payload = "fgdf45bq57dfghdd79fg86d7fgs568g6",
                Timestamp = DateTime.Now,
                TxID = "as6ds6g-" + DateTime.Now.Ticks + "-s7d6f8",
                ChaincodeID = "s8d5f6s6fa6s5f8sa7065sf5as86dfa6s8d5f",
                BlockId = 1,
                Type = Type.CHAINCODE_DEPLOY
            };
            Transaction tr2 = new Transaction()
            {
                Payload = "fgdf45bq57dfghdd79fg86d7fgs568g6",
                Timestamp = DateTime.Now,
                TxID = "as6ds6g-" + DateTime.Now.Ticks + "-s7d6f8",
                ChaincodeID = "s8d5f6s6fa6s5f8sa7065sf5as86dfa6s8d5f",
                BlockId = 1,
                Type = Type.CHAINCODE_DEPLOY
            };

            var list = new List<Transaction> { tr1, tr2 };
            Console.WriteLine(JsonConvert.SerializeObject(list));

            rep.SetLastTransactions(list);
            list = rep.GetLastTransactions();

            Console.WriteLine(JsonConvert.SerializeObject(list));

            Console.ReadLine();
        }
    }
}
