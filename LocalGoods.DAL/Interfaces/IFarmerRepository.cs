using LocalGoods.DAL.Models;

namespace LocalGoods.DAL.Interfaces
{
    public interface IFarmerRepository
    {
        public Task<Farmer> Create(Farmer item);
        public Task<bool> Delete(Farmer item);
        public Task<Farmer> Update(Farmer item);
        public Task<IEnumerable<Farmer>> GetAll();
        public Task<Farmer?> GetById(int id);
        public Task<List<Farm>> GetFarms(int id);
    }
}
