using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Repositories.Abstractions;
using FluentValidation;

namespace Emuhub.Application.UseCases.Games;

public class GameDeleteUseCase(IGameRepository games, GameExistingIdValidator validator)
{
    public async Task Execute(EntityIdRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var game = await games.Get(request.Id);

        await games.Delete(game!);
    }
}