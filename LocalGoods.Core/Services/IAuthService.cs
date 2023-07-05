using LocalGoods.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.Core.Services
{
    public interface IAuthService
    {
        Task Create(AuthToken token);
        Task<bool> Check(string userId);
    }
}
