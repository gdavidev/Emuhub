using Emuhub.Application.UseCases.Emulators;
using Emuhub.Communication.Data.Emulators;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmulatorsController : ControllerBase
{
    [HttpGet("List")]
    public async Task<ActionResult<IEnumerable<EmulatorResponse>>> GetEmulators(
        [FromServices] EmulatorGetUseCase useCase)
    {
        var result = await useCase.Execute();

        return result;
    }

    [HttpGet("Get/{id:long}")]
    public async Task<ActionResult<EmulatorResponse>> GetEmulator(
        [FromServices] EmulatorGetByIdUseCase useCase,
        [FromRoute] long id)
    {
        var result = await useCase.Execute(id);

        return result;
    }
}
