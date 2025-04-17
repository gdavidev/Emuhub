using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.UseCases.Games
{
    public class GameCreateUseCase(IGameRepository games, GameCreateRequestValidator validator, IFileStorageService storage)
    {
        public async Task<long> Execute(GameCreateRequest request)
        {
            validator.ValidateAndThrow(request);

            var imageName = new Guid().ToString();
            var fileName = new Guid().ToString();

            try
            {
                await UploadFileAsync(request.File, "files/");
                await UploadFileAsync(request.Image, "thumbs/");

                var game = new Game()
                {
                    Id = 0,
                    Name = request.Name,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    EmulatorId = request.EmulatorId,
                    ImageName = imageName,
                    FileName = fileName
                };

                return await games.Add(game);
            }
            catch
            {
                await RollbackFiles(imageName, fileName);
                throw;
            }
        }

        private async Task UploadFileAsync(IFormFile file, string location) =>
            await storage.UploadAsync(
                "games",
                file.OpenReadStream(),
                location + file.FileName,
                file.ContentType
            );

        private async Task RollbackFiles(string imagePath, string filePath)
        {
            if (imagePath != "")
                await storage.DeleteAsync("games", "thumb/" + imagePath);
            if (imagePath != "")
                await storage.DeleteAsync("games", "files/" + filePath);
        }
    }    
}
