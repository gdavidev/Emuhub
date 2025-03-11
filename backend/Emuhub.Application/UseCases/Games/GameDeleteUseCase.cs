using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Application.UseCases.Games
{
    public class GameDeleteUseCase(GameRepository games)
    {
        public async Task Execute(long id)
        {
            Validate(id);

            var game = await games.Get(id);

            if (game == null)
                throw new ValidationErrorException([new { Id = ExceptionMessagesResource.GAME_NOT_FOUND }]);

            await games.Delete(game);
        }

        private void Validate(long id)
        {
            if (id <= 0)
                throw new ValidationErrorException([new { Id = ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO }]);
        }
    }
}
