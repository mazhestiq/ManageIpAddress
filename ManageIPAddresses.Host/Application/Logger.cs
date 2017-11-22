using Serilog;

namespace ManageIPAddresses.Host.Application
{
    public static class Logger
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
        }
    }
}