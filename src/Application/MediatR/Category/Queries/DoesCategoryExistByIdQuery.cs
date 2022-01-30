using MediatR;

namespace FoodPlanner.Application.MediatR.Category.Queries
{
    public record DoesCategoryExistByIdQuery(int Id) : IRequest<bool>;
}