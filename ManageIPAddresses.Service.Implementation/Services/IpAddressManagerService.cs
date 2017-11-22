using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ManageIPAddresses.InternalSystem.Contracts.Services;
using ManageIPAddresses.Service.Contracts.Data;
using ManageIPAddresses.Service.Contracts.Services;
using SysData = ManageIPAddresses.InternalSystem.Contracts.Data;

namespace ManageIPAddresses.Service.Implementation.Services
{
    public class IpAddressManagerService : IIpAddressManagerService
    {
        private readonly IIpAddressManagerSystem _ipAddressManagerSystem;

        public IpAddressManagerService(IIpAddressManagerSystem ipAddressManagerSystem)
        {
            _ipAddressManagerSystem = ipAddressManagerSystem;
        }

        public async Task<ProcessResponse> AddIpAddress(IpAddress ipAddress)
        {
            var response = await _ipAddressManagerSystem.AddIpAddress(Mapper.Map<SysData.IpAddress>(ipAddress));

            return Mapper.Map<ProcessResponse>(response);
        }
        
        public async Task<IEnumerable<string>> GetIpAddresses()
        {
            return await _ipAddressManagerSystem.GetIpAddresses();
        }
    }
}
