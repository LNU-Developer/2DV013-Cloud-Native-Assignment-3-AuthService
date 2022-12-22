using FluentValidation;

namespace AuthService.Application.Features.Users.Queries.GetUserEmailsFromGitHub
{
    public class GetUserEmailsFromGitHubQueryValidator : AbstractValidator<GetUserEmailsFromGitHubQuery>
    {
        public GetUserEmailsFromGitHubQueryValidator()
        {
            RuleFor(x => x.BearerToken).NotEmpty().WithMessage("The {PropertyName} cannot be empty.");
        }
    }
}