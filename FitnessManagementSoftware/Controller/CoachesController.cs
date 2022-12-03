using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Coach;

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

    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<SignUpResponseViewModel> CoachSignUp([FromBody] SignUpRequestViewModel signUpRequestViewModel)
    {
        return await _coachService.SignUp(signUpRequestViewModel);
    }
}
