using System;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Persistence;
using AuthService.Application.Features.Users.Queries.GetUserById.Dtos;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.GetUserById
{

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.Id);
        }
    }
}