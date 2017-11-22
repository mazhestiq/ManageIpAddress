using ManageIPAddresses.Infrastructure.Core.Logging.Logging;
using SimpleInjector;

namespace ManageIPAddresses.Infrastructure.Core.Logging
{
    public static class ContainerExtensions
    {
        public static Container UseManageIpAddressesLog(this Container container)
        {
            container.Register<ILog>(LogProvider.GetCurrentClassLogger);
            return container;
        }
    }
}
