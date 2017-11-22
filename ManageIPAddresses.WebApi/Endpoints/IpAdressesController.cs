using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using AutoMapper;
using ManageIPAddresses.Infrastructure.Core.Logging.Logging;
using ManageIPAddresses.Service.Contracts.Data;
using ManageIPAddresses.Service.Contracts.Services;
using ManageIPAddresses.WebApi.Models;

namespace ManageIPAddresses.WebApi.Endpoints
{
    [RoutePrefix("api/v1/[controller]")]
    public class IpAdressesController : ApiController
    {
        private readonly ILog _log;
        private readonly IIpAddressManagerService _ipAddressManagerService;

        public IpAdressesController(ILog log, IIpAddressManagerService ipAddressManagerService)
        {
            _ipAddressManagerService = ipAddressManagerService;
            _log = log;
        }

        [HttpPost]
        [Route("Add")]
        [ResponseType(typeof(ProcessResponse))]
        public async Task<IHttpActionResult> Add(IpAddressModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _ipAddressManagerService.AddIpAddress(Mapper.Map<IpAddress>(model));
                    return Ok(response);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _log.FatalException("Failed add Ip Address.", ex);
                return InternalServerError();
            }
        }
        
        [HttpGet]
        [Route("Get")]
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> GetAddresses()
        {
            try
            {
                var addressList = await _ipAddressManagerService.GetIpAddresses();

                return Ok(addressList);
            }
            catch (Exception ex)
            {
                _log.FatalException("Failed get ipAddress.", ex);
                return InternalServerError();
            }
        }
    }
}
