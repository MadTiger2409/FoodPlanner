using FoodPlanner.Application.MediatR.Category.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Category
{
    public record CreateCategory
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value.Trim().ToLowerInvariant();
        }

        public CreateCategoryCommand GetCreateCategoryCommand() => new(Name);
    }
}