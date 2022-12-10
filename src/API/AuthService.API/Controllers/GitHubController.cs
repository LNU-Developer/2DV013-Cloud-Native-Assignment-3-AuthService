using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using AuthService.Application.Features.Users.Queries.GenerateLoginUri;
using AuthService.Application.Features.Users.Queries.ExchangeCodeToToken;
using AuthService.Application.Features.Users.Queries.GetUserFromGitHub;
using AuthService.Application.Features.Users.Queries.GetUserEmailsFromGitHub;
using AuthService.Application.Features.Users.Commands.CreateAndGetLoggedInUser;
using AuthService.Application.Features.Users.Commands.CreateJwtToken;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GitHubController(IMediator mediator) => _mediator = mediator;

        [HttpGet("loginurl")]
        public async Task<IActionResult> GetLoginUrl()
            => Ok(await _mediator.Send(new GenerateLoginUriQuery()));

        [HttpPost("login")]
        async public Task<IActionResult> RegisterAndGetToken([FromBody] ExchangeCodeToTokenQueryRequest request)
        {
            var gitHubObj = await _mediator.Send(new ExchangeCodeToTokenQuery(request.Code));
            var gitHubUserEmail = await _mediator.Send(new GetUserEmailsFromGitHubQuery(gitHubObj.AccessToken));
            var githubUser = await _mediator.Send(new GetUserFromGitHubQuery(gitHubObj.AccessToken));
            var loggedInUser = await _mediator.Send(new CreateAndGetLoggedInUserCommand(githubUser, gitHubUserEmail));
            var jwtToken = await _mediator.Send(new CreateJwtTokenCommand(loggedInUser));
            return Ok(jwtToken);
        }
    }
}