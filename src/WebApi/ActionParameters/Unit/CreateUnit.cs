using FoodPlanner.Application.MediatR.Unit.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Unit
{
    public record CreateUnit
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value?.Trim().ToLowerInvariant();
        }

        public CreateUnitCommand GetCreateUnitCommand() => new(Name);
    };
}