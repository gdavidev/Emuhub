using Emuhub.Application.UseCases.PostCategories;
using Emuhub.Communication.Data.PostCategories;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers
{
    [ApiController]
    public class PostCategoryController : ControllerBase
    {
        [HttpGet]
        [Route("api/PostCategories/List")]
        public async Task<ActionResult<IEnumerable<PostCategoryResponse>>> GetCategories(
            [FromServices] PostCategoriesGetUseCase useCase)
        {
            return await useCase.Execute();
        }
    }
}
