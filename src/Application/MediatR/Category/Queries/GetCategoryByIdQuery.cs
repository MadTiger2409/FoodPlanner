using MediatR;

namespace FoodPlanner.Application.MediatR.Category.Queries
{
    public record GetCategoryByIdQuery(int Id) : IRequest<bool>;
}