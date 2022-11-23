using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;
public class GenderRepository : IGenderRepository
{
    private readonly ApplicationDbContext _dbContext;
    public GenderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Gender>> GetGenders()
    {
        var genders = await _dbContext.Genders.ToListAsync();

        if(genders is null)
            return new List<Gender>();

        return genders;
    }
}