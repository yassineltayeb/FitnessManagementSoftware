using AutoMapper;
using Domain.Entities;
using Service.ViewModels.Common;

namespace Service.AutoMapperProfiles;

public class CountryProfile : Profile
{
	public CountryProfile()
	{
		CreateMap<Country, KeyValuePairs>()
			.ForMember(dest => dest.Id, o => o.MapFrom(src => src.id))
			.ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
			.ReverseMap();
	}
}
