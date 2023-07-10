using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Logging
{
    public static class SerilogExtensions
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure => (context, configuration) =>
        {

        }
    }
}