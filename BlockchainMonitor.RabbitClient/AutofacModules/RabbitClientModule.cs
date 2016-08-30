﻿using Autofac;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RabbitClient.AutofacModules
{
    public class RabbitClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new ConnectionFactory()
            {
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = new TimeSpan(10000),
            }
            ).As<IConnectionFactory>();

            builder.RegisterType<Publisher>().As<IPublisher>();
            builder.RegisterType<Subscriber>().As<ISubscriber>();
        }
    }
}
