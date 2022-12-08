using LocalGoods.DAL.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Models;

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
        public static async Task SeedQuantityTypesToDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var quantityTypeManager = serviceScope.ServiceProvider.GetRequiredService<IQuantityTypeRepository>();

                if (!await quantityTypeManager.QuantityTypeExistsAsync(QuantityTypes.Number))
                {

                    await quantityTypeManager.Create(new QuantityType()
                    {
                        Name = QuantityTypes.Number,
                    });
                }

                if (!await quantityTypeManager.QuantityTypeExistsAsync(QuantityTypes.KG))
                {
                    await quantityTypeManager.Create(new QuantityType()
                    {
                        Name= QuantityTypes.KG,
                    });
                }
                   

                if (!await quantityTypeManager.QuantityTypeExistsAsync(UserRoles.Admin))
                {
                    await quantityTypeManager.Create(new QuantityType()
                    {
                        Name=QuantityTypes.Litres,
                    });
                }
                    
            }
        }
        public static async Task SeedCategoriesToDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var categoryManager = serviceScope.ServiceProvider.GetRequiredService<ICategoryRepository>();

                if (!await categoryManager.CategoryExistsAsync(BaseCategories.Milk))
                {
                    await categoryManager.Create(BaseCategories.Milk);
                }
                if (!await categoryManager.CategoryExistsAsync(BaseCategories.Vegetables))
                {
                    await categoryManager.Create(BaseCategories.Vegetables);
                }
                if (!await categoryManager.CategoryExistsAsync(BaseCategories.Fruits))
                {
                    await categoryManager.Create(BaseCategories.Fruits);
                }
                if (!await categoryManager.CategoryExistsAsync(BaseCategories.Meat))
                {
                    await categoryManager.Create(BaseCategories.Meat);
                }
            }
        }
    }
}
