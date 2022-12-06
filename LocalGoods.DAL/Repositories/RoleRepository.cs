using LocalGoods.DAL.Data;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly LocalGoodsDbContext _context;

        public RoleRepository(LocalGoodsDbContext context)
        {
            _context = context;
        }

        public async Task<Role> Create(Role Role)
        {
            await _context.Roles.AddAsync(Role);
            await _context.SaveChangesAsync();
            return Role;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            Role? Role = await GetById(id);
            if (Role != null)
            {
                try
                {
                    _context.Roles.Remove(Role);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Role Role)
        {
            try
            {
                _context.Entry(Role).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
