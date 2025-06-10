using Emuhub.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Seeders;

internal static class EmulatorsSeeder
{
    public static void Seed(DbContext context)
    {
        if (context.Set<GameCategory>().Any())
            return;
        
        context.Set<Emulator>().AddRange([
            new Emulator()
            {
                Name = "Super Nintendo",
                CompanyName = "Nintendo",
                Abbreviation = "snes",
                Console = "Super Nintendo",
            },
            new Emulator()
            {
                Name = "Nintendo 64",
                CompanyName = "Nintendo",
                Abbreviation = "n64",
                Console = "Nintendo 64",
            },
            new Emulator()
            {
                Name = "Nintendo",
                CompanyName = "Nintendo",
                Abbreviation = "nes",
                Console = "Nintendo",
            },
            new Emulator()
            {
                Name = "PlayStation 1",
                CompanyName = "Sony",
                Abbreviation = "ps1",
                Console = "PlayStation 1",
            }
        ]);
    }
}