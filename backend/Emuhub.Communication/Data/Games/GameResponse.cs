using System.ComponentModel.DataAnnotations;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Communication.Data.Games;

public record GameResponse(
    [Required] long Id,
    [Required][StringLength(50)] string Name,
    [Required][StringLength(100)] string Description
);

public static class GameExtensions
{
    public static GameResponse AsResponse(this Game game)
    {
        return new GameResponse(
            game.Id,
            game.Name,
            game.Description
        );
    }
}
