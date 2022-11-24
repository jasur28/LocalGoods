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
            FarmDTO farmDTO = new FarmDTO()
            { 
                id=getFarm.Id,
                name=getFarm.Name,
                address=getFarm.Address
            };
            return farmDTO; 
        }

        public Task<List<FarmDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var deleteFarm = await Get(id);
            return await _farmRepository.Delete(deleteFarm.id);
        }

        public Task<FarmDTO> Update(FarmDTO farm)
        {
            throw new NotImplementedException();
        }

        
    }
}
