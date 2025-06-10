using Emuhub.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.Validation.ValidatorExtensions;

public static class NotNullOrEmptyValidatorExtensions
{
    public static IRuleBuilderOptions<T, string> NotNullOrEmpty<T>(
        this IRuleBuilder<T, string> rule)
    {
        return rule
            .Must(val => val is not null && !string.IsNullOrEmpty(val))
            .WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL_OR_EMPTY);
    }
    
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> NotNullOrEmpty<T, TElement>(
        this IRuleBuilder<T, IEnumerable<TElement>> rule)
    {
        return rule
            .Must(val => val is not null && val.Any())
            .WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL_OR_EMPTY);
    }
    
    public static IRuleBuilderOptions<T, IFormFile> NotNullOrEmpty<T>(
        this IRuleBuilder<T, IFormFile> rule)
    {
        return rule
            .Must(val => val is not null && val.Length > 0)
            .WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL_OR_EMPTY);
    }
    
    public static IRuleBuilderOptions<T, Guid> NotNullOrEmpty<T>(
        this IRuleBuilder<T, Guid> rule)
    {
        return rule
            .Must(val => val != Guid.Empty)
            .WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL_OR_EMPTY);
    }
}