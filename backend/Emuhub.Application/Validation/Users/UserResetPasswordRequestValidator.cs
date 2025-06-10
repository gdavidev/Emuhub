using Emuhub.Application.Validation.ValidatorExtensions;
using Emuhub.Communication.Data.Users;
using FluentValidation;

namespace Emuhub.Application.Validation.Users;

public class UserResetPasswordRequestValidator : AbstractValidator<UserResetPasswordRequest>
{
    public UserResetPasswordRequestValidator()
    {
        RuleFor(req => req.RetrievalToken)
            .NotNullOrEmpty();

        RuleFor(req => req.NewPassword)
            .Password();
    }
}