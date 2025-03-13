using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Application.Serialization
{
	public class GameSerializer
	{
		public static Game ParseRequest(GameCreateRequest request) => 
			new Game()
				{
					Id = 0,
					Name = request.Name,
					Description = request.Description,
					CategoryId = request.CategoryId,
					EmulatorId = request.EmulatorId,
				};

		public static Game ParseRequest(GameUpdateRequest request) =>
			new Game()
			{
				Id = 0,
				Name = request.Name,
				Description = request.Description,
				CategoryId = request.CategoryId,
				EmulatorId = request.EmulatorId,
			};

		public static GameResponse ToResponse(Game game) =>
			new GameResponse()
			{
				Id = game.Id,
				Name = game.Name,
				Description = game.Description,
				Category = game.Category!,
				Emulator = game.Emulator!,
			};
	}
}
