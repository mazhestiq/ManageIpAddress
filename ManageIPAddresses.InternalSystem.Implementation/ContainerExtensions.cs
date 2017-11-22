using ManageIPAddresses.InternalSystem.Contracts.Services;
using ManageIPAddresses.InternalSystem.Implementation.NetServices;
using SimpleInjector;

namespace ManageIPAddresses.InternalSystem.Implementation
{
    public static class ContainerExtensions
    {
        public static Container UseInternalSystem(this Container container)
        {
            container.Register<IIpAddressManagerSystem, IpAddressManagerSystem>();

            return container;
        }
    }
}
