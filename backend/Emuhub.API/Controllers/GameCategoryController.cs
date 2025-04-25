using Emuhub.Application.UseCases.GameCategories;
using Emuhub.Communication.Data.GameCategories;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers
{
    [ApiController]
    public class GameCategoryController : ControllerBase
    {
        [HttpGet]
        [Route("api/GameCategories/List")]
        public async Task<ActionResult<IEnumerable<GameCategoryResponse>>> GetCategories(
            [FromServices] GameCategoriesGetUseCase useCase)
        {
            return await useCase.Execute();
        }
    }
}
