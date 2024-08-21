using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using WebApi.Exceptions;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console() // Log to the console
            .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) // Log to a file
            .WriteTo.MSSqlServer(
                connectionString: "ExContextconstrg",
                sinkOptions: new MSSqlServerSinkOptions { TableName = "LogTable", AutoCreateSqlTable = true },
                columnOptions: new ColumnOptions()) // Add any specific column options if needed
            .CreateLogger();

        try
        {
            Log.Information("Starting up the application");
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog() // Use Serilog for logging
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
