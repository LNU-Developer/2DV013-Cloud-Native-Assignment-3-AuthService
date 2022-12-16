using AuthService.Application.Models;
using MediatR;

namespace AuthService.Application.Features.Users.Commands.CreateJwtToken
{
    public sealed record CreateJwtTokenCommand : IRequest<CreateJwtTokenCommandResponse>
    {
        public CreateJwtTokenCommand(ApplicationUser user)
        {
            User = user;
        }
        public ApplicationUser User { get; private set; }
    }
}