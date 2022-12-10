namespace AuthService.Application.Models
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
        public string PrivateKey { get; set; }
    }
}