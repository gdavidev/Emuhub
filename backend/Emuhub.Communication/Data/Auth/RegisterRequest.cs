using Microsoft.AspNetCore.Http;

namespace Emuhub.Communication.Data.Auth;

public class RegisterRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public IFormFile? ProfileImage { get; set; }
}