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

        public async Task<(Product,bool)> Create(Product product)
        {
                try
                {
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                    return (product, true);
                }
                catch (Exception)
                {
                    return (product, false);
                }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> Delete(int id)
        {
            Product? product = await GetById(id);
            if(product != null)
            {
                try
                {
                    _context.Products.Remove(product);
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

        public async Task<int> Update(Product item)
        {
            try
            {
                Product? product = await GetById(item.Id);
                if (product != null)
                {
                    try
                    {
                        _context.Products.Update(product);
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
            catch (Exception)
            {
                return 2;
            }
        }
    }
}
