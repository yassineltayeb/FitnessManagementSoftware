using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation;

public class MemberRepository : IMemberRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MemberRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Member> AddMember(Member member)
    {
        await _dbContext.Members.AddAsync(member);
        await _dbContext.SaveChangesAsync();

        return member;
    }

    public async Task<Member> GetMemberhByEmail(string email)
    {
        return await _dbContext.Members.SingleOrDefaultAsync(c => c.Email == email);
    }

    public async Task<bool> VerifyEmail(string email)
    {
        return await _dbContext.Members.AnyAsync(c => c.Email == email);
    }
}
