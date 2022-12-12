using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Operations;
using LocalGoods.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IFarmRepository farmRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductService(IProductRepository productRepository, IFarmRepository farmRepository,IWebHostEnvironment webHostEnvironment)
        {
            this.productRepository = productRepository;
            this.farmRepository = farmRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<(ProductDTO, int)> Create(ProductDTO productDTO,string name)
        {
            Product? product = new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Image = name,
                Description = productDTO.Description,
                CategoryId = productDTO.CategoryId,
                FarmId = productDTO.FarmId

            };
            Farm? farm = await farmRepository.GetById(productDTO.FarmId);
            if (farm == null)
            {
                return (productDTO, 0);
            }
            (product, bool b) = await productRepository.Create(product);
            if (b == true)
            {
                productDTO.Id = product.Id;
                return (productDTO, 1);
            }
            return (productDTO, 2);
        }
        public async Task<ProductDTO?> Get(int id)
        {
            Product? product = await productRepository.GetById(id);
            if (product != null)
            {
                ViewProductDTO productDTO = new()
                {
                    Id = product.Id,
                    Name=product.Name,
                    CategoryId=product.CategoryId,
                    ImagePath = product.Image,
                    FarmId=product.FarmId,
                    Description=product.Description,
                    Price=product.Price
                };
                return productDTO;
            }
            return null;
        }

        public async Task<List<ViewProductDTO>> GetAll()
        {
            List<ViewProductDTO> productDTOs = new();
            IEnumerable<Product> products = await productRepository.GetAll();
            foreach (Product product in products)
            {
                ViewProductDTO productDTO = new()
                {
                   Id=product.Id,
                   Name=product.Name,
                   CategoryId=product.CategoryId,
                   ImagePath = product.Image,
                   FarmId=product.FarmId,
                   Description=product.Description,
                   Price=product.Price
                };
                productDTOs.Add(productDTO);
            }
            return productDTOs;
        }

        public async Task<int> Delete(int id)
        {
            return await productRepository.Delete(id);
        }

        public async Task<(ProductDTO, int)> Update(ProductDTO productDTO)
        {

            var product = await productRepository.GetById(productDTO.Id);
            if(product is null)
            {
                return (productDTO, 0);
            }
            product.Name = productDTO.Name;
            product.CategoryId = productDTO.CategoryId;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            int i = await productRepository.Update(product);
            return (productDTO, i);
        }

    }
}
