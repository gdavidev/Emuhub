using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Domain.Entities.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Communication.Data.Emulators;

namespace Emuhub.API.Controllers;

[ApiController]
public class EmulatorsController(IEmulatorRepository emulators) : ControllerBase
{
    //[HttpGet]
    //[Route("api/Emulators")]
    //public async Task<ActionResult<IEnumerable<EmulatorResponse>>> GetEmulators([FromQuery] int page)
    //{
    //    List<Emulator> gameList = await emulators.GetAll(page);
    //    List<EmulatorResponse> dtoList = gameList.Select(g => g.AsResponse()).ToList();

    //    return dtoList; 
    //}

    //[HttpGet]
    //[Route("api/Emulators/{id}")]
    //public async Task<ActionResult<EmulatorResponse>> GetEmulator(long id)
    //{
    //    var game = await emulators.Get(id);

    //    if (game == null)
    //        return NotFound();

    //    return game.AsResponse();
    //}

    //[HttpPut]
    //[Route("api/Emulators")]
    //public async Task<IActionResult> UpdateEmulator([FromBody] Emulator game)
    //{
    //    try
    //    {
    //        await emulators.Update(game);
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!await emulators.Exists(game.Id))
    //            return NotFound();
    //        else
    //            throw;
    //    }

    //    return NoContent();
    //}

    //[HttpPost]
    //[Route("api/Emulators")]
    //public async Task<ActionResult<EmulatorResponse>> CreateEmulator(Emulator game)
    //{
    //    await emulators.Add(game);

    //    return CreatedAtAction(nameof(GetEmulator), new { id = game.Id });
    //}

    //[HttpDelete]
    //[Route("api/Emulators/{id}")]
    //public async Task<IActionResult> DeleteEmulator(long id)
    //{
    //    var game = await emulators.Get(id);

    //    if (game == null)
    //        return NotFound();

    //    await emulators.Delete(game);

    //    return NoContent();
    //}
}
