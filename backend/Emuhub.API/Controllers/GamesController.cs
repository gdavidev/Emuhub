using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data.Games;
using Emuhub.Application.UseCases.Games;

namespace Emuhub.API.Controllers;

[ApiController]
public class GamesController : ControllerBase
{
	[HttpGet]
    [Route("api/Games")]
    public async Task<ActionResult<IEnumerable<GameResponse>>> GetGames(
        [FromServices] GameGetUseCase useCase,
        [FromQuery] int page)
	{
		var result = await useCase.Execute(page);

        return result;
    }

	[HttpGet]
    [Route("api/Games/{id}")]
    public async Task<ActionResult<GameResponse>> GetGame(
        [FromServices] GameGetByIdUseCase useCase,
        [FromRoute] long id)
	{
        var result = await useCase.Execute(id);

		return result;
	}

	[HttpPut]
    [Route("api/Games")]
    public async Task<IActionResult> UpdateGame(
        [FromServices] GameUpdateUseCase useCase,
        [FromBody] GameUpdateRequest request)
	{
        await useCase.Execute(request);

        return NoContent();
	}

	[HttpPost]
    [Route("api/Games")]
    public async Task<ActionResult<GameResponse>> CreateGame(
        [FromServices] GameCreateUseCase useCase,
        [FromBody] GameCreateRequest request)
	{
        var result = await useCase.Execute(request);

		return CreatedAtAction(nameof(GetGame), new { id = result });
	}

	[HttpDelete]
    [Route("api/Games/{id}")]
    public async Task<IActionResult> DeleteGame(
        [FromServices] GameDeleteUseCase useCase,
        [FromRoute] long id)
	{
        await useCase.Execute(id);

        return NoContent();
	}	
}
