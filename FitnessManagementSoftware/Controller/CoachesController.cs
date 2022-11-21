using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Coach;

namespace FitnessManagementSoftware.Controller;

[Route("api/coaches")]
[Authorize]
[ApiController]
public class CoachesController : ControllerBase
{
    private readonly ICoachService _coachService;

    public CoachesController(ICoachService coachService)
    {
        _coachService = coachService;
    }

    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<SignUpResponseViewModel> CoachSignUp([FromBody] SignUpRequestViewModel signUpRequestViewModel)
    {
        var signUpResponseViewModel = await _coachService.SignUp(signUpRequestViewModel);

        return signUpResponseViewModel;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<SignUpResponseViewModel> CoachLogin([FromBody] LoginRequestViewModel loginRequestViewModel)
    {
        var signUpResponseViewModel = await _coachService.Login(loginRequestViewModel);

        return signUpResponseViewModel;
    }
}
