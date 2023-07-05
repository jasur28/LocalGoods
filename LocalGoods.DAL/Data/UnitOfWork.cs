using LocalGoods.Core;
using LocalGoods.Core.Models;
using LocalGoods.Core.Repositories;
using LocalGoods.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace LocalGoods.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LocalGoodsDbContext localGoodsDbContext;
        private ICategoryRepository categoryRepository;
        private IDbContextTransaction transaction;
        public UnitOfWork(LocalGoodsDbContext localGoodsDbContext, ICategoryRepository categoryRepository)
        {
            this.localGoodsDbContext = localGoodsDbContext;
            this.categoryRepository = categoryRepository;
        }
        public ICategoryRepository Categories => categoryRepository ??= new CategoryRepository(localGoodsDbContext);

        public async Task CommitAsync()
        {
            await localGoodsDbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            localGoodsDbContext.Dispose();
        }
        public async Task CreateToken(AuthToken t)
        {
            await localGoodsDbContext.Tokens.AddAsync(t);
            await CommitAsync();
        }

        public async Task BeginTransaction()
        {
            transaction = await localGoodsDbContext.Database.BeginTransactionAsync();
        }

        public async Task RollBackTransaction()
        {
            await transaction.RollbackAsync();
        }

        public async Task CommitTransaction()
        {
            await transaction.CommitAsync();
        }
    }
}
