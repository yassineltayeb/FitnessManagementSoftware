using Service.ViewModels.Coach;

namespace Service.Interface;

public interface IMemberService
{
    Task<SignUpResponseViewModel> Login(LoginRequestViewModel loginRequestViewModel);
    Task<SignUpResponseViewModel> SignUp(SignUpRequestViewModel signUpRequestViewModel);
}