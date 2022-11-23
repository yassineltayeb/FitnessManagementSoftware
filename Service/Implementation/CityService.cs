using AutoMapper;
using Repository.Interface;
using Service.Interface;
using Service.ViewModels.Common;

namespace Service.Implementation;

public class CityService : ICityService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<KeyValuePairs>> GetCitiesByCountryId(int countryId)
    {
        var cities = await _unitOfWork.CityRepository.GetCitiesByCountryId(countryId);

        return _mapper.Map<List<KeyValuePairs>>(cities);
    }
}
