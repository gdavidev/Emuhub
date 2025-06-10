namespace Emuhub.Exceptions.Exceptions;

public class DuplicatedResourceException(string resourceName, string message) : Exception
{
    public string ResourceName { get; set; } = resourceName;
    public string ErrorMessage { get; set; } = message;
}