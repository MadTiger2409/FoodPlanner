using MediatR;

namespace FoodPlanner.Application.MediatR.Category.Commands
{
    public record UpdateCategoryCommand(int Id, string Name) : IRequest<Domain.Entities.Category>;
}