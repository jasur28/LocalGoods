using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Helpers
{
    public static class BaseCategories
    {
        public static Category Meat = new()
        {
            Name="Meat",
            Description="High proteins",
        };
        public static Category Milk = new()
        {
            Name = "Milk",
            Description = "High proteins liquid",
        };
        public static Category Fruits = new()
        {
            Name = "Fruits",
            Description = "Healthy",
        };
        public static Category Vegetables = new()
        {
            Name = "Vegetables",            Description = "Very Healthy",
        };

    }
}
