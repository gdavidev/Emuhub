using System.ComponentModel.DataAnnotations;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Communication.Data.Games;

public class GameResponse
{
    public required long  Id { get; set; }
    public required string  Name { get; set; }
    public required string  Description { get; set; }
    public required Emulator  Emulator { get; set; }
    public required GameCategory Category { get; set; }
}
