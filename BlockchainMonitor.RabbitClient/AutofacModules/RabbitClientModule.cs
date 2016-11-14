using Autofac;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using IConnectionFactory = RabbitMQ.Client.IConnectionFactory;
using Module = Autofac.Module;

namespace BlockchainMonitor.RabbitClient.AutofacModules
{
    public class RabbitClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterInstance(new ConnectionFactory()
            //{
            //    HostName = ConfigurationManager.AppSettings["rabbitHost"],
            //    AutomaticRecoveryEnabled = true,
            //    NetworkRecoveryInterval = new TimeSpan(10000),
            //}
            //).As<IConnectionFactory>();

            builder.RegisterInstance(RabbitHutch.CreateBus().Advanced).As<IAdvancedBus>();
            
            builder.RegisterType<Publisher>().As<IPublisher>();
            builder.RegisterType<Subscriber>().As<ISubscriber>();
        }
    }
}
