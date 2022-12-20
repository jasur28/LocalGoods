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

        public async Task<Category> Create(Category newCategory)
        {
            await unitOfWork.Categories.AddAsync(newCategory);
            await unitOfWork.CommitAsync();
            return newCategory;
        }

        public async Task Delete(Category category)
        {
            unitOfWork.Categories.Remove(category);
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

        public async Task Update(Category categoryToBeUpdated, Category category)
        {
            categoryToBeUpdated.Name=category.Name; 
            await unitOfWork.CommitAsync(); 
        }
    }
}
