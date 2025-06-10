namespace Emuhub.Communication.Data.Users;

public class UserResetPasswordRequest
{
    public string RetrievalToken { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}