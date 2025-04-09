using Emuhub.Communication.Data.Auth;
using Emuhub.Exceptions;
using FluentValidation;

namespace Emuhub.Application.Validation.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator() 
        {
            RuleFor(req => req.UserName)
                .NotNullOrEmpty()
                .MinimumLength(6).WithMessage(string.Format(ExceptionMessagesResource.MINIMUN_LENGTH, 6));

            RuleFor(req => req.Email)
                .EmailAddress().WithMessage(ExceptionMessagesResource.EMAIL_EMPTY);

            RuleFor(req => req.Password)
                .Password();

            RuleFor(req => req.ProfileImage)
                .FileOfType(FileType.IMAGE);
        }
    }
}
