using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthService.Persistence
{
    public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var sentinelDbConnectionString = "host=localhost;port=5433;database=TestDb;username=test-user;password=test-user;";
            var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>()
                 .UseNpgsql(sentinelDbConnectionString);

            return new AuthDbContext(optionsBuilder.Options);
        }
    }
}
