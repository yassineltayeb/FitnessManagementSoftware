using Domain.Entities;
using Repository.Interface;

namespace Repository.Implementation;

public class CoachClassRepository : ICoachClassRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CoachClassRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CoachClass> AddCoachClass(CoachClass coachClass)
    {
        await _dbContext.CoachClasses.AddAsync(coachClass);
        await _dbContext.SaveChangesAsync();

        return coachClass;
    }
}
