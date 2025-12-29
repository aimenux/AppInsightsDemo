using CoreLib.TelemetryInitializers;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.OpenApi;

namespace SerilogApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddApplicationInsightsTelemetry();

        services.AddSingleton<ITelemetryInitializer, IpTelemetryInitializer>();
        services.AddSingleton<ITelemetryInitializer, UserTelemetryInitializer>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(Constants.ApiVersion, new OpenApiInfo { Title = Constants.ApiName, Version = Constants.ApiVersion });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            c.SwaggerEndpoint($"/swagger/{Constants.ApiVersion}/swagger.json", Constants.ApiName);
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}