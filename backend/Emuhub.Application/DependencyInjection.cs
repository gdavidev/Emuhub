using Emuhub.Application.UseCases.Emulators;
using Emuhub.Application.UseCases.Games;
using Emuhub.Application.UseCases.Users;
using Emuhub.Application.Validation.Games;
using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Auth;
using Emuhub.Communication.Data.Games;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Emuhub.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddValidators(services);
            AddUseCases(services);
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<GameCreateRequest>, GameCreateRequestValidator>();

            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
        }

        private static void AddUseCases(IServiceCollection services)
        {
            AddGameUseCases(services);
            AddUserUseCases(services);
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
            services.AddScoped<RefreshTokenUseCase>();
        }
    }
}
