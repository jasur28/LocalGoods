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
    public class QuantityTypeRepository : IQuantityTypeRepository
    {
        private readonly LocalGoodsDbContext _context;

        public QuantityTypeRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<QuantityType> Create(QuantityType QuantityType)
        {
            await _context.QuantityTypes.AddAsync(QuantityType);
            await _context.SaveChangesAsync();
            return QuantityType;
        }

        public async Task<IEnumerable<QuantityType>> GetAll()
        {
            return await _context.QuantityTypes.ToListAsync();
        }

        public async Task<QuantityType?> GetById(int id)
        {
            return await _context.QuantityTypes.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            QuantityType? QuantityType = await GetById(id);
            if (QuantityType != null)
            {
                try
                {
                    _context.QuantityTypes.Remove(QuantityType);
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

        public async Task<bool> Update(QuantityType QuantityType)
        {
            try
            {
                _context.Entry(QuantityType).State = EntityState.Modified;
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
