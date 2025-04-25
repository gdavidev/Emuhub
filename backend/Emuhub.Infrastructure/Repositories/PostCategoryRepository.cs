using Emuhub.Domain.Entities.Forum;
using Emuhub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Repositories
{
    public class PostCategoryRepository(ApplicationDbContext context)
    {
        public async Task<PostCategory?> Get(long id)
        {
            return await context.PostCategories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<PostCategory>> GetAll()
        {
            return await context.PostCategories.ToListAsync();
        }

        public async Task<bool> Exists(long id)
        {
            return await context.PostCategories.AnyAsync(c => c.Id == id);
        }
    }
}
