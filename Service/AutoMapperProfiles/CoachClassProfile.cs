using AutoMapper;
using Domain.Entities;
using Service.ViewModels.CoachClass;
using Service.ViewModels.Common;

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
            .ForMember(dest => dest.AvailbleSpaces, o => o.MapFrom(src => src.AvailbleSpaces))
            .ReverseMap();

        CreateMap<Coach, KeyValuePairs>()
            .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, o => o.MapFrom(src => src.FirstName + ' ' + src.LastName))
            .ReverseMap();

        CreateMap<AddCoachClassResponseViewModel, CoachClass>()
            .ForMember(dest => dest.Coach, o => o.MapFrom(src => src.Coach))
            .ForMember(dest => dest.Title, o => o.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, o => o.MapFrom(src => src.Description))
            .ForMember(dest => dest.Location, o => o.MapFrom(src => src.Location))
            .ForMember(dest => dest.ClassFrom, o => o.MapFrom(src => src.ClassDate))
            .ForMember(dest => dest.ClassTo, o => o.MapFrom(src => src.ClassDate.AddMinutes(src.Duration)))
            .ForMember(dest => dest.AvailbleSpaces, o => o.MapFrom(src => src.AvailbleSpaces))
            .ReverseMap();
    }
}