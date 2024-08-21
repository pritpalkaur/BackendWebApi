using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Exceptions.Service;

namespace WebApi.Exceptions
{
    public class Startup
    {
        public Startup()
        {

        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Other service registrations...

            services.AddScoped<ILoggingService, LoggingService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Middleware configuration...

            app.UseSerilogRequestLogging(); // Enable Serilog request logging
        }

    }
}
