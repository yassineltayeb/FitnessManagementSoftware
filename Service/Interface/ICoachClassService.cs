using Repository.Helpers;
using Service.ViewModels.CoachClass;

namespace Service.Interface;

public interface ICoachClassService
{
    Task<AddCoachClassResponseViewModel> AddCoachClass(AddCoachClassRequestViewModel addCoachClassRequest);

    Task<PagedResult<GetCoachClassResponseViewModel>> GetCoachClasses(
        GetCoachClassRequestViewModel getCoachClassRequest);
}