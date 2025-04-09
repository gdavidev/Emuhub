using Emuhub.Application.Validation;
using Emuhub.TestingUtilities.Data;
using FluentValidation;

namespace Emuhub.ApplicationTest.Validation
{
    public class FileValidatorTest
    {
        [Fact]
        public void Validate_ThrowValidationErrorException_UnexpectedFileFormat()
        {
            string[] expectedExtensions = [".zip", ".7z"];
            var sampleFile = new FormFileMock("file.png", 1024);
                            
            var exception = Assert.Throws<ValidationException>(() =>
            {
                new FileValidator(FileType.COMPACT).Validate(sampleFile.Object);
            });

            Assert.Single(exception.Errors);
            Assert.Equal("Arquivo deve ser do tipo (.zip, .7z) apenas", exception.Errors.First().ErrorMessage);
        }
    }
}
