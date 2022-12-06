using LocalGoods.DAL.Models;

namespace LocalGoods.DAL.Interfaces
{
    public interface IFarmRepository
    {
        public Task<Farm> Create(Farm item);
        public Task<int> Delete(int id);
        public Task<bool> Update(Farm item);
        public Task<IEnumerable<Farm>> GetAll();
        public Task<Farm?> GetById(int id);
        public Task<List<Product>> GetProducts(int id);
    }
}
