namespace AuthService.Application.Models
{
    public class OAuthOptions
    {
        public string RedirectUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}