using AutoMapper;
using backend.DTOs.Responses;
using backend.Models;

namespace backend.DTOs.Profiles
{
    public class PizzaMappingProfile : Profile
    {
        public PizzaMappingProfile()
        {
            CreateMap<PizzaOrder, PizzaOrderResponseDto>()
                .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
                .ForMember(dest => dest.ToppingNames, opt => opt.MapFrom(src => src.Toppings.Select(t => t.Name).ToList()));

            CreateMap<Topping, ToppingResponseDto>();
        }
    }
}
