using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Storage;

namespace Emuhub.Application.UseCases.Games;

public class GameImageDownloadUseCase(
    IGameRepository games,
    IFileStorageService fileStorage)
{
    public async Task<(Stream, string)> Execute(string emulatorAbbreviation, string gameName)
    {
        var game = await games.GetByEmulatorAbbreviationAndGameName(
            emulatorAbbreviation,
            gameName);
        if (game is null)
        {
            throw new ResourceNotFoundException(
                "Game",
                ExceptionMessagesResource.GAME_NOT_FOUND);
        }
        
        var imageName = game.ImageName;

        var (stream, mimeType) = await fileStorage.DownloadAsync(
            "games",
            $"thumbs/{imageName}");
        if (stream is null)
        {
            throw new ResourceNotFoundException(
                "File",
                ExceptionMessagesResource.UNKNOWN_ERROR);    
        }
        
        return (stream, mimeType);
    }
}