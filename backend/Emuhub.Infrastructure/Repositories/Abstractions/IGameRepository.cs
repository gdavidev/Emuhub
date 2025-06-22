using Emuhub.Domain.Entities.Games;

namespace Emuhub.Infrastructure.Repositories.Abstractions;

public interface IGameRepository
{
    public Task<Game?> Get(Guid id);
    public Task<List<Game>> GetAll(int page);
    public Task<List<Game>> Search(string term);
    public Task Add(Game game);
    public Task Update(Game game);
    public Task Delete(Game game);
    public Task<bool> Exists(Guid id);
    public Task<Game?> GetByEmulatorAbbreviationAndGameName(
        string emulatorAbbreviation,
        string gameName);
}