using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Repositories;

public class EmulatorRepository(ApplicationDbContext context) : IEmulatorRepository
{
    public async Task<Emulator?> Get(long id)
    {
        return await context.Emulators.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Emulator>> GetAll(int page)
    {        
        return await context.Emulators.ToListAsync();
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
