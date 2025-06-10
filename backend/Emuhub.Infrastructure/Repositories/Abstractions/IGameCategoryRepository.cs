using Emuhub.Domain.Entities.Games;

namespace Emuhub.Infrastructure.Repositories.Abstractions;

public interface IGameCategoryRepository
{
    public Task<GameCategory?> Get(long id);
    public Task<List<GameCategory>> GetAll();
    public Task<bool> Exists(long id);
}