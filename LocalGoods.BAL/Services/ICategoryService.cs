using LocalGoods.Core.Models;
using LocalGoods.BAL.DTOs;

namespace LocalGoods.BAL.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetById(int id);
        Task Create(CategoryDto categoryDto);
        Task Update(Category category);
        Task Delete(Category category);
    }
}
