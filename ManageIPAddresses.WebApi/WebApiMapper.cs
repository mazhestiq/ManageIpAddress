using AutoMapper;
using ManageIPAddresses.Service.Contracts.Data;
using ManageIPAddresses.Service.Implementation;
using ManageIPAddresses.WebApi.Models;

namespace ManageIPAddresses.WebApi
{
    public static class WebApiMapper
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<IpAddressModel, IpAddress>();

            config.ConfigureServiceMapping();

            UseManageIpAddressesApiMapping(config);
        }

        private static void UseManageIpAddressesApiMapping(IMapperConfigurationExpression config)
        {
            config.AddProfiles(typeof(WebApiMapper).Assembly);
        }
    }
}
