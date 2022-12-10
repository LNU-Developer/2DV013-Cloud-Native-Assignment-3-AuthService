using System;

namespace AuthService.Application.Models
{
    public class GitHubEmail
    {
        public string Email { get; set; }
        public bool Primary { get; set; }
        public bool Verified { get; set; }
        public string Visibility { get; set; }
    }
}
