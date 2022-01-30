using FoodPlanner.Application.Mappings.Dtos.Category;
using MediatR;

namespace FoodPlanner.Application.MediatR.Category.Commands
{
    public record CreateCategoryCommand(string Name) : IRequest<CategoryDto>;
}