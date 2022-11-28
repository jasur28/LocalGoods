using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> Create(Product product);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Product product);
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product?> GetById(int id);
    }
}
