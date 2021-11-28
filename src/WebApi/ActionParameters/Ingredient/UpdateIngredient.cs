using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.ActionParameters.Ingredient
{
    public class UpdateIngredient
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }
    }
}