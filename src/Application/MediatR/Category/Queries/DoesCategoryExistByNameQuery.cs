using MediatR;

namespace FoodPlanner.Application.MediatR.Category.Queries
{
    public record DoesCategoryExistByNameQuery(string Name) : IRequest<bool>;
}