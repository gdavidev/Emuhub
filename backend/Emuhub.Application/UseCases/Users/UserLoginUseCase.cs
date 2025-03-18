using Emuhub.Application.Validation;
using Emuhub.Communication.Data.Auth;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Services.Authentication;

namespace Emuhub.Application.UseCases.Users
{
    public class UserLoginUseCase(AuthService authService)
    {
        public async Task<LoginResponse> Execute(LoginRequest request)
        {
            request = Sanitized(request);
            Validate(request);

            return await authService.Login(request);
        }

        public static LoginRequest Sanitized(LoginRequest request)
        {
            request.Email = request.Email.Trim().ToLower();
            request.Password = request.Password.Trim();

            return request;
        }

        public static void Validate(LoginRequest request)
        {
            var errors = new List<ValidationErrorItem>();

            if (!EmailValidator.IsEmailValid(request.Email))
                errors.Add(new ValidationErrorItem("Email", ExceptionMessagesResource.NAME_EMPTY));
            if (request.Password is null || request.Password.Equals(string.Empty))
                errors.Add(new ValidationErrorItem("Password", ExceptionMessagesResource.NAME_EMPTY));

            if (errors.Count > 0)
                throw new ValidationErrorException(errors);
        }        
    }
}
