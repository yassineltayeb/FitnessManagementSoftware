using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;

public class CoachTypeRepository : ICoachTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CoachTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CoachType>> GetCoachTypes()
    {
        return await _dbContext.CoachTypes.ToListAsync();
    }
}
