using AutoMapper;
using ManageIPAddresses.InternalSystem.Implementation;
using ManageIPAddresses.Service.Contracts.Data;
using ManageIPAddresses.Service.Contracts.Services;
using ManageIPAddresses.Service.Implementation.Services;
using SimpleInjector;

namespace ManageIPAddresses.Service.Implementation
{
    public static class ContainerExtensions
    {
        public static Container UseService(this Container container)
        {
            container.Register<IIpAddressManagerService, IpAddressManagerService>();

            container.UseInternalSystem();

            return container;
        }

        public static void ConfigureServiceMapping(this IMapperConfigurationExpression config)
        {
            config.CreateMap<IpAddress, InternalSystem.Contracts.Data.IpAddress>();
        }
    }
}
