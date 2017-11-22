using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ManageIPAddresses.InternalSystem.Contracts.Data;

namespace ManageIPAddresses.InternalSystem.Contracts.Services
{
    public interface IIpAddressManagerSystem
    {
        Task<ProcessResponse> AddIpAddress(IpAddress ipAddress);
        Task<IEnumerable<string>> GetIpAddresses();
    }
}
