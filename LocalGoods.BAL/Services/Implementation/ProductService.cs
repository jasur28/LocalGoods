using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using LocalGoods.DAL.Operations;
using LocalGoods.DAL.Repositories;
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

        public ProductService(IProductRepository productRepository, IFarmRepository farmRepository)
        {
            this.productRepository = productRepository;
            this.farmRepository = farmRepository;
        }

        public async Task<(ProductDTO, int)> Create(ProductDTO productDTO)
        {
            Product? product = new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,

                //Surplus = productDTO.Surplus,
                Description = productDTO.Description,
                Image = productDTO.Image,
                CategoryId = productDTO.CategoryId,
                //QuantityTypeId = productDTO.QuantityTypeId,
                FarmId = productDTO.FarmId,

                //Description = productDTO.Description,   
                //Image = productDTO.Image,
                //CategoryId=productDTO.CategoryId,
                //FarmId=productDTO.FarmId,

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
                ProductDTO productDTO = new()
                {
                    Id = product.Id,

                    //Name = product.Name,
                    //CategoryId = product.CategoryId,
                    //Image = product.Image,
                    //QuantityTypeId = product.QuantityTypeId,
                    //Surplus = product.Surplus,
                    //FarmId = product.FarmId,
                    //Description = product.Description,
                    //Price = product.Price

                    Name=product.Name,
                    CategoryId=product.CategoryId,
                    Image=product.Image,
                    FarmId=product.FarmId,
                    Description=product.Description,
                    Price=product.Price
                    //QuantityTypeId = product.QuantityTypeId,
                    //Surplus = product.Surplus,

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

                    //Id = product.Id,
                    //Name = product.Name,
                    //CategoryId = product.CategoryId,
                    //Image = product.Image,
                    //QuantityTypeId = product.QuantityTypeId,
                    //FarmId = product.FarmId,
                    //Description = product.Description,
                    //Price = product.Price,
                    //Surplus = product.Surplus

                   Id=product.Id,
                   Name=product.Name,
                   CategoryId=product.CategoryId,
                   Image = product.Image,
                   FarmId=product.FarmId,
                   Description=product.Description,
                   Price=product.Price,
                   //Surplus=product.Surplus
                   //QuantityTypeId = product.QuantityTypeId,

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
            product.Name = productDTO.Name;
            product.CategoryId = productDTO.CategoryId;
            product.Image = productDTO.Image;
            //product.QuantityTypeId = productDTO.QuantityTypeId;
            //product.Surplus = productDTO.Surplus;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            //Product product = new()
            //{
            //    Id = productDTO.Id,
            //    Name = productDTO.Name,
            //    CategoryId = productDTO.CategoryId,
            //    Image=productDTO.Image,
            //    QuantityTypeId=productDTO.QuantityTypeId,
            //    Surplus=productDTO.Surplus,
            //    Description=productDTO.Description,
            //    Price=productDTO.Price,
            //};

            //Product product = new()
            //{
            //    Id = productDTO.Id,
            //    Name = productDTO.Name,
            //    CategoryId = productDTO.CategoryId,
            //    Image=productDTO.Image,
            //    Description=productDTO.Description,
            //    Price=productDTO.Price,
                // QuantityTypeId=productDTO.QuantityTypeId,
                //Surplus=productDTO.Surplus,
            //};

            int i = await productRepository.Update(product);
            return (productDTO, i);
        }

    }
}
