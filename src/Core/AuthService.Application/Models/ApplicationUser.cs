using System;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string GitHubProfileUrl { get; set; }
    }
}