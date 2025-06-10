namespace Emuhub.Communication.Data.Error;

public class ErrorResponse
{
    public required int StatusCode { get; init; }
    public required string Message { get; init; }
    public required List<ErrorResponseDetail> Errors { get; init; }
}
