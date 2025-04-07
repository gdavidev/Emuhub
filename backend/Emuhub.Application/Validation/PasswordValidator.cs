using Emuhub.Exceptions;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Emuhub.Application.Validation
{
    public partial class PasswordValidator : AbstractValidator<string>
    {
        [GeneratedRegex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")]
        private static partial Regex PasswordPattern();

        public PasswordValidator()
        {
            RuleFor(password => password)
                .NotNull()
                .MinimumLength(8)
                .Matches(PasswordPattern())
                .WithMessage(ExceptionMessagesResource.PASSWORD_INVALID); 
        }     
    }
}
