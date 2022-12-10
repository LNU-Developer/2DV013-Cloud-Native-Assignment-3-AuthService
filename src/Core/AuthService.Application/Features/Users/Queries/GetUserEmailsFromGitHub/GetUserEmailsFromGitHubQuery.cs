using System.Collections.Generic;
using AuthService.Application.Models;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.GetUserEmailsFromGitHub
{
    public sealed record GetUserEmailsFromGitHubQuery : IRequest<List<GitHubEmail>>
    {
        public GetUserEmailsFromGitHubQuery(string bearerToken)
        {
            BearerToken = bearerToken;
        }
        public string BearerToken { get; private set; }
    }
}