namespace Emuhub.Domain.Entities.Games;

public class Game
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string ImageName { get; set; } = "";
    public string FileName { get; set; } = "";

    // Foreign Keys
    public required long CategoryId { get; set; }
    public required long EmulatorId { get; set; }

    // Navigation Properties    
    public GameCategory? Category { get; set; }
    public Emulator? Emulator { get; set; }
}
