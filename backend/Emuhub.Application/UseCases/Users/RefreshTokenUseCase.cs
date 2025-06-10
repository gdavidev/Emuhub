using Emuhub.Communication.Data.Auth;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Services.Authentication;

namespace Emuhub.Application.UseCases.Users;

public class RefreshTokenUseCase(AuthService authService)
{
    public async Task<UserTokensResponse> Execute(RefreshTokenRequest request)
    {
        Validate(request);

        return await authService.RefreshToken(request);
    }

    private static void Validate(RefreshTokenRequest request)
    {
        if (request.UserId == Guid.Empty)
            throw new ValidationErrorException(new ValidationErrorItem("UserId", ExceptionMessagesResource.NAME_EMPTY));
    }
}