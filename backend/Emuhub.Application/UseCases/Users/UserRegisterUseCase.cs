using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Auth;
using Emuhub.Infrastructure.Services.Authentication;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;

namespace Emuhub.Application.UseCases.Users
{
    public class UserRegisterUseCase(AuthService authService, RegisterRequestValidator validator, IFileStorageService storageService)
    {
        public async Task Execute(RegisterRequest request)
        {
            request = Sanitized(request);
            validator.ValidateAndThrow(request);

            await authService.Register(request);
            await storageService.UploadAsync(request.ProfileImage);
        }

        public static RegisterRequest Sanitized(RegisterRequest request)
        {
            request.Email = request.Email.Trim().ToLower();

            return request;
        }     
    }
}
