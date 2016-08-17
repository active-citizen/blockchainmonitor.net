using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlockchainMonitor.WebUI.Startup))]
namespace BlockchainMonitor.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = RegisterDependencies(app);

            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
