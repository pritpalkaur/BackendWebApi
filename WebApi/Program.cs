using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
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
