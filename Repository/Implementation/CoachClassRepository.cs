using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Repository.Helpers;
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

    public async Task<PagedResult<CoachClass>> GetCoachClasses(string searchTerm, int pageNumber, int pageSize)
    {
        var coachClassesQuery = _dbContext.CoachClasses
            .Include(cc => cc.Coach)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            coachClassesQuery = coachClassesQuery
                .Where(cc => cc.Title.Contains(searchTerm) ||
                             cc.Description.Contains(searchTerm) ||
                             cc.Location.Contains(searchTerm));
        }

        return await coachClassesQuery.GetPaged(pageNumber, pageSize);
    }

    public async Task<CoachClass> GetCoachClassById(long coachClassId)
    {
        return await _dbContext.CoachClasses.SingleOrDefaultAsync(cc => cc.Id == coachClassId);
    }

    public async Task<CoachClass> Update(CoachClass coachClass)
    {
        _dbContext.CoachClasses.Update(coachClass);
        await _dbContext.SaveChangesAsync();

        return coachClass;
    }
}