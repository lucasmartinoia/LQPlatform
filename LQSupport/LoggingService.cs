using Serilog;

using System;

namespace LatamQuants.Support
{
    public static class LoggingService
    {
        //Install-Package Serilog
        //Install-Package Serilog.Sinks.Console

        //Install-Package Serilog.Sinks.RollingFile

        //Install-Package Serilog.Sinks.Async
        public static void Save(int level, string message)
        {

            //Install-Package Serilog.Settings.Configuration
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            //    var log = new LoggerConfiguration().WriteTo.RollingFile(GlobalSettings.LogFile, shared: true).CreateLogger();

            //var log = new LoggerConfiguration().WriteTo.Async()




            //            var log = new LoggerConfiguration().WriteTo.RollingFile(GlobalSettings.LogFile, shared: true, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {NewLine} {Message:lj}{NewLine}{Exception} {NewLine} {NewLine}").CreateLogger();

            

            var log = new LoggerConfiguration().WriteTo
                .Async(a => a.RollingFile(GlobalSettings.LogFile, shared: true, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {NewLine} {Message:lj}{NewLine}{Exception} {NewLine} {NewLine}"))
                .CreateLogger();
            if (level== (int)EnumLogType.Information)
                log.Information(message);
            else if (level == (int)EnumLogType.Error)
                log.Fatal(message);
        }
        public static void Save(string message, [System.Runtime.CompilerServices.CallerMemberName] string ProcedureName = "")
        {
            message = "-- PROCESO: " + ProcedureName + Environment.NewLine +  message;
            var log = new LoggerConfiguration().WriteTo
                .Async(a => a.RollingFile(GlobalSettings.LogFileMonitor, shared: true, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {NewLine} {Message:lj}{NewLine}{Exception} {NewLine} {NewLine}"))
                .CreateLogger();
                log.Information(message);
        }
    }
}
