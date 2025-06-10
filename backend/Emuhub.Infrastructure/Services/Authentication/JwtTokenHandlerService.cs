using Emuhub.Domain.Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Emuhub.Infrastructure.Services.Authentication;

public class JwtTokenHandlerService(JwtTokenSecrets authSecrets)
{
    public string CreateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSecrets.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: authSecrets.Issuer,
            audience: authSecrets.Audience,
            claims: [
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            ],
            expires: DateTime.UtcNow.AddDays(authSecrets.ExpirationInDays),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public static string CreateRefreshToken()
    {
        using var rng = RandomNumberGenerator.Create();

        var randomNumber = new byte[32];
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}