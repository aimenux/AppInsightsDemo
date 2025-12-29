namespace NativeCodeConfigApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        using var host = Random.Shared.Next(1, 100) % 2 == 0 
            ? CreateHostBuilderWayOne(args).Build() 
            : CreateHostBuilderWayTwo(args).Build();

        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilderWayOne(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseStartup<StartupWayOne>();
            })
            .ConfigureLogging((hostingContext, loggingBuilder) =>
            {
                loggingBuilder.AddApplicationInsights(hostingContext.Configuration);
            });

    private static IHostBuilder CreateHostBuilderWayTwo(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseStartup<StartupWayTwo>();
            });
}