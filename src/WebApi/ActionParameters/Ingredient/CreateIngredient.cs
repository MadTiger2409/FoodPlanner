using FoodPlanner.Application.MediatR.Ingredient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.ActionParameters.Ingredient
{
    public class CreateIngredient
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }

        public static implicit operator Domain.Entities.Ingredient(CreateIngredient createIngredient)
        {
            return new Domain.Entities.Ingredient
            {
                ProductId = createIngredient.ProductId,
                UnitId = createIngredient.UnitId,
                Amount = createIngredient.Amount
            };
        }

        public static implicit operator CreateIngredient(Domain.Entities.Ingredient ingredient)
        {
            return new CreateIngredient
            {
                ProductId = ingredient.ProductId,
                UnitId = ingredient.UnitId,
                Amount = ingredient.Amount
            };
        }
    }
}