using System.Web.Http;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Lifestyles;

namespace ManageIPAddresses.Host.Application
{
    public static class OwinExtensions
    {
        public static IAppBuilder UseManageIpAddresses(this IAppBuilder app, HttpConfiguration applicationConfiguration,
            Container container)
        {
            AsyncScopedLifestyle.BeginScope(container);

            app.UseWebApi(applicationConfiguration);
            return app;
        }
    }
}