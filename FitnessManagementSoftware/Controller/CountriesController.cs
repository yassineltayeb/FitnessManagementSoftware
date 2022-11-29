using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Common;

namespace FitnessManagementSoftware.Controller;

[Route("api/countries")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<List<KeyValuePairs>> GetCountries()
    {
        return await _countryService.GetCountries();
    }
}
