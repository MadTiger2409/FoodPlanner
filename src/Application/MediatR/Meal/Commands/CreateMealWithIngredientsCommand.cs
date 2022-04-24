using FoodPlanner.Application.Mappings.Dtos.Meal;
using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Meal.Commands
{
    public record CreateMealWithIngredientsCommand(string Name, List<Domain.Entities.Ingredient> Ingredients) : IRequest<MealDto>;
}