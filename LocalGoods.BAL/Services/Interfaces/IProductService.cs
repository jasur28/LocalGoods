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
        Task<(ProductDTO,int)> Create(ProductDTO product);
        Task<ProductDTO?> Get(int id);
        Task<(ProductDTO,int)> Update(ProductDTO product);
        Task<int> Delete(int id);
        Task<List<ProductDTO>> GetAll();
    }
}
