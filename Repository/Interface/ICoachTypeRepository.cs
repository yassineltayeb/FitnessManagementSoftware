using Domain.Entities;

namespace Repository.Interface;
public interface ICoachTypeRepository
{
    Task<List<CoachType>> GetCoachTypes();
}