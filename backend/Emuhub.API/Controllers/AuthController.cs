using Emuhub.Application.UseCases.Users;
using Emuhub.Communication.Data.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(
            [FromServices] UserRegisterUseCase useCase,
            [FromForm] RegisterRequest request)
        {
            await useCase.Execute(request);

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(
            [FromServices] UserLoginUseCase useCase,
            [FromBody] LoginRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<UserTokensResponse>> RefreshToken(
            [FromServices] RefreshTokenUseCase useCase,
            [FromBody] RefreshTokenRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteUser() 
        {
            throw new NotImplementedException();
        }

        [HttpPut("Update")]
        public IActionResult UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
