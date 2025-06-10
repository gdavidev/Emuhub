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

        ConfigureGameEntity(modelBuilder);
    }

    private static void ConfigureGameEntity(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Game>();
        
        builder
            .HasOne(game => game.Category)
            .WithMany()
            .HasForeignKey(g => g.CategoryId)
            .IsRequired();
        
        builder
            .HasOne(game => game.Emulator)
            .WithMany()
            .HasForeignKey(g => g.EmulatorId)
            .IsRequired();
    }    
}