using Autofac;
using Autofac.Integration.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using BlockchainMonitor.Infrastructure.AutofacModules;
using System.Web.Mvc;
using System.Web.Http;
using BlockchainMonitor.WebUI.Initialization;

namespace BlockchainMonitor.WebUI
{
    public partial class Startup
    {
        public IContainer RegisterDependencies(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var contentProviderModule = new BlockchainProvidersModule();
            builder.RegisterModule(contentProviderModule);

            AutoMapperInitializer.Initialize(builder, app);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMvc();

            return container;
        }
    }
}