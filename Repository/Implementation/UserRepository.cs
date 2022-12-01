using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;

public class UserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Coach> AddUser(Coach coach)
    {
        await _dbContext.Coaches.AddAsync(coach);
        await _dbContext.SaveChangesAsync();

        return coach;
    }

    public async Task<Coach> GetCoachByEmail(string email)
    {
        return await _dbContext.Coaches.SingleOrDefaultAsync(c => c.Email == email);
    }

    public async Task<bool> VerifyEmail(string email)
    {
        return await _dbContext.Coaches.AnyAsync(c => c.Email == email);
    }

    public async Task<bool> VerifyPhone(string phone)
    {
        return await _dbContext.Coaches.AnyAsync(c => c.Phone == phone);
    }
}
