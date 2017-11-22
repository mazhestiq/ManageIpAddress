using ManageIPAddresses.Host.Application;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ManageIPAddresses.Host.Startup))]
namespace ManageIPAddresses.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Logger.Configure();

            var mapper = Mapping.SetMapping();

            var container = IoC.Create(mapper);

            var configuration = AppConfiguration.Build(container);

            app.UseManageIpAddresses(configuration, container);
        }
    }
}