using System.Collections.Generic;
using AuthService.Application.Models;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.GetUserFromGitHub
{
    public sealed record GetUserFromGitHubQuery : IRequest<GitHubUser>
    {
        public GetUserFromGitHubQuery(string bearerToken)
        {
            BearerToken = bearerToken;
        }
        public string BearerToken { get; private set; }
    }
}