using Emuhub.Application.Serialization;
using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;

namespace Emuhub.Application.UseCases.Games
{
    public class GameGetByIdUseCase(GameRepository games, GameExistingIdValidator validator)
    {
        public async Task<GameResponse> Execute(long id)
        {
            await validator.ValidateAndThrowAsync(id);

            Game? game = await games.Get(id);

            return GameSerializer.ToResponse(game!);
        }
    }
}
