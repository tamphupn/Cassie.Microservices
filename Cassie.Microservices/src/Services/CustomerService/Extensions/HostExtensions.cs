using Common.Logging;
using Serilog;

namespace CustomerService.Extensions
{
	public static class HostExtensions
	{
		public static void AddAppConfigurations(this ConfigureHostBuilder host)
		{
            host.UseSerilog(SerilogExtensions.Configure);
        }
	}
}