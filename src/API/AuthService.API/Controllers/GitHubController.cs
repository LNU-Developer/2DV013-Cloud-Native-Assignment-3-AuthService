using System;
using Microsoft.AspNetCore.Mvc;
using KickAssBackend.Models.ResponseObject;
using KickAssBackend.Models;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace KickAssBackend.Controllers
{
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly GitHubApiService api;
        public GitHubController(GitHubApiService api)
        {
            api = api;
        }

        [HttpGet("loginurl")]
        public Task<IActionResult> GetLoginUrl()
        {
            string message = "https://github.com/login/oauth/authorize?client_id=&redirect_uri=http://localhost:13000/callback&scope=user&state=123";
            return responseObject;
        }

        [HttpGet("exchangecode")]
        async public Task<string> ExchangeCodeToToken(string token)
        {
            string clientId = "";
            string clientSecret = "";
            string redirectUrl = "http://kickasspayouts.n00bs.io:3500/auth/redirectdiscord";
            string response = await _client.FetchAccesToken(token, clientId, clientSecret, redirectUrl);
            Console.WriteLine(response);
            return response;
        }
    }
}