using Emuhub.Application.Serialization;
using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;

namespace Emuhub.Application.UseCases.Games
{
    public class GameGetByIdUseCase(IGameRepository games, GameExistingIdValidator validator)
    {
        public async Task<GameResponse> Execute(GameExistingIdRequest request)
        {
            await validator.ValidateAndThrowAsync(request);

            Game? game = await games.Get(request.Id);

            return GameSerializer.ToResponse(game!);
        }
    }
}
