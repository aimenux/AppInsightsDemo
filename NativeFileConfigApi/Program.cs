namespace NativeFileConfigApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();
        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging((hostingContext, loggingBuilder) =>
            {
                loggingBuilder.AddApplicationInsights(hostingContext.Configuration);
            });
}