using LocalGoods.DAL.Data;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly LocalGoodsDbContext _context;

        public FarmerRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<Farmer> Create(Farmer item)
        {
            await _context.Farmers.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(Farmer item)
        {
            _context.Farmers.Remove(item);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Farmer>> GetAll()
        {
            return await _context.Farmers.ToListAsync();
        }

        public async Task<Farmer?> GetById(int id)
        {
            return await _context.Farmers.SingleOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Farmer> Update(Farmer item)
        {
            _context.Farmers.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<List<Farm>> GetFarms(int id)
        {
            Farmer? farmer = await GetById(id);
            if(farmer==null || farmer.Farms is null)
            {
                return new List<Farm>();
            }
            return farmer.Farms.ToList();
        }
    }
}
