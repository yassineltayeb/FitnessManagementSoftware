using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CountryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Country>> GetCountries()
    {
        var countries = await _dbContext.Countries.ToListAsync();

        if (countries is null)
            return new List<Country>();

        return countries;
    }
}
