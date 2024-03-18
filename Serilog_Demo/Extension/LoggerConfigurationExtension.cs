using Serilog;
using Serilog.Events;
using Serilog_Demo.Model;
using System.Globalization;

namespace Serilog_Demo.Extension
{
    public static class LoggerConfigurationExtension
    {
        public static LoggerConfiguration LogWriter(this LoggerConfiguration loggerConfiguration,
            IConfiguration configuration)
        {
            var config = configuration
                .GetSection(SerilogConfiguration.Section)
                .Get<SerilogConfiguration>();

            var basePath = config.BasePath;
            var LogsPath = config.AllLogsPath;
            var errorPath = config.ErrorLogsPath;
            var outputTemplate = config.OutputTemplate;

            var allLogsPath = Path.GetFullPath(LogsPath, basePath: basePath);
            var errorLogsPath = Path.GetFullPath(errorPath, basePath: basePath);

            loggerConfiguration
                .WriteTo.File(path: errorLogsPath,
                outputTemplate: outputTemplate,
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Error,
                formatProvider: CultureInfo.CurrentCulture)

                .WriteTo.File(path: allLogsPath,
                outputTemplate: outputTemplate,
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Verbose,
                formatProvider: CultureInfo.CurrentCulture)

                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.WithThreadId()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Console(formatProvider: CultureInfo.CurrentCulture);

            return loggerConfiguration;
        }
    }
}
