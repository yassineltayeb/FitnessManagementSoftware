using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Common;

namespace FitnessManagementSoftware.Controller;

[Route("api/coachTypes")]
[ApiController]
public class CoachTypesController : ControllerBase
{
    private readonly ICoachTypeService _coachTypeService;

    public CoachTypesController(ICoachTypeService coachTypeService)
    {
        _coachTypeService = coachTypeService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<KeyValuePairs>> GetCoachTypes()
    {
        return await _coachTypeService.GetCoachTypes();
    }
}