namespace Serilog_Demo.Model
{
    public class SerilogConfiguration
    {
        public const string Section = "Serilog";
        public string BasePath { get; set; } =default!;
        public string AllLogsPath { get; set; } = default!;
        public string ErrorLogsPath { get; set; } = default!;
        public string OutputTemplate { get; set; } = default!;
    }
}
