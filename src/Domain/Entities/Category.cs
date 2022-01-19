using FoodPlanner.Domain.Common;
using System.Collections.Generic;

namespace FoodPlanner.Domain.Entities
{
    public class Category : NamedEntity
    {
        public List<Product> Products { get; set; }
    }
}