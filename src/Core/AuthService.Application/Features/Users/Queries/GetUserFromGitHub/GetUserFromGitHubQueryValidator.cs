using FluentValidation;

namespace AuthService.Application.Features.Users.Queries.GetUserFromGitHub
{
    public class GetUserFromGitHubQueryValidator : AbstractValidator<GetUserFromGitHubQuery>
    {
        public GetUserFromGitHubQueryValidator()
        {
            RuleFor(x => x.BearerToken).NotEmpty().WithMessage("The {PropertyName} cannot be empty.");
        }
    }
}