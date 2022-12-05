using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Interfaces
{
    public interface IQuantityTypeRepository
    {
        public Task<QuantityType> Create(QuantityType QuantityType);
        public Task<bool> Delete(int id);
        public Task<bool> Update(QuantityType QuantityType);
        public Task<IEnumerable<QuantityType>> GetAll();
        public Task<QuantityType?> GetById(int id);
    }
}
