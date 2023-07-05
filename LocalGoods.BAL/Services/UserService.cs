using LocalGoods.Core;
using LocalGoods.Core.Models;
using LocalGoods.Core.Services;
using LocalGoods.DAL.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;
        public UserService(UserManager<User> userManager, IUnitOfWork unitOfWork) 
        {
            this.userManager = userManager; 
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(User user, string password)
        {
            await unitOfWork.BeginTransaction();          
            var result=await userManager.CreateAsync(user, password);
            if(IsOperationSuccessful(result))
            {
                var rolesToAdd = new List<string> { "USER"};
                if(user.IsFarmer)
                {
                    rolesToAdd.Add("FARMER");
                }
                result = await userManager.AddToRolesAsync(user, rolesToAdd);   
                if(IsOperationSuccessful(result))
                {
                    await unitOfWork.CommitTransaction();
                    return true;
                }
            }
            await unitOfWork.RollBackTransaction();
            return false;
        }

        public bool IsOperationSuccessful(IdentityResult result)
        {
            return result.Succeeded;
        }

        public async Task FailedOperation()
        {
            await unitOfWork.RollBackTransaction();
        }

        public Task Create()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailAlreadyExisting(string email)
        {
            var result=await userManager.FindByEmailAsync(email);
            return result != null;
        }
    }
}
