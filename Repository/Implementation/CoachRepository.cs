using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;

public class CoachRepository : ICoachRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CoachRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Coach> AddCoach(Coach coach)
    {
        await _dbContext.Coaches.AddAsync(coach);
        await _dbContext.SaveChangesAsync();

        return coach;
    }

    public async Task<Coach> GetCoachByEmail(string email)
    {
        return await _dbContext.Coaches.SingleOrDefaultAsync(c => c.Email == email);
    }
}
