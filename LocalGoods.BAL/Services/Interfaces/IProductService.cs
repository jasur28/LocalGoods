using LocalGoods.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> Create(ProductDTO product);
        Task<ProductDTO?> Get(int id);
        Task<ProductDTO?> Update(ProductDTO product);
        Task<bool> Delete(int id);
        Task<List<ProductDTO>> GetAll();
    }
}
