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

        public async Task<bool> Delete(int id)
        {
            Farmer removeFarmer = await GetById(id);

            _context.Farmers.Remove(removeFarmer);
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

        public async Task<Farmer> GetById(int id)
        {
            return await _context.Farmers.FindAsync(id);
        }

        public async Task<Farmer> Update(Farmer item)
        {
            _context.Farmers.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
