using FoodPlanner.Application.MediatR.Meal.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Meal
{
    public record CreateMeal
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value?.Trim().ToLowerInvariant();
        }

        public CreateMealCommand GetCreateMealCommand() => new(Name);
    }
}