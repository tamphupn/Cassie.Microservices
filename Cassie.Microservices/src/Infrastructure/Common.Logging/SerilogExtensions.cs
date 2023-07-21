using Cassie.Shared.Constants;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Logging
{
    public static class SerilogExtensions
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure => (context, configuration) =>
        {
            var applicationName = context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-");
            var environmentName = context.HostingEnvironment.EnvironmentName ?? "Development";

            configuration
            .WriteTo.Debug()
            .WriteTo.Console(outputTemplate: Config.LOG_TEMPLATE)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithProperty("Environment", environmentName)
            .Enrich.WithProperty("Application", applicationName)
            .ReadFrom.Configuration(context.Configuration);
        };
    }
}