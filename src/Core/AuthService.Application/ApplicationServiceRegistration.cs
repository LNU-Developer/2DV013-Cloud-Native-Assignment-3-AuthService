using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using AuthService.Application.Models;
using System;

namespace AuthService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            var clientId = Environment.GetEnvironmentVariable("GHCLIENTID") is not null ? Environment.GetEnvironmentVariable("GHCLIENTID") : "test123";
            var redirectUri = Environment.GetEnvironmentVariable("REDIRECTURI") is not null ? Environment.GetEnvironmentVariable("REDIRECTURI") : "http://testtestestes.dev/callback";
            var clientSecret = Environment.GetEnvironmentVariable("GHCLIENTSECRET") is not null ? Environment.GetEnvironmentVariable("GHCLIENTSECRET") : "test123";

            services.AddSingleton(new OAuthOptions
            {
                ClientId = clientId,
                RedirectUri = redirectUri,
                ClientSecret = clientSecret
            });
            services.AddSingleton(new JwtSettings
            {
                Issuer = Environment.GetEnvironmentVariable("JWTISSUER") ?? "AuthService",
                Audience = Environment.GetEnvironmentVariable("JWTAUDIENCE") ?? "LitterService",
                DurationInMinutes = int.Parse(Environment.GetEnvironmentVariable("JWTDURATIONINMINUTES")) != 0 ? int.Parse(Environment.GetEnvironmentVariable("JWTDURATIONINMINUTES")) : 60,
                PrivateKey = Environment.GetEnvironmentVariable("JWTPRIVATEKEY") ?? "test"

            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}