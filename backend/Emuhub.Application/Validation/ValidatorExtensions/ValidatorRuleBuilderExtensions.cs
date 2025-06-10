using Emuhub.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.Validation.ValidatorExtensions;

internal static class ValidatorRuleBuilderExtensions
{        
    public static IRuleBuilderOptions<T, TProperty> WithMessageFormat<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule,
        string format,
        params object?[] args)
    {
        return rule.WithMessage(string.Format(format, args));
    }

    public static IRuleBuilder<T, long> DatabaseIdentity<T>(
        this IRuleBuilder<T, long> rule)
    {
        return rule
            .NotNull().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL)
            .GreaterThan(0).WithMessage(ExceptionMessagesResource.ID_MUST_BE_GREATER_THAN_ZERO);
    }

    public static IRuleBuilderOptions<T, string> Password<T>(
        this IRuleBuilder<T, string> rule)
    {
        return rule.SetValidator(new PropertyValidators.PasswordValidator<T>());
    }
}