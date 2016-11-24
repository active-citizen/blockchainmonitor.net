using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataModels.Aggregated;
using BlockchainMonitor.DataModels.Blockchain;
using Newtonsoft.Json;
using BlockchainMonitor.DataModels.Participants;
using Newtonsoft.Json.Converters;

namespace BlockchainMonitor.RedisClient
{
    public class Repository : IRepository
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        public const string LastTransactions = "lastTransactions";
        public const string LastBlocks = "lastBlocks";
        public const string AliveParticipants = "aliveParticipants";
        public const string DeadParticipants = "deadParticipants";
        public Repository(ConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public int GetStatisticsIntValue(StatisticsKey key)
        {
            string value = GetStatisticsValue(key);

            int result;
            return Int32.TryParse(value, out result) ? result : 0;
        }

        public double GetStatisticsDoubleValue(StatisticsKey key)
        {
            string value = GetStatisticsValue(key);

            int result;
            return Int32.TryParse(value, out result) ? result : 0;
        }

        string GetStatisticsValue(StatisticsKey key)
        {
            IDatabase data = _connectionMultiplexer.GetDatabase();

            var value = data.StringGet(
                Enum.GetName(typeof(StatisticsKey), key));

            return value;
        }

        public void SetStatisticsValue(StatisticsKey key, int value)
        {
            SetStatisticsValue(key, value.ToString());
        }

        public void SetStatisticsValue(StatisticsKey key, double value)
        {
            SetStatisticsValue(key, value.ToString());
        }

        public void SetStatisticsValue(StatisticsKey key, string value)
        {
            IDatabase data = _connectionMultiplexer.GetDatabase();

            data.StringSet(key.ToString(), value);
        }

        public List<Transaction> GetLastTransactions()
        {
            return GetObject<List<Transaction>>(LastTransactions);
        }

        public void SetLastTransactions(List<Transaction> transactions)
        {
            SetObject(transactions, LastTransactions);
        }

        public List<Block> GetLastBlocks()
        {
            return GetObject<List<Block>>(LastBlocks);
        }

        public void SetLastBlocks(List<Block> blocks)
        {
            SetObject(blocks, LastBlocks);
        }

        public List<Participant> GetParticipants(bool alive)
        {
            return GetObject<List<Participant>>(alive ? AliveParticipants : DeadParticipants);
        }

        public void SetAliveParticipants(List<Participant> participants, bool alive)
        {
            SetObject(participants, alive ? AliveParticipants : DeadParticipants);
        }

        private T GetObject<T>(string key) where T : class
        {
            IDatabase data = _connectionMultiplexer.GetDatabase();

            var json = data.StringGet(key);
            var values = !json.IsNull ? JsonConvert.DeserializeObject<T>(json) : null;

            return values;
        }

        private void SetObject<T>(T obj, string key)
        {
            IDatabase data = _connectionMultiplexer.GetDatabase();

            //var values = (RedisValue)JsonConvert.SerializeObject(obj);

            var values = (RedisValue) JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            data.StringSet(key, values);
        }
    }
}
