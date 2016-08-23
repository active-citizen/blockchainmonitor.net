using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataAccess.Context;

namespace BlockchainMonitor.DataAccess.AutofacModules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlockchainDbContext>().As<IBlockchainDbContext>();
        }
    }
}
