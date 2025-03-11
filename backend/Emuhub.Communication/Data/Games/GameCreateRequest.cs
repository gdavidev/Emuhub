using Emuhub.Domain.Entities.Games;

namespace Emuhub.Communication.Data.Games
{
    public class GameCreateRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required long CategoryId { get; set; }
        public required long EmulatorId { get; set; }
        public required IFormFile File { get; set; }
        public required IFormFile Image { get; set; }

        public Game AsGame(Emulator emulator, GameCategory category)
        {
            return new Game()
            {
                Id = 0,
                Name = Name,
                Description = Description,
                Category = category,
                Emulator = emulator,
                Image = Image,
                File = File
            };
        }
    }
}
