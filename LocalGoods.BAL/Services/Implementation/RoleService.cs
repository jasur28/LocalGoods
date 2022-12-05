using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository RoleRepository;

        public RoleService(IRoleRepository RoleRepository)
        {
            this.RoleRepository = RoleRepository;
        }

        public async Task<RoleDTO> Create(RoleDTO RoleDTO)
        {
            Role Role = new()
            {
                Name = RoleDTO.Name,
            };
            Role = await RoleRepository.Create(Role);
            RoleDTO = new()
            {
                Name = Role.Name,
                Id = Role.Id
            };
            return RoleDTO;
        }
        public async Task<RoleDTO?> Get(int id)
        {
            Role? Role = await RoleRepository.GetById(id);
            if (Role != null)
            {
                RoleDTO RoleDTO = new()
                {
                    Id = Role.Id,
                    Name = Role.Name
                };
                return RoleDTO;
            }
            return null;
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            List<RoleDTO> RoleDTOs = new();
            IEnumerable<Role> Roles = await RoleRepository.GetAll();
            foreach (Role Role in Roles)
            {
                RoleDTO RoleDTO = new()
                {
                    Id = Role.Id,
                    Name = Role.Name
                };
                RoleDTOs.Add(RoleDTO);
            }
            return RoleDTOs;
        }

        public async Task<bool> Delete(int id)
        {
            return await RoleRepository.Delete(id);
        }

        public async Task<RoleDTO?> Update(RoleDTO RoleDTO)
        {
            Role Role = new()
            {
                Id = RoleDTO.Id,
                Name = RoleDTO.Name
            };
            bool i = await RoleRepository.Update(Role);
            if (i == true)
            {
                return new RoleDTO()
                {
                    Id = Role.Id,
                    Name = Role.Name
                };
            }
            return null;
        }
    }
}
