using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Services.Storage;
using Microsoft.EntityFrameworkCore;

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

            var game = GameSerializer.ParseRequest(request);
            game.Id = oldGame!.Id;
            game.Image = imagePath;
            game.File = filePath;            

            try
            {
                await games.Update(game);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await games.Exists(game.Id))
                    throw new ValidationErrorException(new ValidationErrorItem("Game", ExceptionMessagesResource.GAME_NOT_FOUND));
                else
                    throw new ValidationErrorException(new ValidationErrorItem("RaceCondition", ExceptionMessagesResource.UNKNOWN_ERROR));
            }
        }

        private async Task Validate(GameUpdateRequest request)
        {
            var errors = new List<ValidationErrorItem>();

            if (request.Id <= 0)
                errors.Add(new ValidationErrorItem("Id", ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO));
            if (request.Name == "")
                errors.Add(new ValidationErrorItem("Name", ExceptionMessagesResource.NAME_EMPTY));
            if (request.Description == "")
                errors.Add(new ValidationErrorItem("Description", ExceptionMessagesResource.NAME_EMPTY));
            if (request.CategoryId <= 0)
                errors.Add(new ValidationErrorItem("CategoryId", ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO));
            if (request.EmulatorId <= 0)
                errors.Add(new ValidationErrorItem("EmulatorId", ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO));

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);

            if (!await games.Exists(request.Id))
                errors.Add(new ValidationErrorItem("Game", ExceptionMessagesResource.GAME_NOT_FOUND));            
            if (!await emulators.Exists(request.EmulatorId))
                errors.Add(new ValidationErrorItem("Emulator", ExceptionMessagesResource.NAME_EMPTY));
            if (!await categories.Exists(request.CategoryId))
                errors.Add(new ValidationErrorItem("Category", ExceptionMessagesResource.NAME_EMPTY));

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);
        }
    }
}
