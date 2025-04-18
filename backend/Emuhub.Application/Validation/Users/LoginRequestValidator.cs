using Emuhub.Communication.Data.Auth;
using Emuhub.Exceptions;
using FluentValidation;

namespace Emuhub.Application.Validation.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() 
        {
            RuleFor(req => req.Email)
                .NotNullOrEmpty()
                .EmailAddress().WithMessage(ExceptionMessagesResource.EMAIL_INVALID);

            RuleFor(req => req.Password)
                .Password();
        }
    }
}
