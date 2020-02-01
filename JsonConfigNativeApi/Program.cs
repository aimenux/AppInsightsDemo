using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JsonConfigNativeApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder => { webHostBuilder.UseStartup<Startup>(); })
                .ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    const string key = "Logging:ApplicationInsights:InstrumentationKey";
                    var instrumentationKey = hostingContext.Configuration.GetValue<string>(key);
                    loggingBuilder.AddApplicationInsights(instrumentationKey);
                });
    }
}
