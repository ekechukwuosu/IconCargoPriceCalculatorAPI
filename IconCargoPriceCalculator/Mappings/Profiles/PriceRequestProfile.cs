using AutoMapper;
using IconCargoPriceCalculator.Models;
using IconCargoPriceCalculator.Models.Request;

namespace IconCargoPriceCalculator.Mappings.Profiles
{
    public class PriceRequestProfile : Profile
    {
        public PriceRequestProfile()
        {
            CreateMap<InputRequest, PriceRequest>()
                .ForMember(
                    dest => dest.Height,
                    opt => opt.MapFrom(src => $"{src.Height}")
                )
                .ForMember(
                    dest => dest.Width,
                    opt => opt.MapFrom(src => $"{src.Width}")
                )
                .ForMember(
                    dest => dest.Depth,
                    opt => opt.MapFrom(src => $"{src.Depth}")
                )
                 .ForMember(
                    dest => dest.Weight,
                    opt => opt.MapFrom(src => src.Weight)
                )
                 .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => DateTime.Now)
                );
        }
    }
}
