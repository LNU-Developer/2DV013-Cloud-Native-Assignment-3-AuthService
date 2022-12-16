using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Persistence;
using AuthService.Application.Features.Users.Queries.GetAllUsers.Dtos;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.GetAllUsers
{

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsers();
        }
    }
}