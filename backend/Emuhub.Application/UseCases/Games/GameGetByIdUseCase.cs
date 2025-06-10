using Emuhub.Application.Serialization;
using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data;
using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;

namespace Emuhub.Application.UseCases.Games;

public class GameGetByIdUseCase(
    IGameRepository games,
    GameExistingIdValidator validator,
    IFileStorageService fileStorage)
{
    public async Task<GameResponse> Execute(EntityIdRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var game = await games.Get(request.Id);
        if (game is null)
        {
            throw new ResourceNotFoundException(
                "Game",
                ExceptionMessagesResource.GAME_NOT_FOUND);
        }

        var gameDto = GameSerializer.ToResponse(game);
        gameDto.ImageBase64 = await fileStorage.GetBase64Async(
            "games",
            $"thumbs/{game.ImageName}");
        gameDto.FileName = game.FileName;

        return gameDto;
    }
}