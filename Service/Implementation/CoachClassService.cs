using System;
using System.Net;
using AutoMapper;
using Domain.Entities;
using Repository.Enum;
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

        coachClassToAdd.StatusId = (int)CoachClassStatusEnum.Booking;

        coachClassToAdd.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        var coachClass = await _unitOfWork.CoachClasses.AddCoachClass(coachClassToAdd);

        return _mapper.Map<AddCoachClassResponseViewModel>(coachClass);
    }

    public async Task<PagedResult<GetCoachClassResponseViewModel>> GetCoachClasses(GetCoachClassRequestViewModel getCoachClassRequest)
    {
        if (getCoachClassRequest.StatusIds.Count!=0)
        {
            if (!getCoachClassRequest.StatusIds.All(x => Enum.IsDefined(typeof(CoachClassStatusEnum), x)))
                throw new APIException((int)HttpStatusCode.BadGateway, "Invalid StatusIds");
        }

        var coachCLassesPaged = await _unitOfWork.CoachClasses.GetCoachClasses(getCoachClassRequest.searchTerm,
                                                                               getCoachClassRequest.StatusIds,
                                                                               getCoachClassRequest.ClassFrom,
                                                                               getCoachClassRequest.ClassTo,
                                                                               getCoachClassRequest.PageNumber,
                                                                               getCoachClassRequest.PageSize);
        var coachClasses = _mapper.Map<List<GetCoachClassResponseViewModel>>(coachCLassesPaged.Data);

        // Calculate Duration
        coachClasses.ForEach(coachClass =>
        {
            var classTo = coachCLassesPaged.Data.SingleOrDefault(cc => cc.Id == coachClass.Id).ClassTo;
            coachClass.Duration = (classTo - coachClass.ClassDate).TotalMinutes;
        });

        return coachClasses.GetPagedViewModel(coachCLassesPaged.TotalItems, coachCLassesPaged.CurrentPage,
                                                                      coachCLassesPaged.ItemsPerPage);
    }

    public async Task<GetCoachClassResponseViewModel> GetCoachClassById(long coachClassId)
    {
        var coachClass = await _unitOfWork.CoachClasses.GetCoachClassById(coachClassId);

        if (coachClass is null)
            throw new APIException((int)HttpStatusCode.NotFound, "Invalid CoachClassId");

        var coachClassResponse = _mapper.Map<GetCoachClassResponseViewModel>(coachClass);

        coachClassResponse.Duration = (coachClass.ClassTo - coachClass.ClassFrom).TotalMinutes;

        return coachClassResponse;
    }

    public async Task<GetCoachClassResponseViewModel> UpdateCoachClass(long coachClassId, AddCoachClassRequestViewModel addCoachClassRequest)
    {
        var coachClass = await _unitOfWork.CoachClasses.GetCoachClassById(coachClassId);

        if (coachClass is null)
            throw new APIException((int)HttpStatusCode.NotFound, "Invalid CoachClassId");

        var coachClassToUpdate =
            _mapper.Map(addCoachClassRequest, coachClass);
             
        var updatedCoachClass = await _unitOfWork.CoachClasses.Update(coachClassToUpdate);

        return _mapper.Map<GetCoachClassResponseViewModel>(updatedCoachClass);
    }

    public async Task<GetCoachClassResponseViewModel> UpdateCoachClassStatus(long coachClassId, CoachClassStatusEnum statusId)
    {
        var coachClass = await _unitOfWork.CoachClasses.GetCoachClassById(coachClassId);

        if (coachClass is null)
            throw new APIException((int)HttpStatusCode.NotFound, "Invalid CoachClassId");

        coachClass.StatusId = (int)statusId;

        var updatedCoachClass = await _unitOfWork.CoachClasses.Update(coachClass);

        return _mapper.Map<GetCoachClassResponseViewModel>(updatedCoachClass);
    }

    public async Task<List<GetCoachClassResponseViewModel>> GetCoachClassesInProcess()
    {
        var coachClasses = await _unitOfWork.CoachClasses.GetCoachClassesInProcess();

        return _mapper.Map<List<GetCoachClassResponseViewModel>>(coachClasses);
    }

    public async Task CoachClassesBulkUpdateStatus(List<long> coachClassIds, int statusId)
    {
        await _unitOfWork.CoachClasses.CoachClassesBulkUpdateStatus(coachClassIds, statusId);
    }

    public async Task<CoachClassStatusSummaryViewModel> CoachClassesStatusCount(long coachClassId)
    {
        var coachClassStatusSummaryViewModel = new CoachClassStatusSummaryViewModel()
        {
            Booking = await _unitOfWork.CoachClasses.CoachClassesStatusCount(coachClassId, (int)CoachClassStatusEnum.Booking),
            OnProgress = await _unitOfWork.CoachClasses.CoachClassesStatusCount(coachClassId, (int)CoachClassStatusEnum.OnProgress),
            Finished = await _unitOfWork.CoachClasses.CoachClassesStatusCount(coachClassId, (int)CoachClassStatusEnum.Finished),
            Canceled = await _unitOfWork.CoachClasses.CoachClassesStatusCount(coachClassId, (int)CoachClassStatusEnum.Canceled)
        };

        return coachClassStatusSummaryViewModel;
    }
}