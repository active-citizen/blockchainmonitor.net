using Autofac;
using BlockchainMonitor.RabbitClient.AutofacModules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.DataAggregator
{
    public partial class DataAggregatorService : ServiceBase
    {
        IContainer _container;
        public DataAggregatorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new RabbitClientModule());

            _container = builder.Build();
        }

        protected override void OnStop()
        {
        }
    }
}
