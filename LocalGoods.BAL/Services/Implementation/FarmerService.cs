using LocalGoods.BAL.DTOs.FarmerDTO;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;

namespace LocalGoods.BAL.Services.Implementation
{
    public class FarmerService : IFarmerService
    {
        private IFarmerRepository _farmerRepository;

        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<CreateFarmerDTO> Create(CreateFarmerDTO farmer)
        {
            var createFarmer = new Farmer()
            {
                FirstName = farmer.firstName,
                LastName = farmer.lastName,
                Email = farmer.email,
                Phone = farmer.phone,
            };
            await _farmerRepository.Create(createFarmer);
            return farmer;

        }

        public async Task<bool> Delete(int id)
        {
            var deleteFarmer = await Get(id);
            return await _farmerRepository.Delete(deleteFarmer.id);

        }

        public async Task<FarmerDTO> Get(int id)
        {
            var getFarmer = await _farmerRepository.GetById(id);
            FarmerDTO farmerDTO = new()
            {
                id = getFarmer.Id,
                firstName = getFarmer.FirstName,
                lastName = getFarmer.LastName,
                email = getFarmer.Email,
                phone = getFarmer.Phone
            };
            return farmerDTO;

        }

        public async Task<List<FarmerDTO>> GetAll()
        {
            List<FarmerDTO> farmerDTOs = new List<FarmerDTO>();
            IEnumerable<Farmer> farmers = await _farmerRepository.GetAll();
            foreach (var farmer in farmers)
            {
                FarmerDTO farmerDTO = new()
                {
                    id = farmer.Id,
                    firstName = farmer.FirstName,
                    lastName = farmer.LastName,
                    email = farmer.Email,
                    phone = farmer.Phone
                };
                farmerDTOs.Add(farmerDTO);
            }
            return farmerDTOs;

        }

        public async Task<FarmerDTO> Update(FarmerDTO farmer)
        {
            var updateFarmer = new Farmer()
            {
                Id = farmer.id,
                FirstName = farmer.firstName,
                LastName = farmer.lastName,
                Email = farmer.email,
                Phone = farmer.phone
            };
            await _farmerRepository.Update(updateFarmer);

            return farmer;

        }
    }
}
