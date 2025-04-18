namespace Emuhub.Communication.Data;

public class ErrorResponse(List<object> errors)
{
    public List<object> Errors = errors;
}
