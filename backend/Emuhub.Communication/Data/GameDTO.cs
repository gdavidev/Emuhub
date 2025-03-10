using System.ComponentModel.DataAnnotations;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Communication.Data;

public record GameDTO(
	[Required] long Id,
	[Required][StringLength(50)] string Name,
	[Required][StringLength(100)] string Description
);

public static class GameExtensions
{
	public static GameDTO AsDTO(this Game game)
	{
		return new GameDTO(
			game.Id,
			game.Name,
			game.Description
		);		
	}
}
