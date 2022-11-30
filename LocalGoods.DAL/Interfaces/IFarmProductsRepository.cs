using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Interfaces
{
    public interface IFarmProductsRepository
    {
        public Task<FarmProductsMapping?> Create(FarmProductsMapping product);
        public Task<bool> Delete(int id);
        public Task<bool> Update(FarmProductsMapping product);
        public Task<IEnumerable<FarmProductsMapping>> GetAll();
        public Task<FarmProductsMapping?> GetById(int id);
    }
}
