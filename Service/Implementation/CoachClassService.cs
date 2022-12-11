using System.Net;
using AutoMapper;
using Domain.Entities;
using Repository.Extensions;
using Repository.Helpers;
using Repository.Interface;
using Service.Exceptions;
using Service.Interface;
using Service.ViewModels.CoachClass;

namespace Service.Implementation;

public class CoachClassService : ICoachClassService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CoachClassService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AddCoachClassResponseViewModel> AddCoachClass(AddCoachClassRequestViewModel addCoachClassRequest)
    {
        var coach = await _unitOfWork.Coaches.GetCoachById(addCoachClassRequest.CoachId);

        if (coach is null)
            throw new APIException((int)HttpStatusCode.NotFound, "Invalid CoachId");

        var coachClassToAdd = _mapper.Map<CoachClass>(addCoachClassRequest);

        coachClassToAdd.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        var coachClass = await _unitOfWork.CoachClasses.AddCoachClass(coachClassToAdd);

        return _mapper.Map<AddCoachClassResponseViewModel>(coachClass);
    }

    public async Task<PagedResult<GetCoachClassResponseViewModel>> GetCoachClasses(GetCoachClassRequestViewModel getCoachClassRequest)
    {
        var coachCLassesPaged = await _unitOfWork.CoachClasses.GetCoachClasses(getCoachClassRequest.searchTerm,
                                                                               getCoachClassRequest.PageNumber, 
                                                                               getCoachClassRequest.PageSize);
        var coachClasses = _mapper.Map<List<GetCoachClassResponseViewModel>>(coachCLassesPaged.Data);
        
        // Calculate Duration
        coachClasses.ForEach(coachClass =>
        {
            var classTo = coachCLassesPaged.Data.SingleOrDefault(cc => cc.Id == coachClass.Id).ClassTo;
            coachClass.Duration = (classTo - coachClass.ClassDate).TotalMinutes;
        });

        return coachClasses.GetPagedViewModel<GetCoachClassResponseViewModel>(coachCLassesPaged.TotalItems,coachCLassesPaged.CurrentPage,
                                                                      coachCLassesPaged.ItemsPerPage);
    }
    
    public async Task<GetCoachClassResponseViewModel> GetCoachClassById(long coachClassId)
    {
        var coachClass = await _unitOfWork.CoachClasses.GetCoachClassById(coachClassId);
        
        if (coachClass is null)
            throw new APIException((int)HttpStatusCode.NotFound, "Invalid CoachClassId");

        var coachClassResponse =  _mapper.Map<GetCoachClassResponseViewModel>(coachClass);

        coachClassResponse.Duration = (coachClass.ClassFrom - coachClass.ClassTo).TotalMinutes;

        return coachClassResponse;
    }
}