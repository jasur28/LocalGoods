using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalGoods.Core.Models;

namespace LocalGoods.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithProductsAsync();
        Task<Category> GetWithProductsByIdAsync(int id);
    }
}
