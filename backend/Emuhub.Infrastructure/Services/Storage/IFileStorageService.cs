using Emuhub.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Infrastructure.Services.Storage;

public interface IFileStorageService
{
    public Task<string> UploadAsync(IFormFile file);
    public void Download(User user, string fileName);
    public void Delete(string path);
}
