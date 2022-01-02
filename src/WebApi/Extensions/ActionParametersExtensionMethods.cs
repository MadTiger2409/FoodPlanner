using FoodPlanner.Application.MediatR.Ingredient.Commands;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using System.Collections.Generic;
using System.Linq;

namespace FoodPlanner.WebApi.Extensions
{
    public static class ActionParametersExtensionMethods
    {
        public static CreateIngredientsCommand GetCreateIngredientsCommand(this List<CreateIngredient> createIngredients, int id)
            => new(id, createIngredients.Select(a => a.GetIngredient()).ToList());
    }
}