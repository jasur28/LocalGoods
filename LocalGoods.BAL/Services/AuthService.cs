using LocalGoods.Core;
using LocalGoods.Core.Models;
using LocalGoods.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        public AuthService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Create(AuthToken token)
        {
            await unitOfWork.CreateToken(token);
        }
        public async Task<bool> Check(string userId)
        {
           
            return false;
        }
    }
}
