using Emuhub.Domain.Entities;
using Emuhub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Repositories;

public class EmulatorRepository(ApplicationDbContext context)
{
    private static readonly int pageSize = 10;

    public async Task<Emulator?> Get(long id)
    {
        return await context.Emulators.SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task<List<Emulator>> GetAll(int page)
    {
        int begin = pageSize * page;

        return await context.Emulators
            .Skip(begin)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task Add(Emulator emulator)
    {
        context.Emulators.Add(emulator);
        await context.SaveChangesAsync();
    }

    public async Task Update(Emulator emulator)
    {
        context.Entry(emulator).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task Delete(Emulator emulator)
    {
        context.Emulators.Remove(emulator);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(long id)
    {
        return await context.Emulators.AnyAsync(e => e.Id == id);
    }
}
