using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Emuhub.Domain.Entities.Users;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryDate { get; set; }
    
    public string? PasswordRetrievalToken { get; set; }
    public DateTime? PasswordRetrievalTokenExpiryDate { get; set; }

    [AllowedValues(["Common", "Admin", "Moderator"])]
    public string Role { get; set; } = "Common";

    // Sensitive Info
    [JsonIgnore]
    public string Email { get; set; } = "";
    [JsonIgnore]
    public string PasswordHash { get; set; } = "";
}
