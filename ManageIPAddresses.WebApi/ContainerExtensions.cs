using ManageIPAddresses.Service.Implementation;
using SimpleInjector;

namespace ManageIPAddresses.WebApi
{
    public static class ContainerExtensions
    {
        public static Container UseManageIpAddressesApi(this Container container)
        {
            container.UseService();

            return container;
        }
    }
}