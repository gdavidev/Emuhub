namespace Emuhub.Communication.Data.Auth
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public required UserTokensResponse UserTokens { get; set; }
    }
}
