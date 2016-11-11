using System.Configuration;
using Autofac;
using RabbitMQ.Client;
using RestSharp;

namespace BlockchainMonitor.DataCollector.AutofacModules
{
    public class BlockchainAPIClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new RestClient(ConfigurationManager.AppSettings["host"]))
                .As<IRestClient>();

            builder.RegisterType<BlockchainAPIClient>().As<IBlockchainAPIClient>();
        }
    }
}
