using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data;
using Emuhub.Domain.Entities;
using Emuhub.Infrastructure.DataAccess;

namespace Emuhub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(ApplicationDbContext context) : ControllerBase
{
	private readonly ApplicationDbContext _context = context;

	[HttpGet]
	public async Task<ActionResult<IEnumerable<GameDTO>>> GetGames()
	{
		return await _context.Games
				.AsNoTracking()
				.Select(g => g.AsDTO())
				.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<GameDTO>> GetGame(long id)
	{
		var game = await _context.Games.FindAsync(id);

		if (game == null)
			return NotFound();

		return game.AsDTO();
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutGame(long id, Game game)
	{
		if (id != game.Id)
		{
			return BadRequest();
		}

		_context.Entry(game).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!GameExists(id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}

		return NoContent();
	}

	[HttpPost]
	public async Task<ActionResult<GameDTO>> PostGame(Game game)
	{
		_context.Games.Add(game);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game.AsDTO());
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteGame(long id)
	{
		var game = await _context.Games.FindAsync(id);
		if (game == null)
		{
			return NotFound();
		}

		_context.Games.Remove(game);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool GameExists(long id)
	{
		return _context.Games.Any(e => e.Id == id);
	}
}
