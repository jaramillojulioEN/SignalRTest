using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Cors;

[assembly: OwinStartup(typeof(signal_test.Startup1))]

namespace signal_test
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = PolicyResolver
                }
            });
            app.MapSignalR();
        }

        private static Task<CorsPolicy> PolicyResolver(IOwinRequest request)
        {
            var corsPolicy = new CorsPolicy
            {
                Methods = { "GET", "POST", "PUT", "DELETE", "OPTIONS" },
                Headers = { "Accept", "Content-Type", "Authorization", "Cache-Control", "Pragma", "Origin" },
                Origins = { "http://127.0.0.1:5500", "http://localhost:3000" },
                SupportsCredentials = true
            };

            return Task.FromResult(corsPolicy);
        }
    }
}
