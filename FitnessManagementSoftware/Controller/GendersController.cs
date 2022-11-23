using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Common;

namespace FitnessManagementSoftware.Controller;

[Route("api/genders")]
[ApiController]
public class GendersController : ControllerBase
{
    private readonly IGenderService _genderService;

    public GendersController(IGenderService genderService)
    {
        _genderService = genderService;
    }

    [HttpGet]
    public async Task<List<KeyValuePairs>> GetGenders()
    {
        return await _genderService.GetGenders();
    }
}
