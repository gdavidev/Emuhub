using Microsoft.EntityFrameworkCore;
using RestAPI.Models.Entities;

namespace RestAPI.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<Game> Games { get; set; }
	}
}
