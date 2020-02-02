using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SerilogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder => { webHostBuilder.UseStartup<Startup>(); })
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    Serilog.Debugging.SelfLog.Enable(Console.Error);
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
                });
    }
}
