namespace AuthService.Application.Models
{
    public sealed record GitHubToken
    {
        public string AccessToken { get; set; }
        public string Scope { get; set; }
        public string TokenType { get; set; }
    }
}