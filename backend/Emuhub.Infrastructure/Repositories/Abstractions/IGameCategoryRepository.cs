using Emuhub.Domain.Entities.Games;

namespace Emuhub.Infrastructure.Repositories
{
    public interface IGameCategoryRepository
    {
        public Task<GameCategory?> Get(long id);
        public Task<List<GameCategory>> GetAll();
        public Task Add(GameCategory category);
        public Task Update(GameCategory category);
        public Task Delete(GameCategory category);
        public Task<bool> Exists(long id);
    }
}
