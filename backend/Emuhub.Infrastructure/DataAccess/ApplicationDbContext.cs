using Microsoft.EntityFrameworkCore;
using Emuhub.Domain.Entities.Games;
using Emuhub.Domain.Entities.Forum;
using Emuhub.Domain.Entities.Reports;
using Emuhub.Infrastructure.Seeders;
using Emuhub.Domain.Entities.Users;

namespace Emuhub.Infrastructure.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameCategory> GameCategories { get; set; }
    public DbSet<Emulator> Emulators { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<Report> Reports { get; set; }

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

        // Games
        ConfigureEmulatorEntity(modelBuilder);
        ConfigureGameCategoryEntity(modelBuilder);

        // Forum
        ConfigurePostCategoryEntity(modelBuilder);
        ConfigureCommentEntity(modelBuilder);
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

    private static void ConfigureCommentEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
            .HasMany(e => e.Comments)
            .WithOne()
            .HasForeignKey("ParentId")
            .IsRequired(false);
    }

    private static void ConfigurePostCategoryEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostCategory>()
            .HasMany<Post>()
            .WithOne(e => e.Category)
            .HasForeignKey("CategoryId")
            .IsRequired();
    }
}