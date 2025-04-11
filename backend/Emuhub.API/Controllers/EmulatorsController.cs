using Emuhub.Application.UseCases.Emulators;
using Emuhub.Communication.Data;
using Emuhub.Communication.Data.Emulators;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers;

[ApiController]
public class EmulatorsController : ControllerBase
{
    [HttpGet]
    [Route("api/Emulators/List")]
    public async Task<ActionResult<IEnumerable<EmulatorResponse>>> GetEmulators(
        [FromServices] EmulatorGetUseCase useCase)
    {
        var result = await useCase.Execute();

        return result;
    }

    [HttpGet]
    [Route("api/Emulators/Get")]
    public async Task<ActionResult<EmulatorResponse>> GetEmulator(
        [FromServices] EmulatorGetByIdUseCase useCase,
        [FromQuery] EntityIdRequest request)
    {
        var result = await useCase.Execute(request);

        return result;
    }
}
