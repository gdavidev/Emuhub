using Microsoft.Extensions.Configuration;

namespace Emuhub.Infrastructure.Services.Authentication;

public class JwtTokenSecrets
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpirationInDays { get; set; }

    public JwtTokenSecrets(IConfiguration configuration)
    {
        Secret = configuration.GetValue<string>("Token:Secret")!;
        Issuer = configuration.GetValue<string>("Token:Issuer")!;
        Audience = configuration.GetValue<string>("Token:Audience")!;
        ExpirationInDays = configuration.GetValue<int>("Token:ExpirationInDays");
    }
}