namespace Emuhub.Domain.Entities.Games;

public class Game
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? Image { get; set; }
    public string? File { get; set; }

    // Foreign Keys
    public required long CategoryId { get; set; }
    public required long EmulatorId { get; set; }

    // Navigation Properties
    public GameCategory? Category { get; set; }
    public Emulator? Emulator { get; set; }
}
