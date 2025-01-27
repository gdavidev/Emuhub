using Microsoft.CodeAnalysis.CSharp.Syntax;
using RestAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Data
{
	public record GameDTO(
		[Required] long Id,
		[Required][StringLength(50)] string Name,
		[Required][StringLength(100)] string Description
	);

	public static class GameDTOExtensions
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
}
