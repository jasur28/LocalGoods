using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using LocalGoods.Core.Models;
using LocalGoods.Core.Repositories;
using LocalGoods.Core.Services;

namespace LocalGoods.DAL.Data
{
    public class AppDbInitializer
    {
        public static async Task SeedRolesToDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Farmer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Farmer));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
        }
        public static async Task SeedCategoriesToDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var categoryService = serviceScope.ServiceProvider.GetRequiredService<ICategoryService>();

                if (await categoryService.CategoryExistsAsync(BaseCategories.Milk) == false)
                {
                    await categoryService.Create(BaseCategories.Milk);
                }
                if (await categoryService.CategoryExistsAsync(BaseCategories.Vegetables) == false)
                {
                    await categoryService.Create(BaseCategories.Vegetables);
                }
                if (await categoryService.CategoryExistsAsync(BaseCategories.Fruits) == false)
                {
                    await categoryService.Create(BaseCategories.Fruits);
                }
                if (await categoryService.CategoryExistsAsync(BaseCategories.Meat) == false)
                {
                    await categoryService.Create(BaseCategories.Meat);
                }
            }
        }
    }
}
