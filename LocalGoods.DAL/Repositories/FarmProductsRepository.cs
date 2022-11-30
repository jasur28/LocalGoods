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
    public class FarmProductsRepository : IFarmProductsRepository
    {
        private readonly LocalGoodsDbContext _context;

        public FarmProductsRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<FarmProductsMapping?> Create(FarmProductsMapping product)
        {
            IEnumerable<FarmProductsMapping> farmProductsMappings = await GetAll();
            bool flag=false;
            foreach (FarmProductsMapping farmProduct in farmProductsMappings)
            {
                if(farmProduct.ProductId.Equals(product.ProductId) && farmProduct.FarmId.Equals(product.FarmId))
                {
                    flag=true;
                }
            }
            if(flag)
            {
                return null;
            }
            await _context.FarmProductsMappings.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<FarmProductsMapping>> GetAll()
        {
            return await _context.FarmProductsMappings.ToListAsync();
        }

        public async Task<FarmProductsMapping?> GetById(int id)
        {
            return await _context.FarmProductsMappings.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            FarmProductsMapping? product = await GetById(id);
            if (product != null)
            {
                try
                {
                    _context.FarmProductsMappings.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(FarmProductsMapping product)
        {
            try
            {
                //_context.Entry(product).State = EntityState.Modified;
                _context.Entry(product).Property("Price").IsModified=true;
                _context.Entry(product).Property("Description").IsModified = true;
                _context.Entry(product).Property("Surplus").IsModified = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
