using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Interfaces
{
    public interface IFarmRepository
    {
        public Task<Farm> Create(Farm item);
        public bool Remove(int id);
        public Farm Update(Farm item);
        public List<Farm> GetAll();
        public Farm GetById(int id);
    }
}
