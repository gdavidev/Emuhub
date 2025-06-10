using Emuhub.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.Validation.ValidatorExtensions;

public static class FileValidationExtensions
{
    public static IRuleBuilder<T, IFormFile> FileOfType<T>(
        this IRuleBuilder<T, IFormFile> rule,
        string[] allowedExtensions)
    {
        rule.Must(file =>
            {
                if (file is null)
                    return false;
                var ext = Path.GetExtension(file.FileName)?.ToLowerInvariant();
                return !string.IsNullOrWhiteSpace(ext) && allowedExtensions.Contains(ext);
            })
            .WithMessageFormat(
                ExceptionMessagesResource.FILE_EXTENSION_MUST_BE,
                string.Join(", ", allowedExtensions));

        return rule;
    }
}