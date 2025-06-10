namespace Emuhub.Communication.Data.Error;

public class ErrorResponseDetail
{
    public required string PropertyName { get; set; }
    public required List<string> Errors { get; set; }
}