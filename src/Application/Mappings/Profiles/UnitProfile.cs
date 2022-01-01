using AutoMapper;
using FoodPlanner.Application.Mappings.Dtos.Unit;

namespace FoodPlanner.Application.Mappings.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Domain.Entities.Unit, UnitDto>();
        }
    }
}
