using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories;
using Moq;

namespace Emuhub.TestingUtilities.Infrastructure.Repositories
{
    public class GameRepositoryMock : Mock<IGameRepository>
    {
        public readonly List<Game> _games = [
                new Game()
                {
                    Id = 1,
                    Name = "Mario",
                    Description = "Greatest game",
                    Image = "games/Mario.png",
                    File = "games/Mario.zip",
                    CategoryId = 1,
                    EmulatorId = 2,
                },
                new Game()
                {
                    Id = 2,
                    Name = "Super Metroid",
                    Description = "Favorite Game",
                    Image = "games/Super-Metroid.jpg",
                    File = "games/Super-Metroid.zip",
                    CategoryId = 2,
                    EmulatorId = 2,
                }
            ];
        public void MockAdd(Game game)
        {
            Setup(r => r.Add(game))
                .Callback(() =>
                {
                    game.Id = _games.Last().Id + 1;
                    _games.Add(game);
                })
                .ReturnsAsync(game.Id);
        }

        public void MockGet(long id) => Setup(r => r.Get(id)).ReturnsAsync(_games.First());

        public void MockGetAll(int page) => Setup(r => r.GetAll(page)).ReturnsAsync(_games);

        public void MockUpdate(Game game) => Setup(r => r.Update(game));

        public void MockDelete(Game game) => Setup(r => r.Delete(game)).Callback(() => _games.Remove(game));

        public void MockExists(long id) => Setup(r => r.Exists(id)).ReturnsAsync(_games.Any(g => g.Id == id));
    }
}
