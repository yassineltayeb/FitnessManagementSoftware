using AutoMapper;
using Repository.Interface;
using Service.Interface;
using Service.ViewModels.Common;

namespace Service.Implementation;

public class GenderService : IGenderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<KeyValuePairs>> GetGenders()
    {
        var genders = await _unitOfWork.GenderRepository.GetGenders();

        return _mapper.Map<List<KeyValuePairs>>(genders);
    }
}
