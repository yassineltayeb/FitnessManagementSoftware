using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Enum;
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

    public async Task<PagedResult<CoachClass>> GetCoachClasses(string searchTerm, List<int> statusIds,
        DateOnly? classFrom, DateOnly? classTo,
        int pageNumber, int pageSize)
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

        if (statusIds.Count != 0)
        {
            coachClassesQuery = coachClassesQuery.Where(cc => statusIds.Contains(cc.StatusId));
        }

        if (classFrom != null)
            coachClassesQuery = coachClassesQuery.Where(cc => cc.ClassFrom >= ConvertDateOnlyToDateTime(classFrom ?? new DateOnly()));

        if (classTo != null)
            coachClassesQuery = coachClassesQuery.Where(cc => cc.ClassTo <= ConvertDateOnlyToDateTime(classTo ?? new DateOnly()));

        return await coachClassesQuery.GetPaged(pageNumber, pageSize);
    }

    public async Task<CoachClass> GetCoachClassById(long coachClassId)
    {
        return await _dbContext.CoachClasses
                                .Include(cc => cc.Coach)
                                .SingleOrDefaultAsync(cc => cc.Id == coachClassId);
    }

    public async Task<CoachClass> Update(CoachClass coachClass)
    {
        _dbContext.CoachClasses.Update(coachClass);
        await _dbContext.SaveChangesAsync();

        return coachClass;
    }

    public async Task<List<CoachClass>> GetCoachClassesInProcess()
    {
        var inProcessStatusIds = new List<int>
        {
            (int)CoachClassStatusEnum.Booking,
            (int)CoachClassStatusEnum.OnProgress
        };

        var coachClasses = await _dbContext.CoachClasses
                                            .Where(cc => inProcessStatusIds.Contains(cc.StatusId))
                                            .Include(cc => cc.Coach)
                                            .ToListAsync();


        return coachClasses;
    }

    public async Task CoachClassesBulkUpdateStatus(List<long> coachClassIds, int statusId)
    {
        var coachClasses = await _dbContext.CoachClasses
                                            .Where(cc => coachClassIds.Contains(cc.Id))
                                            .ExecuteUpdateAsync(cc => cc.SetProperty(s => s.StatusId, s => statusId));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> CoachClassesStatusCount(long coachId, int statusId)
    {
        return await _dbContext.CoachClasses
                                 .CountAsync(cc => cc.CoachId == coachId &&
                                             cc.StatusId == statusId);
    }

    private DateTime ConvertDateOnlyToDateTime(DateOnly date)
    {
        return date.ToDateTime(TimeOnly.Parse("00.00 AM"));
    }
}