using Microsoft.AspNetCore.Http;

namespace Emuhub.Communication.Data.Users;

public class UserUpdateRequest
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public IFormFile? ProfileImage { get; set; }
}