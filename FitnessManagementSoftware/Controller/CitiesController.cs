using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Common;

namespace FitnessManagementSoftware.Controller;

[Route("api/cities")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;

    public CitiesController(ICityService cityService)
	{
        _cityService = cityService;
    }

    [HttpGet()]
    public async Task<List<KeyValuePairs>> GetCitiesByCountryId(int countryId)
    {
        return await _cityService.GetCitiesByCountryId(countryId);
    }
}
