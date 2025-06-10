using Emuhub.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Seeders;

internal static class GameCategorySeeder
{
    public static void Seed(DbContext context)
    {
        if (context.Set<GameCategory>().Any())
            return;
        
        context.Set<GameCategory>().AddRange([
            new GameCategory() { Name = "Adventure" },
            new GameCategory() { Name = "Shooter" },
            new GameCategory() { Name = "Platformer" },
            new GameCategory() { Name = "Simulation" }
        ]);
    }
}