using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RedisClient
{
    public class Subscriber : ISubscriber
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly StackExchange.Redis.ISubscriber _subscriber;
        const string _redisChannel = "__keyspace@0__:*";
        public Subscriber(ConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _subscriber = _connectionMultiplexer.GetSubscriber();

            Start();
        }

        private void Start()
        {
            _subscriber.Subscribe(_redisChannel, (channel, value) => {
                ChangeValue?.Invoke(channel, value);
            });
        }

        public void Stop()
        {
            _subscriber.Unsubscribe(_redisChannel);
        }      

        public event ChangeValueDelegate ChangeValue;
    }
}
