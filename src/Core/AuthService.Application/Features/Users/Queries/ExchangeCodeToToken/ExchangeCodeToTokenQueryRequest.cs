using MediatR;

namespace AuthService.Application.Features.Users.Queries.ExchangeCodeToToken
{
    public sealed record ExchangeCodeToTokenQueryRequest
    {
        public string Code { get; set; }
    }
}