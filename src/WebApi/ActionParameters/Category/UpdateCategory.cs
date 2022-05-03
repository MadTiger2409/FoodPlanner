using FoodPlanner.Application.MediatR.Category.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Category
{
    public record UpdateCategory
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value?.Trim().ToLowerInvariant();
        }

        public UpdateCategoryCommand GetUpdateCategoryCommand(int id) => new(id, Name);
    }
}