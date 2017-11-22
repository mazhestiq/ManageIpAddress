using AutoMapper;
using ManageIPAddresses.Infrastructure.Core.Logging;
using SimpleInjector;

namespace ManageIPAddresses.Infrastructure.Core
{
    public static class ContainerExtensions
    {
        public static Container UseManageIpAddressesInfrastructure(this Container container, MapperConfiguration mapperConfiguration)
        {
            container.UseManageIpAddressesLog();
            container.RegisterSingleton(mapperConfiguration);
            container.Register(() => mapperConfiguration.CreateMapper(container.GetInstance));

            return container;
        }
    }
}
