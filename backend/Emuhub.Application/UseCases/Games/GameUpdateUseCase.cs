using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Application.UseCases.Games
{
    public class GameUpdateUseCase(GameRepository games, EmulatorRepository emulators, GameCategoryRepository categories)
    {
        public async Task Execute(GameUpdateRequest request)
        {
            var emulator = await emulators.Get(request.EmulatorId);
            var category = await categories.Get(request.CategoryId);

            Validate(request, emulator, category);

            var game = request.AsGame(emulator!, category!);
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

        private static void Validate(GameUpdateRequest request, Emulator? emulator, GameCategory? category)
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
            if (request.File == null)
                errors.Add(new { File = ExceptionMessagesResource.NAME_EMPTY });
            if (request.Image == null)
                errors.Add(new { Image = ExceptionMessagesResource.NAME_EMPTY });

            if (emulator == null)
                errors.Add(new { Emulator = ExceptionMessagesResource.NAME_EMPTY });
            if (category == null)
                errors.Add(new { Category = ExceptionMessagesResource.NAME_EMPTY });

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);
        }
    }
}
