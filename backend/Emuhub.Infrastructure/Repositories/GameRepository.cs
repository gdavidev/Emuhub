using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.DataAccess;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Repositories;

public class GameRepository(ApplicationDbContext context) : IGameRepository
{
    private static readonly int pageSize = 10;

    public async Task<Game?> Get(Guid id)
    {
        return await context.Games
            .Include(game => game.Emulator)
            .Include(game => game.Category)
            .SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task<List<Game>> GetAll(int page)
    {
        var begin = pageSize * page;

        return await context.Games
            .Include(game => game.Emulator)
            .Include(game => game.Category)
            .OrderByDescending(g => g.Name)
            .Skip(begin)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Game>> Search(string term)
    {
        var pattern = $"%{term}%";
        
        return await context.Games
            .Include(game => game.Emulator)
            .Include(game => game.Category)
            .OrderByDescending(g => g.Name)
            .Where(g =>
                EF.Functions.ILike(g.Name, pattern)
                || (g.Emulator != null && EF.Functions.ILike(g.Emulator.Name, pattern))
                || (g.Category != null && EF.Functions.ILike(g.Category.Name, pattern)))
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

    public async Task<bool> Exists(Guid id)
    {
        return await context.Games
            .AsNoTracking()
            .AnyAsync(e => e.Id == id);
    }
}