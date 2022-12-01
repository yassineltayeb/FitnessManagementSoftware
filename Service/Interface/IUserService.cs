using Service.ViewModels.Coach;

namespace Service.Interface;
public interface IUserService
{
    Task<SignUpResponseViewModel> Login(LoginRequestViewModel loginRequestViewModel);
}