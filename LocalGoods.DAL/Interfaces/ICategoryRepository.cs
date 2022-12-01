using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category category);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Category category);
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category?> GetById(int id);
        public Task<IEnumerable<Product>> GetCategoryProducts(int id);
    }
}
