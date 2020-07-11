using Serilog;
using System;

namespace LatamQuants.Support
{
    public static class LoggingService
    {
        private const string LOG_FILE = "/Logs/LQLog-{Date}.txt";

        public static void Save(EnumLogType level, string message)
        {
            var log = new LoggerConfiguration().WriteTo
                .Async(a => a.RollingFile(LOG_FILE, shared: true, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}>{Message:lj} {Exception}{NewLine}"))
                .CreateLogger();
            if (level== EnumLogType.Information)
                log.Information(message);
            else if (level == EnumLogType.Error)
                log.Fatal(message);
        }
        public static void Save(string message, [System.Runtime.CompilerServices.CallerMemberName] string ProcedureName = "")
        {
            if(String.IsNullOrEmpty(message)==false)
            {
                message = ": " + message;
            }

            message = "PROCESS: " + ProcedureName +  message;

            var log = new LoggerConfiguration().WriteTo
                .Async(a => a.RollingFile(LOG_FILE, shared: true, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}>{Message:lj} {Exception}{NewLine}"))
                .CreateLogger();
                log.Information(message);
        }
    }
}
