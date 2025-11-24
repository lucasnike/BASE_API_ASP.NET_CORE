namespace Ioc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

public static class LogModule
{
    public static ILoggingBuilder AddApiLogger(this ILoggingBuilder builder, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(Constants.DEFAULT_CONNECTION_STRING);

        Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(
                connectionString,
                new MSSqlServerSinkOptions
                {
                    AutoCreateSqlTable = true,
                    TableName = "Logs"
                },
                null,
                null, LogEventLevel.Warning)
            .WriteTo.Console(LogEventLevel.Debug)
            .WriteTo.File("/Logs", LogEventLevel.Debug)
            .CreateLogger();

        builder.AddSerilog(Log.Logger);
        return builder;
    }
}
