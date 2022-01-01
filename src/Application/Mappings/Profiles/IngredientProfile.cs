using AutoMapper;
using FoodPlanner.Application.Mappings.Dtos.Ingredient;
using FoodPlanner.Application.Mappings.Dtos.Meal;

namespace FoodPlanner.Application.Mappings.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Domain.Entities.Meal, ShortMealDto>();
            CreateMap<Domain.Entities.Ingredient, IngredientDto>();
        }
    }
}
