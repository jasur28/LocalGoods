using LocalGoods.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetById(int id);
        Task<Category> Create(Category newCategory);
        Task Update(Category categoryToBeUpdated, Category category);
        Task Delete(Category category);
    }
}
