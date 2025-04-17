using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Emuhub.Domain.Entities.Users;

namespace Emuhub.Infrastructure.Services.Storage
{
    /// <summary>
    /// Uploads or Downloads the file to the project file system
    /// (Intended for developing porpouses)
    /// </summary>
    public class FileSystemStorageService(IWebHostEnvironment environment) : IFileStorageService
    {
        public Task DeleteAsync(string bucket, string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<(Stream, string)> DownloadAsync(string bucket, string filePath)
        {
            throw new NotImplementedException();
        }

        public Task EnsureBucketsCreated(string[] bucketNames)
        {
            throw new NotImplementedException();
        }

        public Task UploadAsync(string bucket, Stream fileStream, string filePath, string contentType)
        {
            throw new NotImplementedException();
        }
    }
}
