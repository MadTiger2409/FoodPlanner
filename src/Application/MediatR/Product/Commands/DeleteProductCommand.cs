using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Commands
{
	public record DeleteProductCommand(int Id) : IRequest;
}
