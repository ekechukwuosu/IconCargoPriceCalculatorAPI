using AutoMapper;
using IconCargoPriceCalculator.Models;

namespace IconCargoPriceCalculator.Mappings.Profiles
{
    public class CalculatedResponseProfiles : Profile
    {
        public CalculatedResponseProfiles()
        {
            CreateMap<PriceRequest, CalculatorResponse>()
                .ForMember(
                    dest => dest.CalculatedPrice,
                    opt => opt.MapFrom(src => $"{src.CalculatedPrice}")
                )
                .ForMember(
                    dest => dest.CalculatedDimension,
                    opt => opt.MapFrom(src => $"{src.CalculatedDimension}")
                );
        }
    }
}
