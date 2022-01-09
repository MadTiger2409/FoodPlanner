using FoodPlanner.Application.MediatR.Meal.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Meal
{
    public record UpdateMeal
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value.Trim().ToLowerInvariant();
        }

        public UpdateMealCommand GetUpdateMealCommand(int id) => new(id, Name);
    }
}