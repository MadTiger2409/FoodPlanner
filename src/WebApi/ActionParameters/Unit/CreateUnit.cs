using FoodPlanner.Application.MediatR.Unit.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Unit
{
    public record CreateUnit
    {
        public string Name { get; set; }

        public CreateUnitCommand GetCreateUnitCommand() => new(Name);
    };
}