using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.GameCategories;
using Emuhub.Infrastructure.Repositories;

namespace Emuhub.Application.UseCases.GameCategories
{
    public class GameCategoriesGetUseCase(IGameCategoryRepository categories)
    {
        public async Task<List<GameCategoryResponse>> Execute()
        {
            var categoryList = await categories.GetAll();
            var result = categoryList.Select(GameCategorySerializer.ToResponse).ToList();

            return result;
        }
    }
}
