using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<User> userManager;

        public CategoryService(ICategoryRepository categoryRepository, UserManager<User> userManager)
        {
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDTO)
        {
            Category category = new()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
            };
            category = await categoryRepository.Create(category);
            categoryDTO = new()
            {
                Name = category.Name,
                Id = category.Id,
                Description = category.Description,
            };
            return categoryDTO;
        }
        public async Task<CategoryDTO?> Get(int id)
        {
            Category? category = await categoryRepository.GetById(id);
            if (category != null)
            {
                CategoryDTO categoryDTO = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
                return categoryDTO;
            }
            return null;
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            List<CategoryDTO> categoryDTOs = new();
            IEnumerable<Category> categorys = await categoryRepository.GetAll();
            foreach (Category category in categorys)
            {
                CategoryDTO categoryDTO = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description=category.Description
                };
                categoryDTOs.Add(categoryDTO);
            }
            return categoryDTOs;
        }

        public async Task<int> Delete(int id)
        {
            return await categoryRepository.Delete(id);
        }

        public async Task<(CategoryDTO,int)> Update(CategoryDTO categoryDTO)
        {
            Category category = new()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
            };
            int i = await categoryRepository.Update(category);
            return (categoryDTO,i);
        }
        public async Task<(IEnumerable<ProductDTO>,int)> GetCategoryProducts(int id)
        {
            (IEnumerable<Product> products,int a) = await categoryRepository.GetCategoryProducts(id);
            List<ProductDTO> productsDTOs = new();
            foreach(Product product in products)
            {
                productsDTOs.Add(new ProductDTO()
                {
                    Id= product.Id,
                    Name= product.Name,
                    Image= product.Image,
                    QuantityTypeId= product.QuantityTypeId,
                });
            }
            return (productsDTOs,a);
        }
    }
}
