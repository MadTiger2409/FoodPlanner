using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Commands
{
    public class UpdateIngredientCommand : IRequest<Domain.Entities.Ingredient>
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }
    }
}