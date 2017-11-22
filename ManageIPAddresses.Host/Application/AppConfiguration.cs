using System.Reflection;
using System.Web.Http;
using System.Web.Http.Routing;
using ManageIPAddresses.Host.Configurations;
using ManageIPAddresses.WebApi;
using ManageIPAddresses.WebApi.Endpoints;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace ManageIPAddresses.Host.Application
{
    public static class AppConfiguration
    {
        public static HttpConfiguration Build(Container container)
        {
            var configuration = new HttpConfiguration();

            FormatterConfig.Configure(configuration);
            SwaggerConfig.Configure(configuration);

            container.RegisterWebApiControllers(configuration, Assembly.GetExecutingAssembly(), typeof(IpAdressesController).Assembly);
            container.EnableHttpRequestMessageTracking(configuration);
            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            configuration.MapHttpAttributeRoutes();

            container.Verify();
            return configuration;
        }
    }
}