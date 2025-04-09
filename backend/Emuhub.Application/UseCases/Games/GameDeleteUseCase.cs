using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;

namespace Emuhub.Application.UseCases.Games
{
    public class GameDeleteUseCase(IGameRepository games, GameExistingIdValidator validator)
    {
        public async Task Execute(GameExistingIdRequest request)
        {
            await validator.ValidateAndThrowAsync(request);

            var game = await games.Get(request.Id);

            await games.Delete(game!);
        }
    }
}
