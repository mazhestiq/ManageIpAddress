using AutoMapper;
using ManageIPAddresses.WebApi;

namespace ManageIPAddresses.Host.Application
{
    public static class Mapping
    {
        public static MapperConfiguration SetMapping()
        {
            Mapper.Initialize(UseManageIpAddresses);

            return new MapperConfiguration(UseManageIpAddresses);
        }

        private static void UseManageIpAddresses(IMapperConfigurationExpression config)
        {
            WebApiMapper.Configure(config);
        }
    }
}