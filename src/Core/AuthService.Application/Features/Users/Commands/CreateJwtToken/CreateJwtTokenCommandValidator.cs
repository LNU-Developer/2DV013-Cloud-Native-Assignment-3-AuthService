using FluentValidation;

namespace AuthService.Application.Features.Users.Commands.CreateJwtToken
{
    public class CreateJwtTokenCommandValidator : AbstractValidator<CreateJwtTokenCommand>
    {
        public CreateJwtTokenCommandValidator()
        {
            RuleFor(x => x.User).NotEmpty().WithMessage("The {PropertyName} cannot be empty.");
        }
    }
}