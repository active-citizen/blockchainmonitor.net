using Autofac;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RedisClient.AutofacModules
{
    public class RedisClientModule : Module
    {
        readonly string _host;
        public RedisClientModule(string host)
        {
            _host = host;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository>().As<IRepository>();
            builder.RegisterType<Subscriber>().As<ISubscriber>().SingleInstance();
            builder.RegisterInstance(ConnectionMultiplexer.Connect(_host));
        }
    }
}
