using AutoMapper;
using Repository.Interface;
using Service.Interface;
using Service.ViewModels.Common;

namespace Service.Implementation;

public class CountryService : ICountryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<KeyValuePairs>> GetCountries()
    {
        var countries = await _unitOfWork.Counties.GetCountries();

        return _mapper.Map<List<KeyValuePairs>>(countries);
    }
}
