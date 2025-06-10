using Emuhub.Application.UseCases.GameCategories;
using Emuhub.Communication.Data.GameCategories;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameCategoryController : ControllerBase
{
    [HttpGet("List")]
    public async Task<ActionResult<IEnumerable<GameCategoryResponse>>> GetCategories(
        [FromServices] GameCategoriesGetUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }
}