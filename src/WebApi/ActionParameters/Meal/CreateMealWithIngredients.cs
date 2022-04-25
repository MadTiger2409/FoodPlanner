using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using System.Collections.Generic;
using System.Linq;

namespace FoodPlanner.WebApi.ActionParameters.Meal
{
    public record CreateMealWithIngredients
    {
        public string Name { get; set; }
        public List<CreateIngredient> Ingredients { get; set; }

        public CreateMealWithIngredientsCommand GetCreateMealWithIngredientsCommand()
            => new(Name, Ingredients.Select(x => x.GetIngredient()).ToList());
    }
}