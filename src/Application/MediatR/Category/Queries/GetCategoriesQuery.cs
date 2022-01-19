using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Category.Queries
{
    public record GetCategoriesQuery() : IRequest<List<Domain.Entities.Category>>;
}