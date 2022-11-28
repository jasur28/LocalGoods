using LocalGoods.DAL.Models;

namespace LocalGoods.DAL.Interfaces
{
    public interface IFarmerRepository
    {
        public Task<Farmer> Create(Farmer item);
        public Task<bool> Delete(int id);
        public Task<Farmer> Update(Farmer item);
        public Task<IEnumerable<Farmer>> GetAll();
        public Task<Farmer> GetById(int id);
    }
}
