using AuthService.Application.Models;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.ExchangeCodeToToken
{
    public sealed record ExchangeCodeToTokenQuery : IRequest<GitHubToken>
    {
        public ExchangeCodeToTokenQuery(string code)
        {
            Code = code;
        }
        public string Code { get; private set; }
    }
}