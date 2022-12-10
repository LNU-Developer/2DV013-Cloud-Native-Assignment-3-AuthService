using System.Net.Http;
using System.Threading.Tasks;


namespace AuthService.Application.Contracts.Infrastructure
{
    public interface IGitHubService
    {
        Task<HttpResponseMessage> ExchangeCodeToToken(string code);
        Task<HttpResponseMessage> GetUser(string bearerToken);
        Task<HttpResponseMessage> GetUserEmails(string bearerToken);
    }
}