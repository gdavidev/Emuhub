using Emuhub.Communication.Data.Auth;
using Emuhub.Infrastructure.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AuthService authService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await authService.Register(request);

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginRequest request)
        {
            var token = await authService.Login(request);

            return Ok(token);
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

        [Authorize]
        [HttpGet("AuthorizedOnly")]
        public IActionResult AuthorizedOnly()
        {
            return Ok("Gone well");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AdminOnly")]
        public IActionResult AdminOnly()
        {
            return Ok("Gone well");
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet("ModeratorOrAdminOnly")]
        public IActionResult ModeratorOrAdminOnly()
        {
            return Ok("Gone well");
        }
    }
}
