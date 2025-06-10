using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Storage;

namespace Emuhub.Application.UseCases.Games;

public class GameDownloadUseCase(
    IGameRepository games,
    IFileStorageService fileStorage)
{
    public async Task<(Stream, string)> Execute(int gameId)
    {
        var game = await games.Get(gameId);
        if (game is null)
        {
            throw new ResourceNotFoundException(
                "Game",
                ExceptionMessagesResource.GAME_NOT_FOUND);
        }

        var fileName = game.FileName;
        
        return await fileStorage.DownloadAsync("games", $"files/{fileName}");
    }
}