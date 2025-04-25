using Emuhub.Communication.Data.PostCategories;
using Emuhub.Domain.Entities.Forum;

namespace Emuhub.Application.Serialization
{
    public class PostCategorySerializer
    {
        public static PostCategoryResponse ToPostCategoryResponse(PostCategory category) =>
            new PostCategoryResponse()
            {
                Id = category.Id,
                Name = category.Name,
            };
    }
}
