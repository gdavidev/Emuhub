using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Emuhub.Domain.Entities.Users;

namespace Emuhub.Infrastructure.Services.Storage
{
    public class FileSystemStorageService(IWebHostEnvironment environment) : IFileStorageService
    {
        public void Delete(string path)
        {
            throw new NotImplementedException();
        }

        public void Download(User user, string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Uploads the <paramref name="file"/> to the file system
        /// (Intended for developing porpouses)
        /// </summary>
        /// <returns>
        /// The randonly generated name for the file stored
        /// </returns>
        /// <param name="file"></param>    
        public async Task<string> UploadAsync(IFormFile file)
        {
            ArgumentNullException.ThrowIfNull(file);

            var contentPath = environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{ext}";
            var pathToFile = Path.Combine(path, fileName);

            using (var stream = new FileStream(pathToFile, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
