﻿using LocalGoods.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.Core.Services
{
    public interface IUserService
    {
        public Task Create();
        public Task<bool> Create(User user, string password);
        public Task<bool> IsEmailAlreadyExisting(string email);
        public Task<User> GetUserByEmail(string email);
        public Task<bool> AreCorrectCredentialsEntered(string email, string password);
        public Task<IList<string>> GetUserRoles(User user);
    }
}