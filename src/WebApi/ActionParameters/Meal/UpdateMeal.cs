using FoodPlanner.Application.MediatR.Meal.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Meal
{
    public record UpdateMeal
    {
        public string Name { get; set; }

        public UpdateMealCommand GetUpdateMealCommand(int id) => new(id, Name);
    }
}