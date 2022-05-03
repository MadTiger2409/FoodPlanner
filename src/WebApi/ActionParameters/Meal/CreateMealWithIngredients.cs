using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using System.Collections.Generic;
using System.Linq;

namespace FoodPlanner.WebApi.ActionParameters.Meal
{
    public record CreateMealWithIngredients
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value?.Trim().ToLowerInvariant();
        }

        public List<CreateIngredient> Ingredients { get; set; }

        public CreateMealWithIngredientsCommand GetCreateMealWithIngredientsCommand()
            => new(Name, Ingredients.Select(x => x.GetIngredient()).ToList());
    }
}