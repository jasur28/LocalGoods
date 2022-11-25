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

        public async Task<FarmDTO> Create(FarmDTO farm)
        {
            var createFarm = new Farm()
            {
                Name = farm.name,
                Address = farm.address,
            };
            await _farmRepository.Create(createFarm);
            return farm;
        }
        public async Task<FarmDTO> Get(int id)
        {
            var getFarm=await _farmRepository.GetById(id);
            FarmDTO farmDTO = new()
            { 
                id=getFarm.Id,
                name=getFarm.Name,
                address=getFarm.Address
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
                    id = farm.Id,
                    name = farm.Name,
                    address = farm.Address
                };
                farmDTOs.Add(farmDTO);
            }
            return farmDTOs;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteFarm = await Get(id);
            return await _farmRepository.Delete(deleteFarm.id);
        }

        public async Task<FarmDTO> Update(FarmDTO farmDTO)
        {
            var updateFarm = new Farm()
            {
                Id = farmDTO.id,
                Name = farmDTO.name,
                Address = farmDTO.address
            };
            await _farmRepository.Update(updateFarm);
            
            return farmDTO;
        }
    }
}
