
using AuthService.Application.Contracts.Infrastructure;
using AuthService.Infrastructure.GitHub;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IGitHubService, GitHubService>();
            return services;
        }
    }
}
