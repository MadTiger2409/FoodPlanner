using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Commands
{
    public record UpdateProductCommand(int Id, string Name) : IRequest<Domain.Entities.Product>;
}