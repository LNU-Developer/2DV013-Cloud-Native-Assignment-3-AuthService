using System;

namespace AuthService.Application.Features.Users.Queries.GetUserById.Dtos
{
    public sealed record UserDto
    {
        public UserDto(Guid id, string email, string login, string avatarUrl)
        {
            Id = id;
            Email = email;
            Login = login;
            AvatarUrl = avatarUrl;
        }
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string AvatarUrl { get; private set; }
    }
}