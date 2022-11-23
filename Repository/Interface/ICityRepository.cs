using Domain.Entities;

namespace Repository.Interface;

public interface ICityRepository
{
    Task<List<City>> GetCitiesByCountryId(int countryId);
}