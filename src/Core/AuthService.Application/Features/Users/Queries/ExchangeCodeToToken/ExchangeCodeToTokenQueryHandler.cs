using System;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Infrastructure;
using AuthService.Application.Models;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AuthService.Application.Features.Users.Queries.ExchangeCodeToToken
{

    public class ExchangeCodeToTokenQueryHandler : IRequestHandler<ExchangeCodeToTokenQuery, GitHubToken>
    {
        private readonly IGitHubService _api;
        public ExchangeCodeToTokenQueryHandler(IGitHubService api)
        {
            _api = api;

        }

        public async Task<GitHubToken> Handle(ExchangeCodeToTokenQuery request, CancellationToken cancellationToken)
        {
            var response = await _api.ExchangeCodeToToken(request.Code);
            if (!response.IsSuccessStatusCode) return null;
            var stringData = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonConvert.DeserializeObject<GitHubToken>(stringData, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });
        }
    }
}