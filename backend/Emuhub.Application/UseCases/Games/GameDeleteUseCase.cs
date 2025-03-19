using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories;

namespace Emuhub.Application.UseCases.Games
{
    public class GameDeleteUseCase(GameRepository games)
    {
        public async Task Execute(long id)
        {
            Validate(id);

            var game = await games.Get(id);

            if (game is null)
                throw new ValidationErrorException(new ValidationErrorItem("Id", ExceptionMessagesResource.GAME_NOT_FOUND));

            await games.Delete(game);
        }

        private void Validate(long id)
        {
            if (id <= 0)
                throw new ValidationErrorException(new ValidationErrorItem("Id", ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO));
        }
    }
}
