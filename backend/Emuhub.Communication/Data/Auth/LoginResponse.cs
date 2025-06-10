namespace Emuhub.Communication.Data.Auth;

public class LoginResponse
{
    public Guid UserId { get; set; }
    public string ProfileImageBase64 { get; set; } = "";
    public required UserTokensResponse UserTokens { get; set; }
}