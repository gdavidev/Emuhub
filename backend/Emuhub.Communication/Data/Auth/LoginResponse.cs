namespace Emuhub.Communication.Data.Auth;

public class LoginResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public string ProfileImageBase64 { get; set; } = "";
    public required UserTokensResponse UserTokens { get; set; }
}