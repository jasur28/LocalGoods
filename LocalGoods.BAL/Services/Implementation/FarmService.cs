using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Operations;

namespace LocalGoods.BAL.Services.Implementation
{
    public class FarmService : IFarmService
    {
        private IFarmRepository _farmRepository;

        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public async Task<Farm> AddFarm(Farm farm)
        {
            return await _farmRepository.Create(farm);
        }

        public Task<Farm> DeleteFarm(Farm farm)
        {
            throw new NotImplementedException();
        }

        public Task<Farm> GetFarm(Farm farm)
        {
            throw new NotImplementedException();
        }

        public Task<Farm> UpdateFarm(Farm farm)
        {
            throw new NotImplementedException();
        }
    }
}
