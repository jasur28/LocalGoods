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

        public async Task<(Farm,bool)> Create(Farm item)
        {
            
                try
                {
                    await _context.Farms.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return (item, true);
                }
                catch (Exception)
                {
                    return (item, false);
                }
           
        }

        public async Task<IEnumerable<Farm>> GetAll()
        {
            return await _context.Farms.ToListAsync();
        }

        public async Task<Farm?> GetById(int id)
        {
            return await _context.Farms.FindAsync(id);
        }

        public async Task<int> Delete(int id)
        {
            Farm? farm = await GetById(id);
            if (farm != null)
            {
                try
                {
                    _context.Farms.Remove(farm);
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
        //Under development
        public async Task<int> Update(Farm farm)
        {
            try
            {
                Farm? farm1= await GetById(farm.Id);
                if (farm1 != null)
                {
                    try
                    {
                        var entry = _context.Entry(farm);
                        entry.State = EntityState.Modified;
                       // entry.Property("UserId").IsModified = false;
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
            catch (Exception)
            {
                return 2;
            }
        }

        public async Task<List<Product>> GetProducts(int id)
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products.FindAll(x => x.FarmId == id);
        }
    }
}
