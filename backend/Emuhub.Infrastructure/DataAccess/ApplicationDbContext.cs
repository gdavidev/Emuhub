using Microsoft.EntityFrameworkCore;
using Emuhub.Domain.Entities;

namespace Emuhub.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameCategory> GameCategories { get; set; }
    public DbSet<Emulator> Emulators { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
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
            .HasForeignKey("EmulatorId")            // (Shadow property) The foreign key EmulatorId exists in the database but isn’t exposed in the Game class
            .IsRequired();                          // The relationship is required
    }

    private static void ConfigureGameCategoryEntity(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<GameCategory>()
            .HasMany<Game>()
            .WithOne(e => e.Category)
            .HasForeignKey("CategoryId")
            .IsRequired();
}

}