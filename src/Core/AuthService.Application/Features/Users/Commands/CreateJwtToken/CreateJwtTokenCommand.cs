using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Features.Users.Commands.CreateJwtToken
{
    public sealed record CreateJwtTokenCommand : IRequest<CreateJwtTokenCommandResponse>
    {
        public CreateJwtTokenCommand(IdentityUser user)
        {
            User = user;
        }
        public IdentityUser User { get; private set; }
    }
}