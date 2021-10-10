using FoodPlanner.Domain.Common;
using System.Collections.Generic;

namespace FoodPlanner.Domain.Entities
{
    public class Unit : NamedEntity
    {
        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}