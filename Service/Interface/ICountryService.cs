using Service.ViewModels.Common;

namespace Service.Interface;

public interface ICountryService
{
    Task<List<KeyValuePairs>> GetCountries();
}