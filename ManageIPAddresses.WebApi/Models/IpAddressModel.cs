using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace ManageIPAddresses.WebApi.Models
{
    public class IpAddressModel : IValidatableObject
    {
        public string Address { get; set; }
        public string Mask { get; set; }
        public string Gateway { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!IPAddress.TryParse(Address, out var address) || address.AddressFamily != AddressFamily.InterNetwork)
            {
                yield return new ValidationResult("Ip Address is not valid.");
            }

            if (!IPAddress.TryParse(Mask, out var mask) || mask.AddressFamily != AddressFamily.InterNetwork)
            {
                yield return new ValidationResult("Mask is not valid.");
            }

            if (!IPAddress.TryParse(Gateway, out var gateway) || gateway.AddressFamily != AddressFamily.InterNetwork)
            {
                yield return new ValidationResult("Gateway is not valid.");
            }
        }
    }


}
