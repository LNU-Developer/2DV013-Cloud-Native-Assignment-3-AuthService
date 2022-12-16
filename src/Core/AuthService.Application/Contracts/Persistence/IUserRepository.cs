using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthService.Application.Models;
using GetAllUserDto = AuthService.Application.Features.Users.Queries.GetAllUsers.Dtos.UserDto;
using GetByIdUserDto = AuthService.Application.Features.Users.Queries.GetUserById.Dtos.UserDto;

namespace AuthService.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<List<GetAllUserDto>> GetAllUsers();
        Task<GetByIdUserDto> GetUserById(Guid id);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task CreateUser(ApplicationUser user);
    }
}
