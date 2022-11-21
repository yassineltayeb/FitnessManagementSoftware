using Service.ViewModels;

namespace Service.Interface;
public interface ICoachService
{
    Task<SignUpResponseViewModel> SignUp(SignUpRequestViewModel signUpRequestViewModel);
}