using System.Xml.Serialization;

namespace Serilog_Demo.Extension
{
    public static class LoggingExtension
    {
        private static readonly Action<ILogger, Exception> _UpdatedWeather;


        static LoggingExtension()
        {
            _UpdatedWeather = LoggerMessage.Define(LogLevel.Information, new EventId(1), "Updated the weather information");
        }
        public static void UpdatedWeather(this ILogger logger) => _UpdatedWeather(logger, null);
    }
}
