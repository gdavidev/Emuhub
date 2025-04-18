using Serilog;

namespace Emuhub.API
{
    public static class DependencyInjection
    {
        public static void AddLogger(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            host.UseSerilog();
        }
    }
}
