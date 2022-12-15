using Repository.Enum;
using Repository.Helpers;
using Service.ViewModels.CoachClass;

namespace Service.Interface;

public interface ICoachClassService
{
    Task<AddCoachClassResponseViewModel> AddCoachClass(AddCoachClassRequestViewModel addCoachClassRequest);

    Task<PagedResult<GetCoachClassResponseViewModel>> GetCoachClasses(
        GetCoachClassRequestViewModel getCoachClassRequest);

    Task<GetCoachClassResponseViewModel> GetCoachClassById(long coachClassId);

    Task<GetCoachClassResponseViewModel> UpdateCoachClass(long coachClassId,
        AddCoachClassRequestViewModel addCoachClassRequest);

    Task<GetCoachClassResponseViewModel> UpdateCoachClassStatus(long coachClassId, CoachClassStatusEnum statusId);
}