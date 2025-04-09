using Emuhub.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Seeders
{
    internal static class GameCategorySeeder
    {
        public static void Seed(DbContext context)
        {
            context.Set<GameCategory>().Add(new GameCategory() { Name = "Adventure" });
            context.Set<GameCategory>().Add(new GameCategory() { Name = "MMO" });            
        }
    }
}
