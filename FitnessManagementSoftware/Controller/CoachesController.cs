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

    [HttpGet("{coachId}")]
    public async Task<UpdateCoachResponseViewModel> GetCoachById(long coachId)
    {
        return await _coachService.GetById(coachId);
    }

    [HttpPut("{coachId}")]
    public async Task<UpdateCoachResponseViewModel> UpdateCoach(long coachId, [FromBody] UpdateCoachRequestViewModel updateCoachRequestViewModel)
    {
        return await _coachService.Update(coachId, updateCoachRequestViewModel);
    }
}
