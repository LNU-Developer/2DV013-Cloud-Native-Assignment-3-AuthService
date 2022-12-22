using System;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Persistence;
using FluentValidation;

namespace AuthService.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.Id).NotEmpty().WithMessage("The {PropertyName} cannot be empty.");
            RuleFor(x => x.Id).MustAsync(UserMustExist).WithMessage("The value {PropertyValue} was not found for {PropertyName}.");
        }

        private async Task<bool> UserMustExist(Guid e, CancellationToken token)
        {
            return await _userRepository.GetUserById(e) is not null;
        }
    }
}