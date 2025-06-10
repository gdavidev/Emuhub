namespace Emuhub.Communication.Data.Auth;

public class UserTokensResponse
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}