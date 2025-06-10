using Emuhub.Communication.Data.GameCategories;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Application.Serialization;

public class GameCategorySerializer
{
    public static GameCategoryResponse ToResponse(GameCategory category) =>
        new GameCategoryResponse()
        {
            Id = category.Id,
            Name = category.Name,
        };
}