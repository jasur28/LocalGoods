using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Implementation
{
    public class FarmProductsService : IFarmProductsService
    {
        private readonly IFarmProductsRepository farmProductsRepository;

        public FarmProductsService(IFarmProductsRepository farmProductsRepository)
        {
            this.farmProductsRepository = farmProductsRepository;
        }

        public async Task<FarmProductsMappingDTO?> Create(FarmProductsMappingDTO productDTO)
        {
            FarmProductsMapping farmProductsMapping = new()
            {
                FarmId = productDTO.FarmId,
                Price = productDTO.Price,
                Description = productDTO.Description,
                Surplus = productDTO.Surplus,
                ProductId = productDTO.ProductId,
            };
            try
            {
                FarmProductsMapping? farmProductsMapping1 = await farmProductsRepository.Create(farmProductsMapping);
                if(farmProductsMapping1 == null)
                {
                    return new FarmProductsMappingDTO()
                    {
                        Id = 0,
                        FarmId = productDTO.FarmId,
                        Price = productDTO.Price,
                        Description = productDTO.Description,
                        Surplus = productDTO.Surplus,
                        ProductId = productDTO.ProductId,
                    };
                }
                return new FarmProductsMappingDTO()
                {
                    Id = farmProductsMapping1.Id,
                    FarmId = farmProductsMapping1.FarmId,
                    Price = farmProductsMapping1.Price,
                    Description = farmProductsMapping1.Description,
                    Surplus = farmProductsMapping1.Surplus,
                    ProductId = farmProductsMapping1.ProductId,
                };
               
            }
            catch(Exception)
            {
                return null;
            }
            
        }
        public async Task<FarmProductsMappingDTO?> Get(int id)
        {
            FarmProductsMapping? product = await farmProductsRepository.GetById(id);
            if (product != null)
            {
                return new FarmProductsMappingDTO()
                {
                    Id = product.Id,
                    FarmId = product.FarmId,
                    Price = product.Price,
                    Description = product.Description,
                    Surplus = product.Surplus,
                    ProductId = product.ProductId,
                };
            }
            return null;
        }

        public async Task<List<FarmProductsMappingDTO>> GetAll()
        {
            IEnumerable<FarmProductsMapping> products = await farmProductsRepository.GetAll();
            List<FarmProductsMappingDTO> dTOs= new List<FarmProductsMappingDTO>();
            foreach(FarmProductsMapping mapping in products)
            {
                dTOs.Add(new FarmProductsMappingDTO()
                {
                    Id = mapping.Id,
                    FarmId = mapping.FarmId,
                    Price = mapping.Price,
                    Description = mapping.Description,
                    Surplus = mapping.Surplus,
                    ProductId = mapping.ProductId,
                });
            }
            return dTOs;
        }

        public async Task<bool> Delete(int id)
        {
            return await farmProductsRepository.Delete(id);
        }

        public async Task<FarmProductsMappingDTO?> Update(FarmProductsMappingDTO productDTO)
        { 
            FarmProductsMapping mapping = new()
            {
                Id = productDTO.Id,
                Price = productDTO.Price,
                Description = productDTO.Description,
                Surplus = productDTO.Surplus,
            };
            bool i = await farmProductsRepository.Update(mapping);
            if (i == true)
            {
                return new()
                {
                    Id = productDTO.Id,
                    Price = productDTO.Price,
                    Description = productDTO.Description,
                    Surplus = productDTO.Surplus,
                };
            }
            return null;
        }
    }
}
