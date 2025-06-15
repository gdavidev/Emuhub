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
    
    public static void ConfigureCors(this IServiceCollection services, string policyName, IConfiguration configuration)
    {
        var hostIp = configuration.GetValue<string>("HostIp")!;
        
        services.AddCors(options =>
            options.AddPolicy(
                name: policyName,
                configurePolicy => configurePolicy
                    .WithOrigins(
                        "http://localhost:8080",
                        "https://localhost:8080",
                        "http://localhost:5173",
                        "https://localhost:5173",
                        $"http://{hostIp}:8080",
                        $"https://{hostIp}:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
    }
}