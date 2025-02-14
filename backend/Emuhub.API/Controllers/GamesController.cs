using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data;
using Emuhub.Domain.Entities;
using Emuhub.Infrastructure.Repositories;

namespace Emuhub.API.Controllers;

[ApiController]
public class GamesController(GameRepository games) : ControllerBase
{
	[HttpGet]
    [Route("api/Game")]
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
    public async Task<IActionResult> PutGame([FromBody] Game game)
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
    public async Task<ActionResult<GameDTO>> PostGame(Game game)
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
