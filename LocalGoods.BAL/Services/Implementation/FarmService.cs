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
        public async Task<(FarmDTO,int)> Create(CreateFarmDTO farmDTO,string name)
        {
            Farm? farm = new()
            {
                Name = farmDTO.Name,
                Description = farmDTO.Description,
                Address = farmDTO.Address,
                UserId= farmDTO.UserId,
                Email = farmDTO.Email,
                Image=name,
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
                ViewFarmDTO viewFarmDTO = new ViewFarmDTO()
                {
                    Id = farm.Id,
                    Name = farm.Name,
                    Description = farm.Description,
                    Address = farm.Address,
                    UserId = farm.UserId,
                    Email = farm.Email,
                    ImagePath = farm.Image,
                    City = farm.City,
                    Longitude = farm.Longitude,
                    Latitude = farm.Latitude,
                    Country = farm.Country,
                    Telephone = farm.Telephone,
                    Instagram = farm.Instagram,
                    FaceBook = farm.FaceBook
                };
                return (viewFarmDTO, 1);
            }
            return (farmDTO, 2);
        }
        public async Task<ViewFarmDTO?> Get(int id)
        {
            Farm? farm=await _farmRepository.GetById(id);
            if (farm == null)
                return null;
            ViewFarmDTO farmDTO = new()
            {
                Id = farm.Id,
                Name = farm.Name,
                Description = farm.Description,
                Address = farm.Address,
                UserId=farm.UserId,
                City=farm.City,
                ImagePath= farm.Image,
                Country = farm.Country, 
                Latitude=farm.Latitude,
                Longitude=farm.Longitude,
                Email=farm.Email,   
                CreatedOn=farm.CreatedOn,   
                FaceBook = farm.FaceBook,
                Rating=farm.Rating,
                Instagram=farm.Instagram,
                Telephone=farm.Telephone
            };
            (farmDTO.Products,int _) = await GetProducts(id);
            return farmDTO; 
        }

        public async Task<List<ViewFarmDTO>> GetAll()
        {
            List<ViewFarmDTO> farmDTOs = new List<ViewFarmDTO>();
            IEnumerable<Farm> farms=await _farmRepository.GetAll();
            foreach (var farm in farms)
            {
                ViewFarmDTO farmDTO = new()
                {
                    Id = farm.Id,
                    Name = farm.Name,
                    Description = farm.Description,
                    Address = farm.Address,
                    UserId=farm.UserId,
                    City = farm.City,
                    ImagePath = farm.Image,
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

        public async Task<(FarmDTO,int)> Update(FarmDTO farmDTO,string name)
        {
            Farm? farm = await _farmRepository.GetById(farmDTO.Id);
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
            farm.Image = name;
            int i = await _farmRepository.Update(farm);
            farmDTO.UserId = farm.UserId;
            ViewFarmDTO viewFarmDTO = new()
            {
                Id = farm.Id,
                Name = farm.Name,
                Description = farm.Description,
                Address = farm.Address,
                City = farm.City,
                Country = farm.Country,
                CreatedOn = farm.CreatedOn,
                Email = farm.Email,
                FaceBook = farm.FaceBook,
                Instagram = farm.Instagram,
                ImagePath = name,
                Latitude = farm.Latitude,
                Longitude = farm.Longitude,
                Telephone = farm.Telephone,
                Rating = farm.Rating,
                UserId = farm.UserId
            };
            (viewFarmDTO.Products, int k) = await GetProducts(farm.Id);
            return (viewFarmDTO, i);
        }

        public async Task<(List<ViewProductDTO>,int)> GetProducts(int id)
        {
            List<ViewProductDTO> productdtos = new();
            Farm? farm = await _farmRepository.GetById(id);
            if(farm == null)
            {
                return (productdtos, 0);
            }
            List<Product> products1 = await _farmRepository.GetProducts(id);
            foreach(Product product in products1)
            {
                int? fid = product.FarmId;
                productdtos.Add(new ViewProductDTO()
                {
                    Id = product.Id,
                    FarmId = product.FarmId,
                    Price = product.Price,
                    Description = product.Description,  
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    ImagePath=product.Image
                });
            }
            return (productdtos,1);
        }
    }
}
