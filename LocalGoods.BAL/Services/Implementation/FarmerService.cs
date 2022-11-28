using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.DTOs.FarmerDTO;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Operations;
using System.Reflection.Metadata.Ecma335;

namespace LocalGoods.BAL.Services.Implementation
{
    public class FarmerService : IFarmerService
    {
        private IFarmerRepository _farmerRepository;

        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<CreateFarmerDTO> Create(CreateFarmerDTO farmerDTO)
        {
            var farmer = new Farmer()
            {
                FirstName = farmerDTO.FirstName,
                LastName = farmerDTO.LastName,
                Email = farmerDTO.Email,
                Phone = farmerDTO.Phone,
            };
            await _farmerRepository.Create(farmer);
            return farmerDTO;

        }

        public async Task<bool> Delete(FarmerDTO farmerDTO)
        {
            var farmer = await _farmerRepository.GetById(farmerDTO.Id);
            return await _farmerRepository.Delete(farmer);

        }

        public async Task<FarmerDTO> Get(int id)
        {
            var farmer = await _farmerRepository.GetById(id);
            FarmerDTO farmerDTO = new()
            {
                Id = farmer.Id,
                FirstName = farmer.FirstName,
                LastName = farmer.LastName,
                Email = farmer.Email,
                Phone = farmer.Phone
            };
            return farmerDTO;

        }

        public async Task<List<FarmerDTO>> GetAll()
        {
            //List<FarmerDTO> farmerDTOs = new List<FarmerDTO>();
            IEnumerable<Farmer> farmers = await _farmerRepository.GetAll();
            var farmersList = farmers.Select(f => new FarmerDTO
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
                Email = f.Email,
                Phone = f.Phone
            }).ToList();
            return farmersList;
            //foreach (var farmer in farmers)
            //{
            //    FarmerDTO farmerDTO = new()
            //    {
            //        Id = farmer.Id,
            //        FirstName = farmer.FirstName,
            //        LastName = farmer.LastName,
            //        Email = farmer.Email,
            //        Phone = farmer.Phone
            //    };
            //    farmerDTOs.Add(farmerDTO);
            //}
            //return farmerDTOs;

        }

        public async Task<FarmerDTO> Update(FarmerDTO farmerDTO)
        {
            var farmer = await _farmerRepository.GetById(farmerDTO.Id);
            farmer.FirstName = farmerDTO.FirstName;
            farmer.LastName = farmerDTO.LastName;
            farmer.Email = farmerDTO.Email;
            farmer.Phone = farmerDTO.Phone;
            
            await _farmerRepository.Update(farmer);

            return farmerDTO;

        }
    }
}
