using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CityRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<City>> GetCitiesByCountryId(int countryId)
    {
        var cities = await _dbContext.Cities
                                        .Where(c => c.CountryId == countryId)
                                        .ToListAsync();

        if (cities is null)
            return new List<City>();

        return cities;
    }
}
