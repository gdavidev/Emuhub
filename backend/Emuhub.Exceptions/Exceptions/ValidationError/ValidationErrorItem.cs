namespace Emuhub.Exceptions.Exceptions.ValidationError
{
    public class ValidationErrorItem(string propertyName, string message)
    {
        public string PropertyName { get; set; } = propertyName;
        public string Message { get; set; } = message;
    }
}
