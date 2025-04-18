using System.ComponentModel.DataAnnotations;

namespace Emuhub.Communication.Data.Auth
{
    public class RefreshTokenRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public required string RefreshToken { get; set; }
    }
}
