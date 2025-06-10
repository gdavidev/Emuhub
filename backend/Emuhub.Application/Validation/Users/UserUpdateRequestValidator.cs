using Emuhub.Application.Validation.ValidatorExtensions;
using Emuhub.Communication.Data.Users;
using Emuhub.Exceptions;
using FluentValidation;

namespace Emuhub.Application.Validation.Users;

public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateRequestValidator()
    {
        RuleFor(x => x.UserId).NotNullOrEmpty();

        When(req => req.UserName is not null, () =>
        {
            RuleFor(req => req.UserName!)
                .NotNullOrEmpty()
                .MinimumLength(6).WithMessage(string.Format(ExceptionMessagesResource.MINIMUN_LENGTH, 6));
        });

        When(req => req.Email is not null, () =>
        {
            RuleFor(req => req.Email!)
                .EmailAddress().WithMessage(ExceptionMessagesResource.EMAIL_EMPTY);
        });

        When(req => req.Password is not null, () =>
        {
            RuleFor(req => req.Password!)
                .Password();
        });

        When(req => req.ProfileImage is not null, () =>
        {
            RuleFor(req => req.ProfileImage!)
                .FileOfType([".png", ".jpg", ".jpeg", ".gif"]);
        });
    }
}