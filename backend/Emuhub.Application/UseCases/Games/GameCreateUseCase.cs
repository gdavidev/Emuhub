using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;

namespace Emuhub.Application.UseCases.Games
{
    public class GameCreateUseCase(GameRepository games, GameCreateRequestValidator validator, IFileStorageService storage)
    {
        public async Task<long> Execute(GameCreateRequest request)
        {
            validator.ValidateAndThrow(request);

            var imagePath = "";
            var filePath = "";

            try
            {
                imagePath = await storage.UploadAsync(request.Image);
                filePath = await storage.UploadAsync(request.File);

                var game = new Game()
                {
                    Id = 0,
                    Name = request.Name,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    EmulatorId = request.EmulatorId,
                    Image = imagePath,
                    File = filePath
                };
                await games.Add(game);

                return game.Id;
            }
            catch
            {
                RollbackFiles(imagePath, filePath);
                throw;
            }
        }

        private void RollbackFiles(string imagePath, string filePath)
        {
            if (imagePath != "")
                storage.Delete(imagePath);
            if (imagePath != "")
                storage.Delete(filePath);
        }
    }    
}
