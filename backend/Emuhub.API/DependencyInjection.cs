using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Emuhub.API;

public static class DependencyInjection
{
    public static void ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }
    
    public static void AddLogger(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        host.UseSerilog();
    }
}