namespace Emuhub.Exceptions.Exceptions.ValidationError;

public class ValidationErrorException : EmuhubCheckedException
{
    public List<ValidationErrorItem> Errors;

    public ValidationErrorException(List<ValidationErrorItem> errors)
    {
        Errors = errors;
    }

    public ValidationErrorException(ValidationErrorItem error)
    {
        Errors = [error];
    }
}