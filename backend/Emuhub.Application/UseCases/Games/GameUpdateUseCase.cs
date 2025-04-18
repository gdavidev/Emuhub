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

            if (request.Image is not null)
            {
                var image = request.Image;
                await storage.UploadAsync("games", image.OpenReadStream(), "thumbs/" + oldGame.ImageName, image.ContentType);
            }
            if (request.File is not null)
            {
                var file = request.File;
                await storage.UploadAsync("games", file.OpenReadStream(), "thumbs/" + oldGame.FileName, file.ContentType);
            }

            var game = GameSerializer.ParseRequest(request);
            game.Id = oldGame.Id;
            game.ImageName = oldGame.ImageName;
            game.FileName = oldGame.FileName;

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
