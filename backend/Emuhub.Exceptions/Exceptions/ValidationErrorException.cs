namespace Emuhub.Exceptions.Exceptions
{
    public class ValidationErrorException(List<object> errors) : EmuhubCheckedException
    {
        public List<object> Errors = errors;
    }
}
