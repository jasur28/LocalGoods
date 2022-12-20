using LocalGoods.Core.Repositories;
using LocalGoods.DAL.Data;
//using LocalGoods.DAL.Interfaces;
using LocalGoods.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace LocalGoods.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
       public CategoryRepository(LocalGoodsDbContext context) : base(context) { }
        public async Task<IEnumerable<Category>> GetAllWithProductsAsync()
        {
            return await LocalGoodsDbContext.Categories.Include(a => a.Products).ToListAsync();
        }
        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await LocalGoodsDbContext.Categories.Include(a => a.Products).SingleOrDefaultAsync(a => a.Id == id);
        }
        private LocalGoodsDbContext LocalGoodsDbContext
        {
            get { return Context as LocalGoodsDbContext; }
        }
    }
}
