using LocalGoods.BAL.DTOs;
using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IFarmProductsService
    {
        Task<FarmProductsMappingDTO> Create(FarmProductsMappingDTO product);
        Task<FarmProductsMappingDTO?> Get(int id);
        Task<FarmProductsMappingDTO?> Update(FarmProductsMappingDTO product);
        Task<bool> Delete(int id);
        Task<List<FarmProductsMappingDTO>> GetAll();
    }
}
