using System.Threading.Tasks;
using AuthService.Application.Contracts.Persistence;

namespace AuthService.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthDbContext _context;

        public UnitOfWork(AuthDbContext context)
        {
            _context = context;
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}