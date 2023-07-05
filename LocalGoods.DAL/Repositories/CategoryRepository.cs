using LocalGoods.Core.Repositories;
using LocalGoods.DAL.Data;
using LocalGoods.Core.Models;

namespace LocalGoods.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LocalGoodsDbContext context) : base(context) { }
        public async Task<bool> CategoryExistsAsync(Category category)
        {
            IEnumerable<Category> categories = await GetAllAsync();
            categories = categories.Where(x => x.Name == category.Name);
            return categories.Any();
        }
    }
}
