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

        public async Task<Farm> GetById(int id)
        {
            return await _context.Farms.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            Farm removeFarm = await GetById(id);

            _context.Farms.Remove(removeFarm);
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

        public async Task<Farm> Update(Farm item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
