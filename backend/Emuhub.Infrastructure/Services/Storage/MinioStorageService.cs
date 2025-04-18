using Microsoft.Extensions.Configuration;
using Minio.DataModel.Args;
using Minio;
using Emuhub.Domain.Entities.Users;
using Minio.ApiEndpoints;
using Minio.DataModel;

namespace Emuhub.Infrastructure.Services.Storage
{
    internal class MinioStorageService : IFileStorageService
    {
        private readonly IMinioClient _client;

        public MinioStorageService(IConfiguration config)
        {
            _client = new MinioClient()
               .WithEndpoint(config["Minio:Endpoint"]!)
               .WithCredentials(config["Minio:AccessKey"]!, config["Minio:SecretKey"]!)
               .Build();
        }

        public async Task DeleteAsync(string bucket, string filePath)
        {
            var args = new RemoveObjectArgs()
                .WithBucket(bucket)
                .WithObject(filePath);

            await _client.RemoveObjectAsync(args);
        }

        public async Task<(Stream, string)> DownloadAsync(string bucket, string filePath)
        {
            var memStream = new MemoryStream();

            var stat = await FindObject(bucket, filePath);

            string contentType = stat.ContentType ?? "application/octet-stream";

            await _client.GetObjectAsync(new GetObjectArgs()
                .WithBucket(bucket)
                .WithObject(filePath)
                .WithCallbackStream(stream => stream.CopyTo(memStream)));

            memStream.Position = 0;
            return (memStream, contentType);
        }

        public async Task UploadAsync(string bucket, Stream fileStream, string filePath, string contentType)
        {
            var args = new PutObjectArgs()
                .WithBucket(bucket)
                .WithObject(filePath)
                .WithStreamData(fileStream)
                .WithObjectSize(fileStream.Length)
                .WithContentType(contentType);

            await _client.PutObjectAsync(args).ConfigureAwait(false);
        }

        public async Task EnsureBucketsCreated(string[] bucketNames)
        {
            foreach (var bucketName in bucketNames)
            {
                bool exists = await _client.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));

                if (!exists)                
                    await _client.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));                
            }
        }

        private async Task<ObjectStat> FindObject(string bucket, string filePath)
        {
            var finalTargetPath = filePath;

            if (filePath.EndsWith('*'))
            {
                var prefix = filePath[..filePath.IndexOf('*')];
                var args = new ListObjectsArgs()
                    .WithBucket(bucket)
                    .WithPrefix(prefix)
                    .WithRecursive(false);

                var files = _client.ListObjectsEnumAsync(args).GetAsyncEnumerator();
                finalTargetPath = files.Current.Key;
            }      
            
            return await _client.StatObjectAsync(new StatObjectArgs()
                .WithBucket(bucket)
                .WithObject(finalTargetPath));
        }
    }
}
