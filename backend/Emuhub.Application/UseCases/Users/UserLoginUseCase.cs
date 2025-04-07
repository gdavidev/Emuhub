using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Auth;
using Emuhub.Infrastructure.Services.Authentication;
using FluentValidation;

namespace Emuhub.Application.UseCases.Users
{
    public class UserLoginUseCase(AuthService authService, LoginRequestValidator validator)
    {
        public async Task<LoginResponse> Execute(LoginRequest request)
        {
            request = Sanitized(request);
            validator.ValidateAndThrow(request);

            return await authService.Login(request);
        }

        public static LoginRequest Sanitized(LoginRequest request)
        {
            request.Email = request.Email.Trim().ToLower();
            request.Password = request.Password.Trim();

            return request;
        }    
    }
}
