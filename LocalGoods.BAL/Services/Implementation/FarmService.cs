using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Interfaces;
using LocalGoods.BAL.DTOs;
using LocalGoods.DAL.Repositories;

namespace LocalGoods.BAL.Services.Implementation
{
    public class FarmService : IFarmService
    {
        private IFarmRepository _farmRepository;
        private IUserRepository _userRepository;

        public FarmService(IFarmRepository farmRepository, IUserRepository userRepository)
        {
            _farmRepository = farmRepository;
            _userRepository = userRepository;
        }
        public async Task<(FarmDTO,int)> Create(FarmDTO farmDTO)
        {
            Farm? farm = new Farm()
            {
                Name = farmDTO.Name,
                Address = farmDTO.Address,
                UserId= farmDTO.UserId,
                Email = farmDTO.Email,
                City = farmDTO.City,
                Longitude = farmDTO.Longitude,
                Latitude = farmDTO.Latitude,
                Country = farmDTO.Country,
                Telephone = farmDTO.Telephone,
                Instagram = farmDTO.Instagram,
                FaceBook=farmDTO.FaceBook
            };
            User? user = await _userRepository.GetById(farmDTO.UserId);
            if(user == null)
            {
                return (farmDTO,0);
            }
            (farm,bool b) = await _farmRepository.Create(farm);
            if(b==true)
            {
                farmDTO.Id = farm.Id;
                return (farmDTO,1);
            }
            return (farmDTO, 2);
        }
        public async Task<FarmDTO?> Get(int id)
        {
            Farm? farm=await _farmRepository.GetById(id);
            if (farm == null)
                return null;
            FarmDTO farmDTO = new()
            {
                Id = farm.Id,
                Name = farm.Name,
                Address = farm.Address,
                UserId=farm.UserId
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
                    Address = farm.Address,
                    UserId=farm.UserId
                };
                farmDTOs.Add(farmDTO);
            }
            return farmDTOs;
        }

        public async Task<int> Delete(int id)
        {
            return await _farmRepository.Delete(id);
        }

        public async Task<(FarmDTO,int)> Update(FarmDTO farmDTO)
        {
            Farm farm = new()
            {
                Id = farmDTO.Id,
                Name = farmDTO.Name,
                Address=farmDTO.Address,
                City = farmDTO.City,
                Country = farmDTO.Country,
                Email=farmDTO.Email,
                Telephone = farmDTO.Telephone,
                FaceBook = farmDTO.FaceBook,
                Instagram = farmDTO.Instagram,
                Latitude=farmDTO.Latitude,
                Longitude=farmDTO.Longitude
            };
            int i = await _farmRepository.Update(farm);
            farmDTO.UserId = farm.UserId;
            return (farmDTO, i);
        }

        public async Task<(List<ProductDTO>,int)> GetProducts(int id)
        {
            List<ProductDTO> productdtos = new();
            Farm? farm = await _farmRepository.GetById(id);
            if(farm == null)
            {
                return (productdtos, 0);
            }
            List<Product> products1 = await _farmRepository.GetProducts(id);
            foreach(Product product in products1)
            {
                int? fid = product.FarmId;
                productdtos.Add(new ProductDTO()
                {
                    Id = product.Id,
                    FarmId = product.FarmId,
                    Price = product.Price,
                    Surplus = product.Surplus,
                    Description = product.Description,  
                    Image = product.Image,
                    QuantityTypeId = product.QuantityTypeId,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                });
            }
            return (productdtos,1);
        }
    }
}
