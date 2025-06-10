using Emuhub.Communication.Data.Emulators;
using Emuhub.Communication.Data.GameCategories;

namespace Emuhub.Communication.Data.Games;

public class GameResponse
{
    public required long  Id { get; set; }
    public required string  Name { get; set; }
    public required string  Description { get; set; }
    public string ImageBase64 { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public required EmulatorResponse  Emulator { get; set; }
    public required GameCategoryResponse Category { get; set; }
}
