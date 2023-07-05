using LocalGoods.Core.Models;
using LocalGoods.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        Task CreateToken(AuthToken token);
        Task CommitAsync();
        Task BeginTransaction();    
        Task RollBackTransaction();
        Task CommitTransaction();
    }
}
