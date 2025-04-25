using Emuhub.Domain.Entities.Forum;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Infrastructure.Repositories.Abstractions
{
    public interface IPostCategoryRepository
    {
        public Task<PostCategory?> Get(long id);
        public Task<List<PostCategory>> GetAll();
        public Task<bool> Exists(long id);
    }
}
