using Service.ViewModels.Coach;

namespace Service.Interface;
public interface ICoachService
{
    Task<SignUpResponseViewModel> SignUp(SignUpRequestViewModel signUpRequestViewModel);
    Task<UpdateCoachResponseViewModel> Update(long coachId, UpdateCoachRequestViewModel updateCoachRequestViewModel);
}