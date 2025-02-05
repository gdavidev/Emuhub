using Microsoft.EntityFrameworkCore;
using Emuhub.Domain.Entities;

namespace Emuhub.Infrastructure.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
}
