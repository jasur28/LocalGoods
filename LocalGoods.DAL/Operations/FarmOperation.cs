using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Data;
using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Operations
{
    public class FarmOperation : IFarmRepository
    {
        private readonly LocalGoodsDbContext _context;

        public FarmOperation(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<Farm> Create(Farm item)
        {
            await _context.Farms.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public List<Farm> GetAll()
        {
            throw new NotImplementedException();
        }

        public Farm GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Farm Update(Farm item)
        {
            throw new NotImplementedException();
        }
    }
}
