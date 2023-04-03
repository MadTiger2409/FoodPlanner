using MediatR;

namespace FoodPlanner.Application.MediatR.Category.Commands
{
	public record DeleteCategoryCommand(int Id) : IRequest;
}
