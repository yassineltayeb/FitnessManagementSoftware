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

    [HttpGet("test")]
    public async Task<List<KeyValuePairs>> GetCities()
    {
        var cities = new List<KeyValuePairs>() {
        new KeyValuePairs()
            {
                Id = 1,
                Name = "City 1"
            },
            new KeyValuePairs()
            {
                Id = 2,
                Name = "City 2"
            },
            new KeyValuePairs()
            {
                Id = 3,
                Name = "City 3"
            }};
        return cities;
    }
}
