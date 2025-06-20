using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Auth;
using Emuhub.Infrastructure.Services.Authentication;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;

namespace Emuhub.Application.UseCases.Users;

public class UserLoginUseCase(
    AuthService authService,
    LoginRequestValidator validator,
    IFileStorageService storageService)
{
    public async Task<LoginResponse> Execute(LoginRequest request)
    {
        request = Sanitized(request);
        await validator.ValidateAndThrowAsync(request);

        var response = await authService.Login(request);            

        response.ProfileImageBase64 = await storageService.GetBase64Async(
            "users",
            $"{response.Id}/profile.*"
        );;

        return response;
    }

    private static LoginRequest Sanitized(LoginRequest request)
    {
        request.Email = request.Email.Trim().ToLower();
        request.Password = request.Password.Trim();

        return request;
    }    
}