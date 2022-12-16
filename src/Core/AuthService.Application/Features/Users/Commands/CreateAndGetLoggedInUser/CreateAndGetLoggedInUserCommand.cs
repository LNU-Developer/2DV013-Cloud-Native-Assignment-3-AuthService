using System.Collections.Generic;
using AuthService.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Features.Users.Commands.CreateAndGetLoggedInUser
{
    public sealed record CreateAndGetLoggedInUserCommand : IRequest<ApplicationUser>
    {
        public CreateAndGetLoggedInUserCommand(GitHubUser gitHubUser, List<GitHubEmail> gitHubEmails)
        {
            GitHubUser = gitHubUser;
            GitHubEmails = gitHubEmails;
        }
        public List<GitHubEmail> GitHubEmails { get; private set; }
        public GitHubUser GitHubUser { get; private set; }
    }
}