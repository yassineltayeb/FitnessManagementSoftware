using AutoMapper;
using Repository.Interface;
using Service.Interface;
using Service.ViewModels.Common;

namespace Service.Implementation;
public class CoachTypeService : ICoachTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CoachTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<KeyValuePairs>> GetCoachTypes()
    {
        var coachTypes = await _unitOfWork.CoachTypeRepository.GetCoachTypes();

        return _mapper.Map<List<KeyValuePairs>>(coachTypes);
    }
}