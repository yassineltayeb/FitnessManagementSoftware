using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Coach;
using Service.ViewModels.CoachClass;

namespace FitnessManagementSoftware.Controller;

[Route("api/coaches/classes")]
[ApiController]
public class CoachClassesController : ControllerBase
{
    private readonly ICoachClassService _coachClassService;

    public CoachClassesController(ICoachService coachService, ICoachClassService coachClassService)
    {
        _coachClassService = coachClassService;
    }

    [HttpPost]
    public async Task<AddCoachClassResponseViewModel> AddCoachClass([FromBody] AddCoachClassRequestViewModel coachClassRequestViewModel)
    {
        return await _coachClassService.AddCoachClass(coachClassRequestViewModel);
    }
}
