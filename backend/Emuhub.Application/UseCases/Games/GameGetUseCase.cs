using System.Collections.Concurrent;
using System.Text.Json;
using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Storage;

namespace Emuhub.Application.UseCases.Games;

public class GameGetUseCase(
    IGameRepository games,
    IFileStorageService fileStorage)
{
    public async Task<List<GameResponse>> Execute(int page)
    {
        Validate(page);
        
        List<Game> gameList = await games.GetAll(page);
        Console.WriteLine(JsonSerializer.Serialize(gameList, new JsonSerializerOptions() { WriteIndented = true }));
        var response = new ConcurrentBag<GameResponse>();

        var tasks = gameList.Select(async game =>
            {
                var gameDto = GameSerializer.ToResponse(game);
                gameDto.ImageBase64 = await fileStorage.GetBase64Async(
                    "games",
                    $"thumbs/{game.ImageName}");
                gameDto.FileName = game.FileName;

                response.Add(gameDto);
            });

        await Task.WhenAll(tasks);
        return response.ToList();
    }

    private static void Validate(int page)
    {
        if (page < 0)
            throw new ValidationErrorException(new ValidationErrorItem("Page", ExceptionMessagesResource.NEGATIVE_PAGE_NUMBER));
    }
}