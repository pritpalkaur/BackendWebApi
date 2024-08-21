using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
                connectionString: "WebApiApplicationDbContextconstrg",
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
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .UseSerilog() // Use Serilog for logging
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}






//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using webapitaskup.Models;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//builder.Services.AddDbContext<AppDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1")));
//// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp",
//    builder =>
//    {
//        builder.WithOrigins("http://localhost:3000") // React app URL
//    .AllowAnyHeader()
//    .AllowAnyMethod();
//    });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();


//// Enable CORS
//app.UseCors("AllowReactApp");

//app.MapControllers();

//app.Run();






////// Add services to the container.
////builder.Services.AddControllers();

////// Add CORS policy
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowReactApp",
////        builder =>
////        {
////            builder.WithOrigins("http://localhost:3000") // React app URL
////                   .AllowAnyHeader()
////                   .AllowAnyMethod();
////        });
////});

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseDeveloperExceptionPage();
////}
////else
////{
////    app.UseExceptionHandler("/Home/Error");
////    app.UseHsts();
////}

////app.UseHttpsRedirection();
////app.UseRouting();
////app.UseAuthorization();

////// Enable CORS
////app.UseCors("AllowReactApp");

////app.MapControllers();

////app.Run();
