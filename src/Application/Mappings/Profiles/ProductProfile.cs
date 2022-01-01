using AutoMapper;
using FoodPlanner.Application.Mappings.Dtos.Product;

namespace FoodPlanner.Application.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
        }
    }
}
