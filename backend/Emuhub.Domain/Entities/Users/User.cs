using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Emuhub.Domain.Entities.Users;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
    public bool IsActive { get; set; }
    public bool IsBanned { get; set; }

    [AllowedValues(["Common", "Admin", "Moderator"])]
    public string Role { get; set; } = "Common";

    // Sensitive Info
    [JsonIgnore]
    public string Email { get; set; } = "";
    [JsonIgnore]
    public string PasswordHash { get; set; } = "";
}
