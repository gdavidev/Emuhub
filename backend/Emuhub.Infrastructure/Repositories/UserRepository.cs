using Emuhub.Domain.Entities.Users;
using Emuhub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context)
    {
        public async Task<User?> Get(Guid id)
        {
            return await context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await context.Users.AnyAsync(e => e.Id == id);
        }
    }
}
