using Microsoft.AspNetCore.Http;

namespace Emuhub.Communication.Data.Games;

public class GameCreateRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required long CategoryId { get; set; }
    public required long EmulatorId { get; set; }
    public required IFormFile File { get; set; }
    public required IFormFile Image { get; set; }
}