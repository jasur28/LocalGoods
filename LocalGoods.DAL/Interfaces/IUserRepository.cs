using LocalGoods.DAL.Models;

namespace LocalGoods.DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Create(User item);
        public Task<bool> Delete(User item);
        public Task<User> Update(User item);
        public Task<IEnumerable<User>> GetAll();
        public Task<User?> GetById(int id);
        public Task<List<Farm>> GetFarms(int id);
    }
}
