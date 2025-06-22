using Emuhub.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Seeders;

internal static class EmulatorsSeeder
{
    public static void Seed(DbContext context)
    {
        if (context.Set<Emulator>().Any())
            return;
        
        context.Set<Emulator>().AddRange([
            new Emulator()
            {
                Abbreviation = "GB",
                Name = "GAME BOY",            
            },
            new Emulator()
            {
                Abbreviation = "GBC",
                Name = "GAME BOY COLOR",            
            },
            new Emulator()
            {
                Abbreviation = "GBA",
                Name = "GAME BOY ADVANCED",            
            },
            new Emulator()
            {
                Abbreviation = "DS",
                Name = "NINTENDO DS",            
            },
            new Emulator()
            {
                Abbreviation = "NES",
                Name = "NINTENDINHO",            
            },
            new Emulator()
            {
                Abbreviation = "SNES",
                Name = "SUPER NINTENDO",            
            },
            new Emulator()
            {
                Abbreviation = "N64",
                Name = "NINTENDO 64",            
            },
            new Emulator()
            {
                Abbreviation = "PS",
                Name = "PLAYSTATION",            
            },
            new Emulator()
            {
                Abbreviation = "P2",
                Name = "PLAYSTATION 2",            
            },
            new Emulator()
            {
                Abbreviation = "SMS",
                Name = "MASTER SYSTEM",            
            },
            new Emulator()
            {
                Abbreviation = "DC",
                Name = "DREAM CAST",  
            }
        ]);
    }
}