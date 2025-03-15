using System.Text.Json.Serialization;

namespace Emuhub.Domain.Entities.Users;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }

    // Sensitive Info
    [JsonIgnore]
    public string Email { get; set; } = "";
    [JsonIgnore]
    public string PasswordHash { get; set; } = "";
}
