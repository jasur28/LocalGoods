using LocalGoods.BAL.Interfaces;
using LocalGoods.DAL.Data;
using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Operations
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
            if(item is null)
                throw new ArgumentNullException(nameof(item), "item is empty or null ");
            Farm newFarm = new Farm()
            {
                FarmName = item.FarmName,
                FarmAddress = item.FarmAddress
            };

            await _context.Farms.AddAsync(newFarm);
            await _context.SaveChangesAsync();

            return newFarm;
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
