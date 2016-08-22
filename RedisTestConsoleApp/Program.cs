using BlockchainMonitor.RedisClient;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataModels.Aggregated;
using BlockchainMonitor.DataModels.Blockchain;
using Newtonsoft.Json;

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
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Id = "agjhgkjhgqweruyg",
            };
            Transaction tr2 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Id = "agjhgkjhgasdfasdfruyg",
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
