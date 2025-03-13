using Emuhub.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emuhub.Communication.Data.Games
{
    public class GameUpdateRequest
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required long CategoryId { get; set; }
        public required long EmulatorId { get; set; }
        public IFormFile? File { get; set; }
        public IFormFile? Image { get; set; }
    }
}
