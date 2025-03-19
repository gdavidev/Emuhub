using Emuhub.Exceptions.Exceptions.ValidationError;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.Validation
{
    public static class FileValidator
    {
        public static bool Validate(IFormFile file, string[] allowedExtensions)
        {
            if (file is null || file.Length <= 0)
                throw new ValidationErrorException(new ValidationErrorItem("File", "Cannot be null or empty"));
            
            var extension = Path.GetExtension(file.Name.ToLower());
            if (!allowedExtensions.Contains(extension))
                throw new ValidationErrorException(new ValidationErrorItem("File", $"Only {string.Join(", ", allowedExtensions)} are allowed extensions"));

            return true;
        }
    }
}
