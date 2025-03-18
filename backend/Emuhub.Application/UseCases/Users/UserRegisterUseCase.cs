using Emuhub.Application.Validation;
using Emuhub.Communication.Data.Auth;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Services.Authentication;
using Emuhub.Infrastructure.Services.Storage;

namespace Emuhub.Application.UseCases.Users
{
    public class UserRegisterUseCase(AuthService authService, IFileStorageService storageService)
    {
        public async Task Execute(RegisterRequest request)
        {
            request = Sanitized(request);
            Validate(request);

            await authService.Register(request);
            await storageService.UploadAsync(request.ProfileImage);
        }

        public static RegisterRequest Sanitized(RegisterRequest request)
        {
            request.Email = request.Email.Trim().ToLower();

            return request;
        }

        public static void Validate(RegisterRequest request)
        {
            var errors = new List<ValidationErrorItem>();

            if (!EmailValidator.IsEmailValid(request.Email))
                errors.Add(new ValidationErrorItem("Email", ExceptionMessagesResource.NAME_EMPTY));
            if (!PasswordValidator.IsPasswordValid(request.Password))
                errors.Add(new ValidationErrorItem("Password", ExceptionMessagesResource.NAME_EMPTY));

            try
            {
                FileValidator.Validate(request.ProfileImage, [".png", ".jpg", ".jpeg", ".gif"]);
            }
            catch (ValidationErrorException ex)
            {
                ex.Errors.ForEach(err => err.PropertyName = "ProfileImage");
                errors.AddRange(ex.Errors);
            }

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);
        }       
    }
}
