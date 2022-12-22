using FluentValidation;

namespace AuthService.Application.Features.Users.Queries.ExchangeCodeToToken
{
    public class ExchangeCodeToTokenQueryValidator : AbstractValidator<ExchangeCodeToTokenQuery>
    {
        public ExchangeCodeToTokenQueryValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("The {PropertyName} cannot be empty.");
        }
    }
}