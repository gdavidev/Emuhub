using Emuhub.Infrastructure.DataAccess;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Services.Authentication;
using Emuhub.Infrastructure.Services.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Mailing;

namespace Emuhub.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration.GetConnectionString("Default")!);
        AddFileStorageService(services, configuration);
        AddMailingService(services);
        AddRepositories(services);
        AddAuthServices(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(
                connectionString,
                options => options
                    .EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)
                    .MigrationsAssembly("Emuhub.Infrastructure")
            )
        );
    }

    private static void AddFileStorageService(IServiceCollection services, IConfiguration configuration)
    {
        var useLocalFileSystem = configuration.GetValue<bool>("Environment:UseLocalFileSystemStorage");

        if (useLocalFileSystem)
            services.AddSingleton<IFileStorageService, FileSystemStorageService>();
        else
            services.AddSingleton<IFileStorageService, MinioStorageService>();
    }
    
    private static void AddMailingService(IServiceCollection services)
    {
        services.AddSingleton<IEmailService, EmailService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IGameCategoryRepository, GameCategoryRepository>();
        services.AddScoped<IEmulatorRepository, EmulatorRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddAuthServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var securityKeyByteArray = Encoding.UTF8.GetBytes(configuration.GetValue<string>("Token:Secret")!);
                var securityKey = new SymmetricSecurityKey(securityKeyByteArray);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetValue<string>("Token:Issuer")!,
                    ValidAudience = configuration.GetValue<string>("Token:Audience")!,
                    IssuerSigningKey = securityKey
                };
            });

        services.AddScoped<AuthService>();
        services.AddScoped<JwtTokenSecrets>();
        services.AddScoped<JwtTokenHandlerService>();
    }
}
