using FoodPlanner.Application.Mappings.Dtos.Category;
using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Category.Queries
{
    public record GetCategoriesQuery(string Name = default) : IRequest<List<CategoryDto>>;
}