using Emuhub.Exceptions;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Emuhub.Application.Validation
{
    public partial class PasswordValidator<T> : IPropertyValidator<T, string>
    {
        [GeneratedRegex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")]
        private static partial Regex PasswordPattern();

        public string Name => "PasswordValidator";

        public bool IsValid(ValidationContext<T> context, string password)
        {
            if (password == null)
            {
                context.AddFailure(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL);
                return false;
            }
            if (password == string.Empty)
            {
                context.AddFailure(ExceptionMessagesResource.FIELD_CANNOT_BE_EMPTY);
                return false;
            }
            if (password.Length < 8)
            {
                context.AddFailure(ExceptionMessagesResource.PASSWORD_TOO_SHORT);
                return false;
            }
            if (PasswordPattern().IsMatch(password))
            {
                context.AddFailure(ExceptionMessagesResource.PASSWORD_INVALID);
                return false;
            }

            return true;
        }

        public string GetDefaultMessageTemplate(string errorCode)
        {
            throw new NotImplementedException();
        }
    }
}
