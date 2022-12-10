using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Contracts.Infrastructure;
using AuthService.Application.Models;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AuthService.Application.Features.Users.Queries.GetUserEmailsFromGitHub
{

    public class GetUserFromGitHubQueryHandler : IRequestHandler<GetUserEmailsFromGitHubQuery, List<GitHubEmail>>
    {
        private readonly IGitHubService _api;
        public GetUserFromGitHubQueryHandler(IGitHubService api)
        {
            _api = api;

        }

        public async Task<List<GitHubEmail>> Handle(GetUserEmailsFromGitHubQuery request, CancellationToken cancellationToken)
        {

            var response = await _api.GetUserEmails(request.BearerToken);
            if (!response.IsSuccessStatusCode) return null;
            var stringData = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<List<GitHubEmail>>(stringData, new JsonSerializerSettings
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