using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Repositories
{
    public class GameCategoryRepository(ApplicationDbContext context) : IGameCategoryRepository
    {
        public async Task<GameCategory?> Get(long id)
        {
            return await context.GameCategories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<GameCategory>> GetAll()
        {
            return await context.GameCategories.ToListAsync();
        }        

        public async Task<bool> Exists(long id)
        {
            return await context.GameCategories.AnyAsync(c => c.Id == id);
        }
    }
}
