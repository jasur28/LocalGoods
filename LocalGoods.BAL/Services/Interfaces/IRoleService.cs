using LocalGoods.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDTO> Create(RoleDTO Role);
        Task<RoleDTO?> Get(int id);
        Task<RoleDTO?> Update(RoleDTO Role);
        Task<bool> Delete(int id);
        Task<List<RoleDTO>> GetAll();
    }
}
