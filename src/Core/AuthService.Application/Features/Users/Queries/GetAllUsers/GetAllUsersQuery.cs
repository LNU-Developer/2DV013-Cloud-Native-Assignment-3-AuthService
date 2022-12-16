using System.Collections.Generic;
using AuthService.Application.Features.Users.Queries.GetAllUsers.Dtos;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.GetAllUsers
{
    public sealed record GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}