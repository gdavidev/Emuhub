namespace Emuhub.Infrastructure.Services.Storage;

public interface IFileStorageService
{
    public Task<(Stream, string)> DownloadAsync(string bucket, string filePath);
    public Task<string> GetBase64Async(string bucket, string filePath);
    public Task UploadAsync(string bucket, Stream fileStream, string filePath, string contentType);
    public Task DeleteAsync(string bucket, string filePath);
    public Task EnsureBucketsCreated(string[] bucketNames);
}
