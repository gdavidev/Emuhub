using Emuhub.Application.UseCases.Games;
using Microsoft.Extensions.DependencyInjection;

namespace Emuhub.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddGameUseCases(services);
        }

        private static void AddGameUseCases(IServiceCollection services) 
        {
            services.AddScoped<GameGetUseCase>();
            services.AddScoped<GameGetByIdUseCase>();
            services.AddScoped<GameCreateUseCase>();
            services.AddScoped<GameUpdateUseCase>();
            services.AddScoped<GameDeleteUseCase>();
        }
    }
}
