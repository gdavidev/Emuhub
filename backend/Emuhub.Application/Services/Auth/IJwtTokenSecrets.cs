namespace Emuhub.Application.Services.Auth
{
    public interface IJwtTokenSecrets
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationInDays { get; set; }
    }
}
