namespace Emuhub.Domain.Entities.Games;

public class Game
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required GameCategory Category { get; set; }
    public required Emulator Emulator { get; set; }
    public string? Image { get; set; }
}
