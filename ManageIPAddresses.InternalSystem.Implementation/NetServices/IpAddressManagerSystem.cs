using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ManageIPAddresses.Infrastructure.Core.Messages.Exceptions;
using ManageIPAddresses.InternalSystem.Contracts.Data;
using ManageIPAddresses.InternalSystem.Contracts.Services;

namespace ManageIPAddresses.InternalSystem.Implementation.NetServices
{
    public class IpAddressManagerSystem : IIpAddressManagerSystem
    {
        public async Task<ProcessResponse> AddIpAddress(IpAddress ipAddress)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo("netsh",
                    // netsh int ip add addr 1 10.10.10.10
                    $"interface ip set address \"Local Area Connection\" static {ipAddress.Address} {ipAddress.Mask} {ipAddress.Gateway} 1")
                {
                    Verb = "runas"
                }
            };
            process.Start();
            process.WaitForExit(1000);

            if (process.HasExited)
            {
                return await Task.FromResult(new ProcessResponse
                {
                    ExitCode = process.ExitCode,
                    Message = process.ExitCode == 0 ? "Address was added." : "Failed add address."
                });
            }

            process.Close();

            throw new ProcessException("Failed add address, process was terminated.");
        }
        
        public async Task<IEnumerable<string>> GetIpAddresses()
        {
            var server = Dns.GetHostName();

            var heserver = Dns.GetHostEntry(server);

            return await Task.FromResult(heserver.AddressList.Where(x=>x.AddressFamily == AddressFamily.InterNetwork).Select(t => t.ToString()));
        }
    }
}
