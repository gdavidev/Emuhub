using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Services.Storage;

namespace Emuhub.Application.UseCases.Games
{
    public class GameCreateUseCase(GameRepository games, EmulatorRepository emulators, GameCategoryRepository categories, IFileStorageService storage)
    {
        public async Task<long> Execute(GameCreateRequest request)
        {
            await Validate(request);

            var imagePath = await storage.UploadAsync(request.Image);
            var filePath = await storage.UploadAsync(request.File);

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

        private async Task Validate(GameCreateRequest request)
        {
            var errors = new List<object>();

            if (request.Name == "")
                errors.Add(new { Name = ExceptionMessagesResource.NAME_EMPTY });
            if (request.Description == "")
                errors.Add(new { Description = ExceptionMessagesResource.NAME_EMPTY });
            if (request.CategoryId <= 0)
                errors.Add(new { CategoryId = ExceptionMessagesResource.NAME_EMPTY });
            if (request.EmulatorId <= 0)
                errors.Add(new { EmulatorId = ExceptionMessagesResource.NAME_EMPTY });
            if (request.File == null)
                errors.Add(new { File = ExceptionMessagesResource.NAME_EMPTY });
            if (request.Image == null)
                errors.Add(new { Image = ExceptionMessagesResource.NAME_EMPTY });

            if (!await emulators.Exists(request.EmulatorId))
                errors.Add(new { Emulator = ExceptionMessagesResource.NAME_EMPTY });
            if (!await categories.Exists(request.CategoryId))
                errors.Add(new { Category = ExceptionMessagesResource.NAME_EMPTY });

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);
        }        
    }
}
