using System.Reflection;
using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Library.Logging;
public static class CollectionHostBuilderExtensions
{
    public static IHostBuilder UseLogging(this IHostBuilder builder, Assembly assembly) {
        builder.ConfigureLogging(log => {
            log.ClearProviders();
        });
        builder.UseSerilog((HostBuilderContext context, LoggerConfiguration loggerConfig) => {
            loggerConfig.ReadFrom.Configuration(context.Configuration)
            .Enrich.WithProperty("Version", assembly.GetName().Version)
            .Enrich.WithProperty("MachineName", Environment.MachineName);
        });
        return builder;
    }
}
