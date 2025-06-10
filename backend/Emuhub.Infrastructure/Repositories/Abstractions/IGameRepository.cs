using Emuhub.Domain.Entities.Games;

namespace Emuhub.Infrastructure.Repositories.Abstractions;

public interface IGameRepository
{
    public Task<Game?> Get(long id);
    public Task<List<Game>> GetAll(int page);
    public Task<long> Add(Game game);
    public Task Update(Game game);
    public Task Delete(Game game);
    public Task<bool> Exists(long id);
}