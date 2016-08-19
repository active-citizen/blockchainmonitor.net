using Autofac;
using BlockchainMonitor.Infrastructure.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.Infrastructure.AutofacModules
{
    public class ParticipantMonitorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ParticipantMonitor>().As<IParticipantMonitor>();
        }
    }
}
