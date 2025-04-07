using Emuhub.Application.Validation.Games;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;

namespace Emuhub.Application.UseCases.Games
{
    public class GameDeleteUseCase(GameRepository games, GameExistingIdValidator validator)
    {
        public async Task Execute(long id)
        {
            await validator.ValidateAndThrowAsync(id);

            var game = await games.Get(id);

            await games.Delete(game!);
        }
    }
}
