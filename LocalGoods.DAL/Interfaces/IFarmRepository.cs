using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Interfaces
{
    public interface IFarmRepository
    {
        public Task<Farm> Create(Farm item);
        public Task<bool> Delete(int id);
        public Task<Farm> Update(Farm item);
        public Task<IEnumerable<Farm>> GetAll();
        public Task<Farm> GetById(int id);
    }
}
