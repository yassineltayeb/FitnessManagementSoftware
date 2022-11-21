using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels;

namespace FitnessManagementSoftware.Controller;

[Route("api/coaches")]
[ApiController]
public class CoachesController : ControllerBase
{
    private readonly ICoachService _coachService;

    public CoachesController(ICoachService coachService)
    {
        _coachService = coachService;
    }

    [HttpPost("signup")]
    public async Task<SignUpResponseViewModel> CoachSignUp([FromBody] SignUpRequestViewModel signUpRequestViewModel)
    {
        var signUpResponseViewModel = await _coachService.SignUp(signUpRequestViewModel);

        return signUpResponseViewModel;
    }
}
