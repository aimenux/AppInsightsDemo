using CoreLib.TelemetryInitializers;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.OpenApi.Models;

namespace FluentConfigNativeApi
{
    public class StartupWayTwo
    {
        private const string ApiVersion = "V1";
        private const string ApiName = nameof(FluentConfigNativeApi);

        public StartupWayTwo(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddLogging(builder =>
            {
                const string key = "Logging:ApplicationInsights:InstrumentationKey";
                var instrumentationKey = Configuration.GetValue<string>(key);
                builder.AddApplicationInsights(instrumentationKey);
                builder.AddFilter<ApplicationInsightsLoggerProvider>(nameof(FluentConfigNativeApi), LogLevel.Trace);
            });

            services.AddApplicationInsightsTelemetry();

            services.AddSingleton<ITelemetryInitializer, IpTelemetryInitializer>();
            services.AddSingleton<ITelemetryInitializer, UserTelemetryInitializer>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new OpenApiInfo { Title = ApiName, Version = ApiVersion });
            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", ApiName);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
