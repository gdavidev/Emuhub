using System.Collections.Concurrent;
using System.Text.Json;
using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.Games;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Storage;

namespace Emuhub.Application.UseCases.Games;

public class GameSearchUseCase(
    IGameRepository gameRepository,
    IFileStorageService fileStorage)
{
    public async Task<List<GameResponse>> Execute(string term)
    {
        var games = await gameRepository.Search(term);
        var response = new ConcurrentBag<GameResponse>();

        var tasks = games.Select(async game =>
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
}