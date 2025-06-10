using Emuhub.Application.Validation.ValidatorExtensions;
using Emuhub.Communication.Data.Users;
using FluentValidation;

namespace Emuhub.Application.Validation.Users;

public class UserDeleteRequestValidator : AbstractValidator<UserDeleteRequest>
{
    public UserDeleteRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotNullOrEmpty();
    }
}