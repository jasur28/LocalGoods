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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository=productRepository;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            Product product = new()
            {
                Name = productDTO.Name,
                ImageUrl = productDTO.ImageUrl,
                QuantityType = productDTO.QuantityType,
            };
            product=await productRepository.Create(product);
            productDTO = new()
            {
                Name = product.Name,
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                QuantityType=product.QuantityType,
            };
            return productDTO;
        }
        public async Task<ProductDTO?> Get(int id)
        {
            Product? product = await productRepository.GetById(id);
            if(product!=null)
            {
                ProductDTO productDTO = new()
                {
                    Id = product.Id,
                    Name=product.Name,
                    ImageUrl=product.ImageUrl,
                    QuantityType=product.QuantityType
                };
                return productDTO;
            }
            return null;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            List<ProductDTO> productDTOs = new();
            IEnumerable<Product> products = await productRepository.GetAll();
            foreach (Product product in products)
            {
                ProductDTO productDTO = new()
                {
                   Id=product.Id,
                   Name=product.Name,
                   ImageUrl = product.ImageUrl,
                   QuantityType = product.QuantityType
                };
                productDTOs.Add(productDTO);
            }
            return productDTOs;
        }

        public async Task<bool> Delete(int id)
        {
            return await productRepository.Delete(id);
        }

        public async Task<ProductDTO?> Update(ProductDTO productDTO)
        {
            Product product = new()
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                ImageUrl=productDTO.ImageUrl,
                QuantityType=productDTO.QuantityType
            };
            bool i=await productRepository.Update(product);
            if(i == true)
            {
                return new ProductDTO()
                {
                    Id=product.Id,
                    Name=product.Name,
                    ImageUrl = product.ImageUrl,
                    QuantityType = product.QuantityType 
                };
            }
            return null;
        }

    }
}
