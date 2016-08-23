using Autofac;
using BlockchainMonitor.DataAccess.AutofacModules;
using BlockchainMonitor.RabbitClient.AutofacModules;
using BlockchainMonitor.RedisClient.AutofacModules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.RabbitClient;
using BlockchainMonitor.DataAggregator.RabbitHandler;

namespace BlockchainMonitor.DataAggregator
{
    public partial class DataAggregatorService : ServiceBase
    {
        IContainer _container;
        ISubscriber _rabbit;

        public DataAggregatorService()
        {
            InitializeComponent();
        }

        internal void ServiceStartAndStop()
        {
            OnStart(null);
            Console.WriteLine("Started");
            Console.ReadLine();
            OnStop();
            Console.WriteLine("Stopped");
        }

        protected override void OnStart(string[] args)
        {
            RegisterDependencies();
            _rabbit = _container.Resolve<ISubscriber>();
            _rabbit.Start();
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new RabbitClientModule());
            builder.RegisterModule(new DataAccessModule());
            builder.RegisterModule(new RedisClientModule(ConfigurationManager.AppSettings["redisHost"]));

            builder.RegisterType<TransactionHandler>().AsImplementedInterfaces();

            _container = builder.Build();

            var newBuilder = new ContainerBuilder();
            newBuilder.RegisterInstance<IContainer>(_container);
            newBuilder.Update(_container);
        }

        protected override void OnStop()
        {
        }
    }
}
