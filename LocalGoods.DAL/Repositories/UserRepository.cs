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
            return await _context.Users.SingleOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<User> Update(User item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<List<Farm>> GetFarms(int id)
        {
            User? user = await GetById(id);
            if(user==null)
            {
                return new List<Farm>();
            }
            return null;
        }
    }
}
