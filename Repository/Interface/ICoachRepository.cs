using Domain.Entities;

namespace Repository.Interface;

public interface ICoachRepository
{
    Task<Coach> AddCoach(Coach coach);
    Task<Coach> GetCoachByEmail(string email);
}
