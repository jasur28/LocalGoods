using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Interfaces;
using LocalGoods.BAL.DTOs;
using LocalGoods.DAL.Repositories;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.BAL.Services.Implementation
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;
        private readonly UserManager<User> userManager;

        public FarmService(IFarmRepository farmRepository, UserManager<User> userManager)
        {
            _farmRepository = farmRepository;
            this.userManager=userManager;
        }
        public async Task<(FarmDTO,int)> Create(FarmDTO farmDTO)
        {
            Farm? farm = new()
            {
                Name = farmDTO.Name,
                Description = farmDTO.Description,
                Address = farmDTO.Address,
                UserId= farmDTO.UserId,
                Email = farmDTO.Email,
                Image=farmDTO.Image,
                City = farmDTO.City,
                Longitude = farmDTO.Longitude,
                Latitude = farmDTO.Latitude,
                Country = farmDTO.Country,
                Telephone = farmDTO.Telephone,
                Instagram = farmDTO.Instagram,
                FaceBook=farmDTO.FaceBook
            };
            (farm, bool b) = await _farmRepository.Create(farm);
            if (b == true)
            {
                farmDTO.Id = farm.Id;
                return (farmDTO, 1);
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
                Description = farm.Description,
                Address = farm.Address,
                UserId=farm.UserId,
                City=farm.City,
                Image=farm.Image,
                Country = farm.Country, 
                Latitude=farm.Latitude,
                Longitude=farm.Longitude,
                Email=farm.Email,   
                CreatedOn=farm.CreatedOn,   
                FaceBook = farm.FaceBook,
               // Rating=farm.Rating,
                Instagram=farm.Instagram,
                Telephone=farm.Telephone
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
                    Description = farm.Description,
                    Address = farm.Address,
                    UserId=farm.UserId,
                    City = farm.City,
                    Image = farm.Image,
                    Country = farm.Country,
                    Latitude = farm.Latitude,
                    Longitude = farm.Longitude,
                    Email = farm.Email,
                    CreatedOn = farm.CreatedOn,
                    FaceBook = farm.FaceBook,
                    Rating = farm.Rating,
                    Instagram = farm.Instagram,
                    Telephone = farm.Telephone
                };

                (farmDTO.Products,int i)= await GetProducts(farmDTO.Id);
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
            var farm = await _farmRepository.GetById(farmDTO.Id);
            if(farm is null)
            {
                return (farmDTO, 0);
            }
            farm.Name = farmDTO.Name;
            farm.Description = farmDTO.Description;
            farm.Address = farmDTO.Address;
            farm.City = farmDTO.City;
            farm.Country = farmDTO.Country;
            farm.Email = farmDTO.Email;
            farm.Telephone = farmDTO.Telephone;
            farm.FaceBook = farmDTO.FaceBook;
            farm.Instagram = farmDTO.Instagram;
            farm.Latitude = farmDTO.Latitude;
            farm.Longitude = farmDTO.Longitude;
            //Farm farm = new()
            //{
            //    Id = farmDTO.Id,
            //    Name = farmDTO.Name,
            //    Description=farmDTO.Description,
            //    Address=farmDTO.Address,
            //    City = farmDTO.City,
            //    Country = farmDTO.Country,
            //    Email=farmDTO.Email,
            //    Telephone = farmDTO.Telephone,
            //    FaceBook = farmDTO.FaceBook,
            //    Instagram = farmDTO.Instagram,
            //    Latitude=farmDTO.Latitude,
            //    Longitude=farmDTO.Longitude
            //};
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
                    Description = product.Description,  
                    Image = product.Image,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    //Surplus = product.Surplus,
                    //QuantityTypeId = product.QuantityTypeId,
                });
            }
            return (productdtos,1);
        }
    }
}
