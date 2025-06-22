using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Auth;
using Emuhub.Infrastructure.Services.Authentication;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;

namespace Emuhub.Application.UseCases.Users;

public class UserRegisterUseCase(AuthService authService, RegisterRequestValidator validator, IFileStorageService storageService)
{
    public async Task Execute(RegisterRequest request)
    {
        await validator.ValidateAndThrowAsync(request);
        request = Sanitized(request);

        var userGuid = await authService.Register(request);
        
        if (request.ProfileImage is not null)
        {
            var image = request.ProfileImage;
            var profileFileName = $"profile{Path.GetExtension(image.FileName)}";

            await storageService.UploadAsync(
                "users",
                image.OpenReadStream(),
                $"{userGuid}/{profileFileName}",
                image.ContentType
            );
        }
    }

    private static RegisterRequest Sanitized(RegisterRequest request)
    {
        request.Email = request.Email.Trim().ToLower();
        return request;
    }     
}