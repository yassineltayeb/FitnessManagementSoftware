using Service.ViewModels.Common;

namespace Service.Interface;

public interface ICityService
{
    Task<List<KeyValuePairs>> GetCitiesByCountryId(int countryId);
}