using Emuhub.Domain.Entities.Users;

namespace Emuhub.Domain.Entities.Forum;

public class Post
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime CreateAt { get; set; }
    public required DateTime UpdatedOn { get; set; }
    public required bool IsActive { get; set; }

    public required string UserId { get; set; }

    public List<Comment> Comments { get; set; } = [];
	public User? Author { get; set; }
    public PostCategory? Category { get; set; }
}
