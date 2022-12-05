using Domain.Entities;

namespace Repository.Interface;
public interface ICoachClassRepository
{
    Task<CoachClass> AddCoachClass(CoachClass coachClass);
}