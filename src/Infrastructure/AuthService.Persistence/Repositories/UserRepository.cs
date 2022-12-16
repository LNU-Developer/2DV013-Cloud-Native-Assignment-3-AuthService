using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Persistence;
using AuthService.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GetAllUserDto = AuthService.Application.Features.Users.Queries.GetAllUsers.Dtos.UserDto;
using GetByIdUserDto = AuthService.Application.Features.Users.Queries.GetUserById.Dtos.UserDto;

namespace AuthService.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<GetAllUserDto>> GetAllUsers()
        {
            return await _userManager.Users
                .Select(user => new GetAllUserDto(user.Id, user.Email, user.UserName, user.GitHubProfileUrl))
                .ToListAsync();
        }
        public async Task<GetByIdUserDto> GetUserById(Guid id)
        {
            return await _userManager.Users
                .Where(x => x.Id == id)
                .Select(user => new GetByIdUserDto(user.Id, user.Email, user.UserName, user.GitHubProfileUrl))
                .FirstOrDefaultAsync();
        }

        public async Task CreateUser(ApplicationUser user)
        {
            await _userManager.CreateAsync(user);
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}