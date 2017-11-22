using AutoMapper;
using ManageIPAddresses.Infrastructure.Core;
using ManageIPAddresses.WebApi;
using SimpleInjector;

namespace ManageIPAddresses.Host.Application
{
    public static class IoC
    {
        public static Container Create(MapperConfiguration mapper)
        {
            var container = new Container();

            container.UseManageIpAddressesInfrastructure(mapper);
            container.UseManageIpAddressesApi();

            return container;
        }
    }
}