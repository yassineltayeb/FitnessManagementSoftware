using Service.ViewModels.Coach;

namespace Service.Interface;
public interface ICoachService
{
    Task<SignUpResponseViewModel> SignUp(SignUpRequestViewModel signUpRequestViewModel);
    Task<UpdateCoachResponseViewModel> GetById(long coachId);
    Task<UpdateCoachResponseViewModel> Update(long coachId, UpdateCoachRequestViewModel updateCoachRequestViewModel);
}