using Emuhub.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.Validation
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public static readonly string[] IMAGE_EXTENSIONS = [".png", ".jpg", ".jpeg", ".gif"];

        public FileValidator(string[] allowedExtensions) 
        {
            RuleFor(file => file.Length)
                .GreaterThan(0).WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_EMPTY);

            RuleFor(file => Path.GetExtension(file.Name.ToLower()))
                .NotEmpty().WithMessage(ExceptionMessagesResource.FILE_MUST_HAVE_EXTENSION)
                .Must(ext => allowedExtensions.Contains(ext))
                    .WithMessageFormat(ExceptionMessagesResource.FILE_EXTENSION_MUST_BE, string.Join(", ", allowedExtensions));
        }
    }
}
