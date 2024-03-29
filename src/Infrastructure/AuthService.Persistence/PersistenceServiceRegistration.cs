using System;
using AuthService.Application.Contracts.Persistence;
using AuthService.Application.Models;
using AuthService.Persistence.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var host = Environment.GetEnvironmentVariable("AUTHDB_HOST") is not null ? Environment.GetEnvironmentVariable("AUTHDB_HOST") : "localhost";
            var database = Environment.GetEnvironmentVariable("AUTHDB_DATABASE") is not null ? Environment.GetEnvironmentVariable("AUTHDB_DATABASE") : "AuthDb";
            var user = Environment.GetEnvironmentVariable("AUTHDB_USER") is not null ? Environment.GetEnvironmentVariable("AUTHDB_USER") : "test-user";
            var password = Environment.GetEnvironmentVariable("AUTHDB_PASSWORD") is not null ? Environment.GetEnvironmentVariable("AUTHDB_PASSWORD") : "test-password";

            var dbConnectionString = $"host={host};database={database};username={user};password={password};";

            services.AddDbContext<AuthDbContext>(option =>
            {
                option.UseNpgsql(dbConnectionString);
            });

            var runMigrations = Environment.GetEnvironmentVariable("RUN_MIGRATIONS");
            if (runMigrations is not null)
            {
                Console.WriteLine("Running migrations");
                var optionBuilder = new DbContextOptionsBuilder<AuthDbContext>();
                optionBuilder.UseNpgsql(dbConnectionString);
                using var authDbContext = new AuthDbContext(optionBuilder.Options);
                authDbContext.Database.Migrate();
            }
            services.AddDataProtection()
                .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                })
                .PersistKeysToDbContext<AuthDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>().AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}