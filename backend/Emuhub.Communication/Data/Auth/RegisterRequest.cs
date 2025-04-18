using Microsoft.AspNetCore.Http;

namespace Emuhub.Communication.Data.Auth
{
    public class RegisterRequest
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required IFormFile ProfileImage { get; set; }
    }
}
