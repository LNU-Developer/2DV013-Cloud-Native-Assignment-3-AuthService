using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using System;
using AuthService.Application.Features.Users.Queries.GetUserById;
using AuthService.Application.Features.Users.Queries.GetAllUsers;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpGet("/api/Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpGet("/api/User/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid userId)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery(userId)));
        }
    }
}