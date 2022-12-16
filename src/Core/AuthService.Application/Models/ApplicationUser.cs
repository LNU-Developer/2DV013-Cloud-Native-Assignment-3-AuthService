using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string GitHubProfileUrl { get; set; }
    }
}