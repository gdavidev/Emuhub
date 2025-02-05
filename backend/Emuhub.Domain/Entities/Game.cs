namespace Emuhub.Domain.Entities;

public class Game
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int CategoryId { get; set; }
    public string? Image { get; set; }
}
