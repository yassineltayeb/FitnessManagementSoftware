using AutoMapper;
using Domain.Entities;
using Service.ViewModels.Common;

namespace Service.AutoMapperProfiles;

public class GenderProfile : Profile
{
	public GenderProfile()
	{
		CreateMap<Gender, KeyValuePairs>()
			.ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
			.ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
			.ReverseMap();
	}
}
