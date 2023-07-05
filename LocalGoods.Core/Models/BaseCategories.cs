using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.Core.Models
{
    public static class BaseCategories
    {
        public static Category Meat = new()
        {
            Name = "Meat"
        };
        public static Category Milk = new()
        {
            Name = "Milk"
        };
        public static Category Fruits = new()
        {
            Name = "Fruits"
        };
        public static Category Vegetables = new()
        {
            Name = "Vegetables"
        };
    }
}
