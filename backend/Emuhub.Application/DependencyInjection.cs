using Emuhub.Application.UseCases.Games;
using Emuhub.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Emuhub.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            // Services
            AddAuthServices(services);

            // Use Cases
            AddGameUseCases(services);
            AddUserUseCases(services);
        }

        private static void AddAuthServices(IServiceCollection services)
        {
            services.AddScoped<IJwtTokenSecrets, JwtTokenSecrets>();
            services.AddScoped<JwtTokenHandlerService>();
        }

        private static void AddGameUseCases(IServiceCollection services) 
        {
            services.AddScoped<GameGetUseCase>();
            services.AddScoped<GameGetByIdUseCase>();
            services.AddScoped<GameCreateUseCase>();
            services.AddScoped<GameUpdateUseCase>();
            services.AddScoped<GameDeleteUseCase>();
        }

        private static void AddUserUseCases(IServiceCollection services)
        {
            services.AddScoped<UserRegisterUseCase>();
            services.AddScoped<UserLoginUseCase>();
        }
    }
}
