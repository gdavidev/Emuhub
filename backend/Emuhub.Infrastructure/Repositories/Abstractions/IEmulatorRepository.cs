using Emuhub.Domain.Entities.Games;

namespace Emuhub.Infrastructure.Repositories.Abstractions;

public interface IEmulatorRepository
{
    public Task<Emulator?> Get(long id);
    public Task<List<Emulator>> GetAll();
    public Task Add(Emulator emulator);
    public Task Update(Emulator emulator);
    public Task Delete(Emulator emulator);
    public Task<bool> Exists(long id);
}