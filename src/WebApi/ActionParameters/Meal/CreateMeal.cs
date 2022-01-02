using FoodPlanner.Application.MediatR.Meal.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Meal
{
    public record CreateMeal
    {
        public string Name { get; set; }

        public CreateMealCommand GetCreateMealCommand() => new(Name);
    }
}