using System;
using AuthService.Application.Features.Users.Queries.GetUserById.Dtos;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery : IRequest<UserDto>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}