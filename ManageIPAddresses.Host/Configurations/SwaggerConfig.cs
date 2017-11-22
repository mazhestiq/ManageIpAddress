using System.Web.Http;
using Swashbuckle.Application;

namespace ManageIPAddresses.Host.Configurations
{
    public static class SwaggerConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            configuration
                .EnableSwagger( c => {c.SingleApiVersion("v1", "Manage Ip Addresses REST API (Internal only)"); })
                .EnableSwaggerUi();
        }
    }
}