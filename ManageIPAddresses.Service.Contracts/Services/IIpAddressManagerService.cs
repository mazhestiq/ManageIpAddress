using System.Collections.Generic;
using System.Threading.Tasks;
using ManageIPAddresses.Service.Contracts.Data;

namespace ManageIPAddresses.Service.Contracts.Services
{
    public interface IIpAddressManagerService
    {
        Task<ProcessResponse> AddIpAddress(IpAddress ipAddress);
        Task<IEnumerable<string>> GetIpAddresses();
    }
}
