using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByEmail(string email, int userTypeId)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(c => c.Email == email && c.UserTypeId == userTypeId);
    }

    public async Task<bool> VerifyEmail(string email, int userTypeId)
    {
        return await _dbContext.Users.AnyAsync(c => c.Email == email && c.UserTypeId == userTypeId);
    }

    public async Task<bool> VerifyPhone(string phone, int userTypeId)
    {
        return await _dbContext.Users.AnyAsync(c => c.Phone == phone && c.UserTypeId == userTypeId);
    }
}
