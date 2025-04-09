using Emuhub.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.Validation
{
    internal static class ValidatorRuleBuilderExtensions
    {        
        public static IRuleBuilderOptions<T, TProperty> WithMessageFormat<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule,
            string format,
            params string[] args)
        {
            return rule.WithMessage(string.Format(format, args));
        }

        public static IRuleBuilderOptions<T, TProperty> NotNullOrEmpty<T, TProperty>(
            this IRuleBuilder<T, TProperty> rule)
        {
            return rule
                .NotNull().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL)
                .NotEmpty().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_EMPTY);
        }

        public static IRuleBuilderOptions<T, long> DatabaseIdentity<T>(
            this IRuleBuilder<T, long> rule)
        {
            return rule
                .NotNull().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL)
                .GreaterThan(0).WithMessage(ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO);
        }

        public static IRuleBuilderOptions<T, IFormFile> FileOfType<T>(
            this IRuleBuilder<T, IFormFile> rule,
            FileType fileType)
        {
            return rule.SetValidator(new FileValidator<T>(fileType));
        }

        public static IRuleBuilderOptions<T, string> Password<T>(
            this IRuleBuilder<T, string> rule)
        {
            return rule.SetValidator(new PasswordValidator<T>());
        }
    }
}
