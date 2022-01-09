using FoodPlanner.Application.MediatR.Unit.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Unit
{
    public record UpdateUnit
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value.Trim().ToLowerInvariant();
        }

        public UpdateUnitCommand GetUpdateUnitCommand(int id) => new(id, Name);
    }
}