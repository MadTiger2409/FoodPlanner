using MediatR;

namespace FoodPlanner.Application.MediatR.Category.Commands
{
    public record CreateCategoryCommand(string Name) : IRequest<Domain.Entities.Category>;
}