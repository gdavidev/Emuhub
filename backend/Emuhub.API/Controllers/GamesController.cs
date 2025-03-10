using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.API.Controllers;

[ApiController]
public class GamesController(GameRepository games) : ControllerBase
{
	[HttpGet]
    [Route("api/Games")]
    public async Task<ActionResult<IEnumerable<GameDTO>>> GetGames([FromQuery] int page)
	{
		List<Game> gameList = await games.GetAll(page);
		List<GameDTO> dtoList = gameList.Select(g => g.AsDTO()).ToList();

		return dtoList;
    }

	[HttpGet]
    [Route("api/Games/{id}")]
    public async Task<ActionResult<GameDTO>> GetGame(long id)
	{
		var game = await games.Get(id);

		if (game == null)
			return NotFound();

		return game.AsDTO();
	}

	[HttpPut]
    [Route("api/Games")]
    public async Task<IActionResult> UpdateGame([FromBody] Game game)
	{
        try
        {
            await games.Update(game);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await games.Exists(game.Id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
	}

	[HttpPost]
    [Route("api/Games")]
    public async Task<ActionResult<GameDTO>> CreateGame(Game game)
	{
		await games.Add(game);

		return CreatedAtAction(nameof(GetGame), new { id = game.Id });
	}

	[HttpDelete]
    [Route("api/Games/{id}")]
    public async Task<IActionResult> DeleteGame(long id)
	{
        var game = await games.Get(id);

        if (game == null)
            return NotFound();
        
        await games.Delete(game);        

        return NoContent();
	}	
}
