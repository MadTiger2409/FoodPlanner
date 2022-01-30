using AutoMapper;
using FoodPlanner.Application.Mappings.Dtos.Category;

namespace FoodPlanner.Application.Mappings.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Domain.Entities.Category, CategoryDto>();
        }
    }
}