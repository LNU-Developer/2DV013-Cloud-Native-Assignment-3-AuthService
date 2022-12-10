using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Infrastructure;
using AuthService.Application.Models;

namespace AuthService.Infrastructure.GitHub
{
    public class GitHubService : IGitHubService
    {
        public HttpClient Client { get; }
        private readonly OAuthOptions _options;

        public GitHubService(HttpClient client, OAuthOptions options)
        {
            client.BaseAddress = new Uri("https://github.com/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client = client;
            _options = options;
        }

        public async Task<HttpResponseMessage> ExchangeCodeToToken(string code)
        {
            string body = $"client_id={_options.ClientId}&client_secret={_options.ClientSecret}&code={code}&redirect_uri={_options.RedirectUri}";
            return await Client.PostAsync($"login/oauth/access_token?{body}", null);
        }

        public async Task<HttpResponseMessage> GetUserEmails(string bearerToken)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user/emails");
            var productValue = new ProductInfoHeaderValue("AuthService", "1.0");
            requestMessage.Headers.UserAgent.Add(productValue);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            requestMessage.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
            requestMessage.Headers.Add("Accept", "application/vnd.github+json");
            return await Client.SendAsync(requestMessage);
        }

        public async Task<HttpResponseMessage> GetUser(string bearerToken)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user");
            var productValue = new ProductInfoHeaderValue("AuthService", "1.0");
            requestMessage.Headers.UserAgent.Add(productValue);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            requestMessage.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
            requestMessage.Headers.Add("Accept", "application/vnd.github+json");
            return await Client.SendAsync(requestMessage);
        }
    }
}