namespace Emuhub.Exceptions.Exceptions;

public class ResourceNotFoundException(string resourceName, string message) : EmuhubCheckedException
{
    public string ResourceName { get; set; } = resourceName;
    public string ErrorMessage { get; set; } = message;

    public static void ThrowIfNull(object? value, string resourceName, string message)
    {
        if (value is null)
            throw new ResourceNotFoundException(resourceName, message);
    }
}