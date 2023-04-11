using MediatR;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Commands
{
	public record DeletePlannedMealCommand(int Id) : IRequest;
}
