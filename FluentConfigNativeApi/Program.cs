using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace FluentConfigNativeApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilderWayTwo(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilderWayOne(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder => { webHostBuilder.UseStartup<StartupWayOne>(); })
                .ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    const string key = "Logging:ApplicationInsights:InstrumentationKey";
                    var instrumentationKey = hostingContext.Configuration.GetValue<string>(key);
                    loggingBuilder.AddApplicationInsights(instrumentationKey);
                    loggingBuilder.AddFilter<ApplicationInsightsLoggerProvider>(nameof(FluentConfigNativeApi), LogLevel.Trace);
                });

        public static IHostBuilder CreateHostBuilderWayTwo(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder => { webHostBuilder.UseStartup<StartupWayTwo>(); });
    }
}
