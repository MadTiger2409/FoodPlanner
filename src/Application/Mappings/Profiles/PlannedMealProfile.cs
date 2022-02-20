using AutoMapper;
using FoodPlanner.Application.Mappings.Dtos.Ingredient;
using FoodPlanner.Application.Mappings.Dtos.Meal;
using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using FoodPlanner.Application.Mappings.Dtos.Product;
using FoodPlanner.Application.Mappings.Dtos.Unit;

namespace FoodPlanner.Application.Mappings.Profiles
{
    public class PlannedMealProfile : Profile
    {
        public PlannedMealProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
            CreateMap<Domain.Entities.Unit, UnitDto>();
            CreateMap<Domain.Entities.Ingredient, IngredientForMealDto>();
            CreateMap<Domain.Entities.Meal, MealDto>();
            CreateMap<Domain.Entities.PlannedMeal, PlannedMealForGroupingDto>();
            CreateMap<Domain.Entities.PlannedMeal, PlannedMealDto>();
        }
    }
}