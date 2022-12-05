using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Data;
using LocalGoods.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Operations
{
    public class FarmRepository : IFarmRepository
    {
        private readonly LocalGoodsDbContext _context;

        public FarmRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<Farm> Create(Farm item)
        {
            await _context.Farms.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<Farm>> GetAll()
        {
            return await _context.Farms.ToListAsync();
        }

        public async Task<Farm?> GetById(int id)
        {
            return await _context.Farms.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            Farm? farm = await GetById(id);
            if (farm != null)
            {
                try
                {
                    _context.Farms.Remove(farm);
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

        public async Task<bool> Update(Farm farm)
        {
            try
            {
                _context.Entry(farm).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetProducts(int id)
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products.FindAll(x => x.FarmId == id);
        }
    }
}
