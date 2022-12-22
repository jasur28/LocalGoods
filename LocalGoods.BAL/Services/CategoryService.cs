using LocalGoods.BAL.DTOs;
using LocalGoods.Core;
using LocalGoods.Core.Models;
using LocalGoods.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Create(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            };
            await unitOfWork.Categories.CreateAsync(category);
            await unitOfWork.CommitAsync();
        }

        public async Task Delete(Category category)
        {
            unitOfWork.Categories.DeleteAsync(category);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task Update(Category category)
        {
            var temp = await unitOfWork.Categories.GetByIdAsync(category.Id);
            temp.Name=category.Name;
            await unitOfWork.CommitAsync(); 
        }
    }
}
