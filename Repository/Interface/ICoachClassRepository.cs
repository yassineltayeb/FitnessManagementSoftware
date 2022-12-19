using Domain.Entities;
using Repository.Helpers;

namespace Repository.Interface;
public interface ICoachClassRepository
{
    Task<CoachClass> AddCoachClass(CoachClass coachClass);
    Task<PagedResult<CoachClass>> GetCoachClasses(string searchTerm, int pageNumber, int pageSize);
    Task<CoachClass> GetCoachClassById(long coachClassId);
    Task<CoachClass> Update(CoachClass coachClass);
    Task<List<CoachClass>> GetCoachClassesInProcess();
    Task CoachClassesBulkUpdateStatus(List<long> coachClassIds, int statusId);
    Task<int> CoachClassesStatusCount(long coachId, int statusId);
}