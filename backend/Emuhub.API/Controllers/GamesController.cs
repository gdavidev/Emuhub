using Microsoft.AspNetCore.Mvc;
using Emuhub.Communication.Data.Games;
using Emuhub.Application.UseCases.Games;
using Emuhub.Communication.Data;
using Microsoft.AspNetCore.Authorization;

namespace Emuhub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
	[HttpGet("List")]
    public async Task<ActionResult<IEnumerable<GameResponse>>> GetGames(
        [FromServices] GameGetUseCase useCase,
        [FromQuery] int page)
	{
		var result = await useCase.Execute(page);
        return Ok(result);
    }

	[HttpGet("Get/{id:Guid}")]    
    public async Task<ActionResult<GameResponse>> GetGame(
        [FromServices] GameGetByIdUseCase useCase,
        [FromRoute] Guid id)
	{
        var result = await useCase.Execute(id);
		return Ok(result);
	}
	
	[HttpGet("Search")]    
	public async Task<ActionResult<GameResponse>> SearchGame(
		[FromServices] GameSearchUseCase useCase,
		[FromQuery] string search)
	{
		var result = await useCase.Execute(search);
		return Ok(result);
	}
	
	[HttpGet("Download/{emulatorAbbreviation}/{gameName}")]
	public async Task<ActionResult<GameResponse>> DownloadGame(
		[FromServices] GameDownloadUseCase useCase,
		[FromRoute] string emulatorAbbreviation,
		[FromRoute] string gameName)
	{
		var (fileStream, contentType) = await useCase.Execute(
			emulatorAbbreviation,
			gameName);
		return File(fileStream, contentType);
	}

	[Authorize(Roles = "Admin")]
	[HttpPut("Update")]    
    public async Task<IActionResult> UpdateGame(
        [FromServices] GameUpdateUseCase useCase,
        [FromForm] GameUpdateRequest request)
	{
        await useCase.Execute(request);
        return NoContent();
	}

	[Authorize(Roles = "Admin")]
	[HttpPost("Create")]    
    public async Task<ActionResult<GameResponse>> CreateGame(
        [FromServices] GameCreateUseCase useCase,
        [FromForm] GameCreateRequest request)
	{
        var result = await useCase.Execute(request);
		return Created("/Get/{id:long}", new { id = result });
	}

	[Authorize(Roles = "Admin")]
	[HttpDelete("Delete")]
    public async Task<IActionResult> DeleteGame(
        [FromServices] GameDeleteUseCase useCase,
        [FromQuery] EntityIdRequest request)
	{
        await useCase.Execute(request);
        return NoContent();
	}	
}
