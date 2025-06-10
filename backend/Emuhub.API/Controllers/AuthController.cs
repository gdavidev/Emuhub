using Emuhub.Application.UseCases.Users;
using Emuhub.Communication.Data.Auth;
using Emuhub.Communication.Data.Users;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
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
        
    [HttpPost("ResetPasswordPassword")]
    public async Task<ActionResult> ResetPasswordPassword(
        [FromServices] UserResetPasswordUseCase useCase,
        [FromBody] UserResetPasswordRequest request)
    {
        await useCase.Execute(request);
        return NoContent();
    }
        
    [HttpPost("ForgotPassword")]
    public async Task<ActionResult> ForgotPassword(
        [FromServices] UserForgotPasswordUseCase useCase,
        [FromBody] UserForgotPasswordRequest request)
    {
        await useCase.Execute(request);
        return NoContent();
    }
        
    [HttpDelete("Delete")]
    public async Task<ActionResult> DeleteUser(
        [FromServices] UserDeleteUseCase useCase,
        [FromBody] UserDeleteRequest request) 
    {
        await useCase.Execute(request);
        return NoContent();
    }

    [HttpPatch("Update")]
    public async Task<ActionResult> UpdateUser(
        [FromServices] UserUpdateUseCase useCase,
        [FromBody] UserUpdateRequest request) 
    {
        await useCase.Execute(request);
        return NoContent();
    }
}