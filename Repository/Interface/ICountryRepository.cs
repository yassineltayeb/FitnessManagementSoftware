using Domain.Entities;

namespace Repository.Interface;

public interface ICountryRepository
{
    Task<List<Country>> GetCountries();
}