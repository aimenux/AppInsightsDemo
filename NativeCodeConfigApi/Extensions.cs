using Microsoft.Extensions.Logging.ApplicationInsights;

namespace NativeCodeConfigApi;

public static class Extensions
{
    public static void AddApplicationInsights(this ILoggingBuilder builder, IConfiguration configuration)
    {
        const string key = "Logging:ApplicationInsights:ConnectionString";
        var connectionString = configuration.GetValue<string>(key);
        builder.AddApplicationInsights(
            config => config.ConnectionString = connectionString,
            options => options.IncludeScopes = true);
        builder.AddFilter<ApplicationInsightsLoggerProvider>("*", LogLevel.Information);
    }
}