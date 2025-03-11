using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Repositories
{
    public class GameRepository(ApplicationDbContext context)
    {
        private static readonly int pageSize = 10;

        public async Task<Game?> Get(long id) 
        {
            return await context.Games.SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Game>> GetAll(int page)
        {
            int begin = pageSize * page;

            return await context.Games
                .Skip(begin)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Add(Game game)
        {
            context.Games.Add(game);
            await context.SaveChangesAsync();
        }

        public async Task Update(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(Game game)
        {
            context.Games.Remove(game);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(long id)
        {
            return await context.Games.AnyAsync(e => e.Id == id);
        }
    }
}
