using Common.Logging;
using Serilog;

namespace BasketService.Extensions
{
	public static class HostExtensions
	{
		public static void AddAppConfigurations(this ConfigureHostBuilder host)
		{
			host.UseSerilog(SerilogExtensions.Configure);
        }
	}
}

