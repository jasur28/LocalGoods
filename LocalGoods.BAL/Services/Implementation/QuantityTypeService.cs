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
    public class QuantityTypeService : IQuantityTypeService
    {
        private readonly IQuantityTypeRepository QuantityTypeRepository;

        public QuantityTypeService(IQuantityTypeRepository QuantityTypeRepository)
        {
            this.QuantityTypeRepository = QuantityTypeRepository;
        }

        public async Task<QuantityTypeDTO> Create(QuantityTypeDTO QuantityTypeDTO)
        {
            QuantityType QuantityType = new()
            {
                Name = QuantityTypeDTO.Name,
            };
            QuantityType = await QuantityTypeRepository.Create(QuantityType);
            QuantityTypeDTO = new()
            {
                Name = QuantityType.Name,
                Id = QuantityType.Id
            };
            return QuantityTypeDTO;
        }
        public async Task<QuantityTypeDTO?> Get(int id)
        {
            QuantityType? QuantityType = await QuantityTypeRepository.GetById(id);
            if (QuantityType != null)
            {
                QuantityTypeDTO QuantityTypeDTO = new()
                {
                    Id = QuantityType.Id,
                    Name = QuantityType.Name
                };
                return QuantityTypeDTO;
            }
            return null;
        }

        public async Task<List<QuantityTypeDTO>> GetAll()
        {
            List<QuantityTypeDTO> QuantityTypeDTOs = new();
            IEnumerable<QuantityType> QuantityTypes = await QuantityTypeRepository.GetAll();
            foreach (QuantityType QuantityType in QuantityTypes)
            {
                QuantityTypeDTO QuantityTypeDTO = new()
                {
                    Id = QuantityType.Id,
                    Name = QuantityType.Name
                };
                QuantityTypeDTOs.Add(QuantityTypeDTO);
            }
            return QuantityTypeDTOs;
        }

        public async Task<bool> Delete(int id)
        {
            return await QuantityTypeRepository.Delete(id);
        }

        public async Task<QuantityTypeDTO?> Update(QuantityTypeDTO QuantityTypeDTO)
        {
            QuantityType QuantityType = new()
            {
                Id = QuantityTypeDTO.Id,
                Name = QuantityTypeDTO.Name
            };
            bool i = await QuantityTypeRepository.Update(QuantityType);
            if (i == true)
            {
                return new QuantityTypeDTO()
                {
                    Id = QuantityType.Id,
                    Name = QuantityType.Name
                };
            }
            return null;
        }
    }
}
