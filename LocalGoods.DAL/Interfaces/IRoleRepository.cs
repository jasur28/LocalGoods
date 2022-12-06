using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> Create(Role Role);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Role Role);
        public Task<IEnumerable<Role>> GetAll();
        public Task<Role?> GetById(int id);
    }
}
