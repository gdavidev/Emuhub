using Emuhub.Domain.Entities.Users;

namespace Emuhub.Domain.Entities.Forum;

public class Comment
{
    public long Id { get; set; }
    public required string Content { get; set; }
    public required User Author { get; set; }
    public required bool IsActive { get; set; }
    public string? Image { get; set; }
    public required List<Comment> Comments { get; set; }
    public required DateTime CreateAt { get; set; }
    public required DateTime UpdatedOn { get; set; }
}
