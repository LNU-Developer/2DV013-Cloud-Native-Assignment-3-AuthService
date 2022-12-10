using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Features.Users.Commands.CreateAndGetLoggedInUser
{

    public class CreateAndGetLoggedInUserCommandHandler : IRequestHandler<CreateAndGetLoggedInUserCommand, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public CreateAndGetLoggedInUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityUser> Handle(CreateAndGetLoggedInUserCommand request, CancellationToken cancellationToken)
        {
            var email = request.GitHubEmails.FirstOrDefault(x => x.Primary == true) ?? request.GitHubEmails.FirstOrDefault();
            var existingUser = await _userManager.FindByEmailAsync(email.Email);
            if (existingUser is not null) return existingUser;

            var newUser = new IdentityUser
            {
                Email = email.Email,
                UserName = request.GitHubUser.Login,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(newUser);
            return newUser;
        }
    }
}