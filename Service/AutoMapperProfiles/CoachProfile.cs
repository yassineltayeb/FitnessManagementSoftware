using AutoMapper;
using Domain.Entities;
using Service.ViewModels.Coach;

namespace Service.AutoMapperProfiles;

public class CoachProfile : Profile
{
	public CoachProfile()
	{
		CreateMap<SignUpRequestViewModel, Coach>()
			.ForMember(desc => desc.FirstName, o => o.MapFrom(src => src.FirstName))
			.ForMember(desc => desc.LastName, o => o.MapFrom(src => src.LastName))
			.ForMember(desc => desc.Email, o => o.MapFrom(src => src.Email))
			.ForMember(desc => desc.Phone, o => o.MapFrom(src => src.Phone))
			.ForMember(desc => desc.DateOfBirth, o => o.MapFrom(src => src.DateOfBirth))
			.ForMember(desc => desc.Password, o => o.MapFrom(src => src.Password))
			.ReverseMap();
	}
}
