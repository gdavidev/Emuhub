using Emuhub.Infrastructure.DataAccess;
using Emuhub.Infrastructure.Services.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Emuhub.Infrastructure;

public static class ConfigureApplication
{
    public static WebApplication UseUpdateMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
        dbContext.Database.Migrate();

        return app;
    }

    public static async Task<WebApplication> UseFileStorageService(this WebApplication app)
    {
        IFileStorageService minioClient = app.Services.GetRequiredService<IFileStorageService>();

        await minioClient.EnsureBucketsCreated([
            "games",
            "users"
        ]);

        return app;
    }
}