using Emuhub.Domain.Entities.Games;
using Emuhub.Domain.Entities.Users;
using Emuhub.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameCategory> GameCategories { get; set; }
    public DbSet<Emulator> Emulators { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
            GameCategorySeeder.Seed(context);
            EmulatorsSeeder.Seed(context);

            context.SaveChanges();
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureEmulatorEntity(modelBuilder);
        ConfigureGameCategoryEntity(modelBuilder);
    }

    private static void ConfigureEmulatorEntity(ModelBuilder modelBuilder)
    {
        // Emulators are related to many Games, but they don't store any reference to them (Id's and as dotnet calls 'navigation property')
        modelBuilder.Entity<Emulator>()
            .HasMany<Game>()                        // Emulator has many Games
            .WithOne(e => e.Emulator)               // Games have one Emulator
            .HasForeignKey(g => g.EmulatorId)       // Foreign key
            .IsRequired();                          // The relationship is required
    }

    private static void ConfigureGameCategoryEntity(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<GameCategory>()
            .HasMany<Game>()
            .WithOne(e => e.Category)
            .HasForeignKey(g => g.CategoryId)
            .IsRequired();
    }    
}