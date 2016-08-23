using Autofac;
using BlockchainMonitor.DataAccess.Context;
using BlockchainMonitor.Infrastructure.Provider;
using BlockchainMonitor.RedisClient.AutofacModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.Infrastructure.AutofacModules
{
    public class BlockchainProvidersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlockchainProvider>().As<IBlockchainProvider>();
            builder.RegisterType<BlockchainDbContext>().As<IBlockchainDbContext>();
        }
    }
}
