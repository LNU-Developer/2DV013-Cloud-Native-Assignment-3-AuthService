using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Persistence;
using AuthService.Application.Models;
using MediatR;

namespace AuthService.Application.Features.Users.Commands.CreateAndGetLoggedInUser
{

    public class CreateAndGetLoggedInUserCommandHandler : IRequestHandler<CreateAndGetLoggedInUserCommand, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;
        public CreateAndGetLoggedInUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApplicationUser> Handle(CreateAndGetLoggedInUserCommand request, CancellationToken cancellationToken)
        {
            var email = request.GitHubEmails.FirstOrDefault(x => x.Primary == true) ?? request.GitHubEmails.FirstOrDefault();
            var existingUser = await _userRepository.GetUserByEmail(email.Email);
            if (existingUser is not null) return existingUser;

            var newUser = new ApplicationUser
            {
                Email = email.Email,
                UserName = request.GitHubUser.Login,
                EmailConfirmed = true,
                GitHubProfileUrl = request.GitHubUser.AvatarUrl
            };

            await _userRepository.CreateUser(newUser);
            return newUser;
        }
    }
}