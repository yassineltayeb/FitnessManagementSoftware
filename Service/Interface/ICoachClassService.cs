using Service.ViewModels.CoachClass;

namespace Service.Interface;

public interface ICoachClassService
{
    Task<AddCoachClassResponseViewModel> AddCoachClass(AddCoachClassRequestViewModel addCoachClassRequest);
}