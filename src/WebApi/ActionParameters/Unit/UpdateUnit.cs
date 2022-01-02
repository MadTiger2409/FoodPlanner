using FoodPlanner.Application.MediatR.Unit.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Unit
{
    public record UpdateUnit
    {
        public string Name { get; set; }

        public UpdateUnitCommand GetUpdateUnitCommand(int id) => new(id, Name);
    }
}