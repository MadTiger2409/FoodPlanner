using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Commands
{
    public record CreateProductCommand(string Name) : IRequest<Domain.Entities.Product>;
}