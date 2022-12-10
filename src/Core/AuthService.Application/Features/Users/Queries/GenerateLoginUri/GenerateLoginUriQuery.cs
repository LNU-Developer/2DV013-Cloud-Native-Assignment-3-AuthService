using MediatR;

namespace AuthService.Application.Features.Users.Queries.GenerateLoginUri
{
    public sealed record GenerateLoginUriQuery : IRequest<string>
    {
    }
}