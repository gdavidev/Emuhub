using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data.Games;
using Emuhub.Application.UseCases.Games;
using Emuhub.Communication.Data;

namespace Emuhub.API.Controllers;

[ApiController]
public class GamesController : ControllerBase
{
	[HttpGet]
    [Route("api/Games/List")]
    public async Task<ActionResult<IEnumerable<GameResponse>>> GetGames(
        [FromServices] GameGetUseCase useCase,
        [FromQuery] int page)
	{
		var result = await useCase.Execute(page);

        return Ok(result);
    }

	[HttpGet]
    [Route("api/Games/Get")]
    public async Task<ActionResult<GameResponse>> GetGame(
        [FromServices] GameGetByIdUseCase useCase,
        [FromQuery] EntityIdRequest request)
	{
        var result = await useCase.Execute(request);

		return Ok(result);
	}

	[HttpPut]
    [Route("api/Games/Update")]
    public async Task<IActionResult> UpdateGame(
        [FromServices] GameUpdateUseCase useCase,
        [FromBody] GameUpdateRequest request)
	{
        await useCase.Execute(request);

        return NoContent();
	}

	[HttpPost]
    [Route("api/Games/Create")]
    public async Task<ActionResult<GameResponse>> CreateGame(
        [FromServices] GameCreateUseCase useCase,
        [FromBody] GameCreateRequest request)
	{
        var result = await useCase.Execute(request);

		return CreatedAtAction(nameof(GetGame), new { id = result });
	}

	[HttpDelete]
    [Route("api/Games/Delete")]
    public async Task<IActionResult> DeleteGame(
        [FromServices] GameDeleteUseCase useCase,
        [FromQuery] EntityIdRequest request)
	{
        await useCase.Execute(request);

        return NoContent();
	}	
}
