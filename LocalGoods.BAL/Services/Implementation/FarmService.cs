using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Interfaces;
using LocalGoods.BAL.DTOs;

namespace LocalGoods.BAL.Services.Implementation
{
    public class FarmService : IFarmService
    {
        private IFarmRepository _farmRepository;

        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public async Task<CreateFarmDTO> Create(CreateFarmDTO farmDTO)
        {
            var farm = new Farm()
            {
                Name = farmDTO.Name,
                Address = farmDTO.Address,
            };
            await _farmRepository.Create(farm);
            return farmDTO;
        }
        public async Task<FarmDTO> Get(int id)
        {
            var farm=await _farmRepository.GetById(id);
            FarmDTO farmDTO = new()
            { 
                Id=farm.Id,
                Name=farm.Name,
                Address=farm.Address
            };
            return farmDTO; 
        }

        public async Task<List<FarmDTO>> GetAll()
        {
            List<FarmDTO> farmDTOs = new List<FarmDTO>();
            IEnumerable<Farm> farms=await _farmRepository.GetAll();
            foreach (var farm in farms)
            {
                FarmDTO farmDTO = new()
                {
                    Id = farm.Id,
                    Name = farm.Name,
                    Address = farm.Address
                };
                farmDTOs.Add(farmDTO);
            }
            return farmDTOs;
        }

        public async Task<bool> Delete(int id)
        {
            FarmDTO farmDTO = await Get(id);
            Farm farm = new Farm()
            {
                Id = farmDTO.Id,
                Name = farmDTO.Name,
                Address = farmDTO.Address
            };
            return await _farmRepository.Delete(farm);
        }

        public async Task<FarmDTO> Update(FarmDTO farmDTO)
        {
            var farm = new Farm()
            {
                Id = farmDTO.Id,
                Name = farmDTO.Name,
                Address = farmDTO.Address
            };
            await _farmRepository.Update(farm);
            
            return farmDTO;
        }
    }
}
