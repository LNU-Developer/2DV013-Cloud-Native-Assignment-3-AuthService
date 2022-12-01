using System;
using System.Threading.Tasks;

namespace AuthService.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
        int Complete();
    }
}