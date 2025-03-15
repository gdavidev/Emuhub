using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories;

namespace Emuhub.Application.UseCases.Games
{
    public class GameGetByIdUseCase(GameRepository games)
    {
        public async Task<GameResponse?> Execute(long id)
        {
            await Validate(id);

            Game? game = await games.Get(id);

            if (game is not null)
                return GameSerializer.ToResponse(game);
            return null;
        }

        private async Task Validate(long id)
        {
            if (id <= 0)
                throw new ValidationErrorException([new { Id = ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO }]);
            if (!await games.Exists(id))
                throw new ValidationErrorException([new { Id = ExceptionMessagesResource.GAME_NOT_FOUND }]);
        }
    }
}
