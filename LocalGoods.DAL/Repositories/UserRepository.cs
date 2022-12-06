using LocalGoods.DAL.Data;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LocalGoodsDbContext _context;

        public UserRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(User item)
        {
            _context.Users.Remove(item);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Update(User item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<List<Farm>> GetFarms(int id)
        {

            List<Farm> farms = await _context.Farms.ToListAsync();
            return farms.FindAll(x => x.UserId == id);
        }
    }
}
