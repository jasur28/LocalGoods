using LocalGoods.DAL.Data;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LocalGoodsDbContext _context;

        public CategoryRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<int> Delete(int id)
        {
            Category? category = await GetById(id);
            if (category != null)
            {
                try
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();
                    return 1;
                }
                catch (Exception)
                {
                    return 2;
                }
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> Update(Category category)
        {
            try
            {
                Category? category1 = await GetById(category.Id);
                if(category1 != null)
                {
                    try
                    {
                        //_context.Entry(category1).State = EntityState.Modified;
                        _context.Categories.Update(category1);
                        await _context.SaveChangesAsync();
                        return 1;
                    }
                    catch(Exception)
                    {
                        return 2;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception)
            {
                return 2;
            }
        }
        public async Task<(IEnumerable<Product>,int)> GetCategoryProducts(int id)
        {
            try
            {
                Category? category = await GetById(id);
                if (category != null)
                {
                    IEnumerable<Product> products=_context.Products.ToList().Where(x => x.CategoryId == category.Id);
                    return (products, 1);
                }
                return (new List<Product>(), 0);
            }
            catch(Exception)
            {
                return (new List<Product>(), 0);
            }
        }
        public async Task<bool> CategoryExistsAsync(Category category)
        {
            IEnumerable<Category> categories = await GetAll();
            categories=categories.Where(x => x.Name == category.Name);
            return categories.Any();
        }
    }
}
