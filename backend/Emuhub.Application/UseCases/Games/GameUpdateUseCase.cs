using Emuhub.Application.Serialization;
using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Application.UseCases.Games
{
    public class GameUpdateUseCase(IGameRepository games, GameUpdateRequestValidator validator, IFileStorageService storage)
    {
        public async Task Execute(GameUpdateRequest request)
        {
            await validator.ValidateAndThrowAsync(request);

            var oldGame = (await games.Get(request.Id))!;

            string? imagePath = request.Image is null ? oldGame.Image : await storage.UploadAsync(request.Image);
            string? filePath = request.File is null ? oldGame.File : await storage.UploadAsync(request.File);

            var game = GameSerializer.ParseRequest(request);
            game.Id = oldGame.Id;
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
    }
}
