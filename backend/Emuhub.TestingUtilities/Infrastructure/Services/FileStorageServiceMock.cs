using Emuhub.Domain.Entities.Users;
using Emuhub.Infrastructure.Services.Storage;
using Emuhub.TestingUtilities.Data;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Emuhub.TestingUtilities.Infrastructure.Services
{
    public class FileStorageServiceMock : Mock<IFileStorageService>
    {
        public readonly List<IFormFile> _files = [
                new FormFileMock("Mario.zip", 1024 * 4).Object,
                new FormFileMock("Super-Metroid.zip", 1024 * 4).Object
            ];
        
        public void MockUploadAsync(IFormFile file)
        {
            Setup(s => s.UploadAsync(file))
                .ReturnsAsync("games/" + file.Name)
                .Callback(() => _files.Add(file));
        }

        public void MockDownload(User user, string fileName) => Setup(s => s.Download(user, fileName));

        public void MockDelete(string path) => Setup(s => s.Delete(path));
    }
}
