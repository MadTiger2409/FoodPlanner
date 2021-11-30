using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Commands
{
    public record CreateIngredientsCommand(int MealId, IList<Domain.Entities.Ingredient> Ingredients) : IRequest<List<Domain.Entities.Ingredient>>;
}