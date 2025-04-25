using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.PostCategories;
using Emuhub.Infrastructure.Repositories.Abstractions;

namespace Emuhub.Application.UseCases.PostCategories
{
    public class PostCategoriesGetUseCase(IPostCategoryRepository categories)
    {
        public async Task<List<PostCategoryResponse>> Execute()
        {
            var categoryList = await categories.GetAll();
            var result = categoryList.Select(PostCategorySerializer.ToPostCategoryResponse).ToList();

            return result;
        }
    }
}
