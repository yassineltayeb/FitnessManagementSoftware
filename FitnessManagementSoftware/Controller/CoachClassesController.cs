using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Helpers;
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
    public async Task<AddCoachClassResponseViewModel> AddCoachClass(
        [FromBody] AddCoachClassRequestViewModel coachClassRequestViewModel)
    {
        return await _coachClassService.AddCoachClass(coachClassRequestViewModel);
    }

    [HttpGet]
    public async Task<PagedResult<GetCoachClassResponseViewModel>> GetCoachClasses(
        [FromQuery] GetCoachClassRequestViewModel getCoachClassRequestViewModel)
    {
        return await _coachClassService.GetCoachClasses(getCoachClassRequestViewModel);
    }
    
    [HttpGet("{coachClassId}")]
    public async Task<GetCoachClassResponseViewModel> GetCoachClassById(long coachClassId)
    {
        return await _coachClassService.GetCoachClassById(coachClassId);
    }
}