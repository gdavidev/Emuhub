using Microsoft.EntityFrameworkCore;
using Emuhub.Domain.Entities;

namespace Emuhub.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
