using LocalGoods.Core.Models;
using LocalGoods.Core.Repositories;
using LocalGoods.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
