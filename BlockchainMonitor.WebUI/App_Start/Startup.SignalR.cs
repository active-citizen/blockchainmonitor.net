using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BlockchainMonitor.WebUI
{
    public partial class Startup
    {
        void ConfigureSignalR(IAppBuilder app)
        {
            app.MapSignalR();

            var serializer =
                JsonSerializer.Create(new JsonSerializerSettings()
                {
                    ContractResolver = new SignalRContractResolver()
                });

            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), 
                () => serializer);

        }

        internal class SignalRContractResolver : IContractResolver
        {
            private readonly IContractResolver _defaultContractResolver;
            private readonly IContractResolver _camelContractResolver;
            private readonly Assembly _assembly;
            public SignalRContractResolver()
            {
                _defaultContractResolver = new DefaultContractResolver();
                _camelContractResolver = new CamelCasePropertyNamesContractResolver();
                _assembly = typeof(Connection).Assembly;
            }

            public JsonContract ResolveContract(Type type)
            {
                if (type.Assembly.Equals(_assembly))
                {
                    return _defaultContractResolver.ResolveContract(type);
                }
                else
                {
                    return _camelContractResolver.ResolveContract(type);
                }
            }
        }
    }
}