using Emuhub.Application.UseCases.Emulators;
using Emuhub.Application.UseCases.GameCategories;
using Emuhub.Application.UseCases.Games;
using Emuhub.Application.UseCases.Users;
using Emuhub.Application.Validation.Emulators;
using Emuhub.Application.Validation.Games;
using Emuhub.Application.Validation.Users;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Emuhub.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddGames(services);
        AddGameCategories(services);
        AddEmulators(services);
        AddUsers(services);
    }

    private static void AddGames(IServiceCollection services) 
    {
        services.AddValidatorsFromAssemblyContaining<GameExistingIdValidator>();
        services.AddValidatorsFromAssemblyContaining<GameCreateRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<GameUpdateRequestValidator>();

        services.AddScoped<GameGetUseCase>();
        services.AddScoped<GameGetByIdUseCase>();
        services.AddScoped<GameCreateUseCase>();
        services.AddScoped<GameDownloadUseCase>();
        services.AddScoped<GameUpdateUseCase>();
        services.AddScoped<GameDeleteUseCase>();
    }
    
    private static void AddGameCategories(IServiceCollection services) 
    {
        services.AddScoped<GameCategoriesGetUseCase>();
    }

    private static void AddEmulators(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<EmulatorExistingIdValidator>();

        services.AddScoped<EmulatorGetByIdUseCase>();
        services.AddScoped<EmulatorGetUseCase>();
    }

        private static void AddUsers(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
    private static void AddUsers(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

            services.AddScoped<UserRegisterUseCase>();
            services.AddScoped<UserLoginUseCase>();
            services.AddScoped<RefreshTokenUseCase>();
        }
    }
}

        services.AddScoped<UserRegisterUseCase>();
        services.AddScoped<UserLoginUseCase>();
        services.AddScoped<RefreshTokenUseCase>();
        services.AddScoped<UserForgotPasswordUseCase>();
    }
}