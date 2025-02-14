namespace Emuhub.Communication.Exceptions;

public class ValidationErrorException : Exception
{
    public List<KeyValuePair<string, string>> Errors = [];
}
