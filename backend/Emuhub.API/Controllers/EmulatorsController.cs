using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.API.Controllers;

[ApiController]
public class EmulatorsController(EmulatorRepository emulators) : ControllerBase
{
    [HttpGet]
    [Route("api/Emulators")]
    public async Task<ActionResult<IEnumerable<EmulatorDTO>>> GetEmulators([FromQuery] int page)
    {
        List<Emulator> gameList = await emulators.GetAll(page);
        List<EmulatorDTO> dtoList = gameList.Select(g => g.AsDTO()).ToList();

        return dtoList; 
    }

    [HttpGet]
    [Route("api/Emulators/{id}")]
    public async Task<ActionResult<EmulatorDTO>> GetEmulator(long id)
    {
        var game = await emulators.Get(id);

        if (game == null)
            return NotFound();

        return game.AsDTO();
    }

    [HttpPut]
    [Route("api/Emulators")]
    public async Task<IActionResult> UpdateEmulator([FromBody] Emulator game)
    {
        try
        {
            await emulators.Update(game);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await emulators.Exists(game.Id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpPost]
    [Route("api/Emulators")]
    public async Task<ActionResult<EmulatorDTO>> CreateEmulator(Emulator game)
    {
        await emulators.Add(game);

        return CreatedAtAction(nameof(GetEmulator), new { id = game.Id });
    }

    [HttpDelete]
    [Route("api/Emulators/{id}")]
    public async Task<IActionResult> DeleteEmulator(long id)
    {
        var game = await emulators.Get(id);

        if (game == null)
            return NotFound();

        await emulators.Delete(game);

        return NoContent();
    }
}
