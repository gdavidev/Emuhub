using Emuhub.Domain.Entities.Users;

namespace Emuhub.Infrastructure.Repositories.Abstractions;

public interface IUserRepository
{
    public Task Add(User user);
    public Task<User?> GetById(Guid id);
    public Task<User?> GetByEmail(string email);
    public Task Update(User user);
    public Task Delete(User user);
    public Task<bool> IsUserNameAndEmailAvailable(string userName, string email);
    public Task<bool> Exists(Guid id);
}