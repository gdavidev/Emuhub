using Emuhub.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Emuhub.Application.Services.Auth
{
    public class JwtTokenHandlerService(IJwtTokenSecrets authSecrets)
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
                ],
                expires: DateTime.UtcNow.AddDays(authSecrets.ExpirationInDays),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
