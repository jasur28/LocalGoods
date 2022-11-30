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

        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }
        public async Task<FarmDTO?> Create(CreateFarmDTO farmDTO)
        {
            Farm? farm = new Farm()
            {
                Name = farmDTO.name,
                Address = farmDTO.address,
            };
            farm=await _farmRepository.Create(farm);
            if(farm is null)
            {
                return null;
            }
            return new FarmDTO()
            {
                id=farm.Id,
                name=farm.Name,
                address=farm.Address
            };
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
        public async Task<FarmDTO?> Get(int id)
        {
            Farm? farm=await _farmRepository.GetById(id);
            if (farm == null)
                return null;
            FarmDTO farmDTO = new()
            { 
                id=farm.Id,
                name=farm.Name,
                address=farm.Address
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
            return await _farmRepository.Delete(id);
            FarmDTO farmDTO = await Get(id);
            Farm farm = new Farm()
            {
                Id = farmDTO.Id,
                Name = farmDTO.Name,
                Address = farmDTO.Address
            };
            return await _farmRepository.Delete(farm);
        }

        public async Task<FarmDTO?> Update(FarmDTO farmDTO)
        {
            Farm farm = new()
            {
                Id = farmDTO.id,
                Name = farmDTO.name,
                Address=farmDTO.address
            };
            bool i = await _farmRepository.Update(farm);
            if (i == true)
            {
                return new FarmDTO()
                {
                    id = farm.Id,
                    name = farm.Name,
                    address=farm.Address
                };
            }
            return null;
        }

        public async Task<List<FarmProductsMappingDTO>> GetProducts(int id)
        {
            Farm farm = await _farmRepository.GetById(id);
            List<FarmProductsMappingDTO> productdtos = new();
            List<FarmProductsMapping> products1 = await _farmRepository.GetProducts(id);
            foreach(FarmProductsMapping product in products1)
            {
                int? fid = product.FarmId;
                productdtos.Add(new FarmProductsMappingDTO()
                {
                    ProductId = product.ProductId,
                    FarmId = product.FarmId,
                    FarmProductId = product.FarmProductId,
                    Price = product.Price,
                    Surplus = product.Surplus,
                    Description = product.Description,
                    FarmDTO = new FarmDTO()
                    {
                        id = product.Farm.Id,
                        address = product.Farm.Address,
                        name = product.Farm.Name
                    },
                    ProductDTO = new ProductDTO()
                    {
                        Id = product.Product.Id,
                        Name = product.Product.Name,
                        ImageUrl = product.Product.ImageUrl,
                        QuantityType = product.Product.QuantityType
                    }
                });
            }
            return productdtos;
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
