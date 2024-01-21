using Microsoft.Extensions.Hosting;
using Serilog;

namespace Logging
{
    public static class LoggingExtension
    {
        public static IHostBuilder UseLogging(this IHostBuilder webHostBuilder)
            => webHostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(context.Configuration);
                loggerConfiguration.Enrich.With<UserLogEnricher>();
            });
    }
}
