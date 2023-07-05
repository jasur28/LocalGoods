﻿using LocalGoods.Core.Models;

namespace LocalGoods.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<bool> CategoryExistsAsync(Category category);
    }
}
