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
    public class ProductRepository : IProductRepository
    {
        private readonly LocalGoodsDbContext _context;

        public ProductRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            Product? product = await GetById(id);
            if(product != null)
            {
                try
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }                
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
