using LocalGoods.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Create(CategoryDTO category);
        Task<CategoryDTO?> Get(int id);
        Task<CategoryDTO?> Update(CategoryDTO category);
        Task<bool> Delete(int id);
        Task<List<CategoryDTO>> GetAll();
        Task<IEnumerable<ProductDTO>> GetCategoryProducts(int id);
    }
}
