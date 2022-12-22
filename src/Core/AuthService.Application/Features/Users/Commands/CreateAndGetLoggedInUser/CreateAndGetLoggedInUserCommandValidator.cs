using FluentValidation;

namespace AuthService.Application.Features.Users.Commands.CreateAndGetLoggedInUser
{
    public class CreateAndGetLoggedInUserCommandValidator : AbstractValidator<CreateAndGetLoggedInUserCommand>
    {
        public CreateAndGetLoggedInUserCommandValidator()
        {
            RuleFor(x => x.GitHubUser).NotEmpty().WithMessage("The {PropertyName} cannot be empty.");
            RuleFor(x => x.GitHubEmails).NotEmpty().WithMessage("The {PropertyName} cannot be empty.");
        }
    }
}