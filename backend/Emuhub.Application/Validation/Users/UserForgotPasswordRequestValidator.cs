using Emuhub.Communication.Data.Users;
using FluentValidation;

namespace Emuhub.Application.Validation.Users;

public class UserForgotPasswordRequestValidator : AbstractValidator<UserForgotPasswordRequest>
{
    public UserForgotPasswordRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress();
    }
}