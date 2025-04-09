using Emuhub.Exceptions;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.Validation
{
    public enum FileType
    {
        IMAGE,
        ARCHIVE
    }

    public class FileValidator<T>(FileType fileType) : IPropertyValidator<T, IFormFile>
    {
        public static readonly Dictionary<FileType, string[]> AllowedExtensions = new()
        {
            { FileType.IMAGE, new[] { ".png", ".jpg", ".jpeg", ".gif" } },
            { FileType.ARCHIVE, new[] { ".zip", ".7z", ".rar" } },
        };
        public string Name => "FileValidator";        

        public bool IsValid(ValidationContext<T> context, IFormFile file)
        {
            if (file == null)
            {
                context.AddFailure(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL);
                return false;
            }

            if (file.Length <= 0)
            {
                context.AddFailure(ExceptionMessagesResource.FIELD_CANNOT_BE_EMPTY);
                return false;
            }

            var ext = Path.GetExtension(file.FileName.ToLower());
            var allowed = GetAllowedExtensions(fileType);

            if (string.IsNullOrWhiteSpace(ext) || !allowed.Contains(ext))
            {
                context.AddFailure(string.Format(ExceptionMessagesResource.FILE_EXTENSION_MUST_BE, string.Join(", ", allowed)));
                return false;
            }

            return true;
        }

        public string GetDefaultMessageTemplate(string errorCode)
        {
            throw new NotImplementedException();
        }

        public static string[] GetAllowedExtensions(FileType type)
        {
            return AllowedExtensions.TryGetValue(type, out var list) ? list : [];
        }
    }
}
