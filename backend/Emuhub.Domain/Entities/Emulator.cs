namespace Emuhub.Domain.Entities;

public class Emulator
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string CompanyName { get; set; }
    public required string Abbreviation { get; set; }
    public required string Console { get; set; }
}
