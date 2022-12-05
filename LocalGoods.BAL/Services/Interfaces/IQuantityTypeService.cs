using LocalGoods.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IQuantityTypeService
    {
        Task<QuantityTypeDTO> Create(QuantityTypeDTO QuantityType);
        Task<QuantityTypeDTO?> Get(int id);
        Task<QuantityTypeDTO?> Update(QuantityTypeDTO QuantityType);
        Task<bool> Delete(int id);
        Task<List<QuantityTypeDTO>> GetAll();
    }
}
