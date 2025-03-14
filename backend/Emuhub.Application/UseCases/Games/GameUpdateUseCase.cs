using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Emuhub.Infrastructure.Services.Storage;

namespace Emuhub.Application.UseCases.Games
{
    public class GameUpdateUseCase(GameRepository games, EmulatorRepository emulators, GameCategoryRepository categories, IFileStorageService storage)
    {
        public async Task Execute(GameUpdateRequest request)
        {
            await Validate(request);

            var oldGame = await games.Get(request.Id);

            string? imagePath = request.Image is null ? oldGame!.Image : await storage.UploadAsync(request.Image);
            string? filePath = request.File is null ? oldGame!.File : await storage.UploadAsync(request.File);

            var game = new Game()
            {
                Id = oldGame!.Id,
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                EmulatorId = request.EmulatorId,
                Image = imagePath,
                File = filePath
            };

            try
            {
                await games.Update(game);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await games.Exists(game.Id))
                    throw new ValidationErrorException([new { Game = ExceptionMessagesResource.GAME_NOT_FOUND }]);
                else
                    throw new ValidationErrorException([ExceptionMessagesResource.UNKNOWN_ERROR]);
            }
        }

        private async Task Validate(GameUpdateRequest request)
        {
            var errors = new List<object>();

            if (request.Id <= 0)
                errors.Add(new { Id = ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO });
            if (request.Name == "")
                errors.Add(new { Name = ExceptionMessagesResource.NAME_EMPTY });
            if (request.Description == "")
                errors.Add(new { Description = ExceptionMessagesResource.NAME_EMPTY });
            if (request.CategoryId <= 0)
                errors.Add(new { CategoryId = ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO });
            if (request.EmulatorId <= 0)
                errors.Add(new { EmulatorId = ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO });

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);

            if (!await games.Exists(request.Id))
                errors.Add(new { Game = ExceptionMessagesResource.GAME_NOT_FOUND });            
            if (!await emulators.Exists(request.EmulatorId))
                errors.Add(new { Emulator = ExceptionMessagesResource.NAME_EMPTY });
            if (!await categories.Exists(request.CategoryId))
                errors.Add(new { Category = ExceptionMessagesResource.NAME_EMPTY });

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);
        }
    }
}
