using AutoMapper;
using Domain.Entities;
using Service.ViewModels.CoachClass;

namespace Service.AutoMapperProfiles;

public class CoachClassProfile : Profile
{
    public CoachClassProfile()
    {
        CreateMap<AddCoachClassRequestViewModel, CoachClass>()
            .ForMember(dest => dest.CoachId, o => o.MapFrom(src => src.CoachId))
            .ForMember(dest => dest.Title, o => o.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, o => o.MapFrom(src => src.Description))
            .ForMember(dest => dest.Location, o => o.MapFrom(src => src.Location))
            .ForMember(dest => dest.ClassFrom, o => o.MapFrom(src => src.ClassDate))
            .ForMember(dest => dest.ClassTo, o => o.MapFrom(src => src.ClassDate.AddMinutes(src.Duration)))
            .ForMember(dest => dest.AvailbleSpaces, o => o.MapFrom(src => src.ClassDate.AddMinutes(src.AvailbleSpaces)))
            .ReverseMap();
    }
}