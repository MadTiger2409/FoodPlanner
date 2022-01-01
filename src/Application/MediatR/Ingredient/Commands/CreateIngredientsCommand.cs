using FoodPlanner.Application.Mappings.Dtos.Ingredient;
using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Ingredient.Commands
{
    public record CreateIngredientsCommand(int MealId, List<Domain.Entities.Ingredient> Ingredients) : IRequest<List<IngredientDto>>;
}