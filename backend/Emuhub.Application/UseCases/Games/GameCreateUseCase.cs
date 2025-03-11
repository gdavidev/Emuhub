using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories;

namespace Emuhub.Application.UseCases.Games
{
    public class GameCreateUseCase(GameRepository games, EmulatorRepository emulators, GameCategoryRepository categories)
    {
        public async Task<long> Execute(GameCreateRequest request)
        {
            var emulator = await emulators.Get(request.EmulatorId);
            var category = await categories.Get(request.CategoryId);

            Validate(request, emulator, category);

            var game = request.AsGame(emulator!, category!);
            await games.Add(game);

            return game.Id;
        }

        private static void Validate(GameCreateRequest request, Emulator? emulator, GameCategory? category)
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

            if (emulator == null)
                errors.Add(new { Emulator = ExceptionMessagesResource.NAME_EMPTY });
            if (category == null)
                errors.Add(new { Category = ExceptionMessagesResource.NAME_EMPTY });

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);
        }        
    }
}
