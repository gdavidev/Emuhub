using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories;
using Moq;

namespace Emuhub.TestingUtilities.Infrastructure.Repositories
{
    public class EmulatorRepositoryMock : Mock<IEmulatorRepository>
    {
        public readonly List<Emulator> _emulators = [
                new Emulator()
                {
                    Id = 1,
                    Name = "Super Nintendo",
                    CompanyName = "Nintendo",
                    Abbreviation = "snes",
                    Console = "Super Nintendo",
                },
                new Emulator()
                {
                    Id = 2,
                    Name = "Nintendo 64",
                    CompanyName = "Nintendo",
                    Abbreviation = "n64",
                    Console = "Nintendo 64",
                }
            ];

        public void MockGet(long id) => Setup(r => r.Get(id)).ReturnsAsync(_emulators.First());

        public void MockGetAll(int page) => Setup(r => r.GetAll(page)).ReturnsAsync(_emulators);

        public void MockUpdate(Emulator emulator) => Setup(r => r.Update(emulator));

        public void MockAdd(Emulator emulator) => Setup(r => r.Add(emulator));

        public void MockDelete(Emulator emulator) => Setup(r => r.Delete(emulator)).Callback(() => _emulators.Remove(emulator));

        public void MockExists(long id) => Setup(r => r.Exists(id)).ReturnsAsync(_emulators.Any(g => g.Id == id));

    }
}
