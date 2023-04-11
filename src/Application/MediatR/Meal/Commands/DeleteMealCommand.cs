using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Commands
{
	public record DeleteMealCommand(int Id) : IRequest;
}
