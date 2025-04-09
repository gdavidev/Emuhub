using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories;
using Moq;

namespace Emuhub.TestingUtilities.Infrastructure.Repositories
{
    public class GameCategoriesRepositoryMock : Mock<IGameCategoryRepository>
    {
        public readonly List<GameCategory> _categories = [
                new GameCategory()
                {
                    Id = 1,
                    Name = "Adventure",
                },
                new GameCategory()
                {
                    Id = 2,
                    Name = "Shooter",
                }
            ];

        public void MockGet(long id) => Setup(r => r.Get(id)).ReturnsAsync(_categories.First());

        public void MockGetAll() => Setup(r => r.GetAll()).ReturnsAsync(_categories);

        public void MockUpdate(GameCategory category) => Setup(r => r.Update(category));

        public void MockAdd(GameCategory category) => Setup(r => r.Add(category));

        public void MockDelete(GameCategory category) => Setup(r => r.Delete(category)).Callback(() => _categories.Remove(category));

        public void MockExists(long id) => Setup(r => r.Exists(id)).ReturnsAsync(_categories.Any(g => g.Id == id));
    }
}
