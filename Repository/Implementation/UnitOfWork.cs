using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Interface;

namespace Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICoachRepository CoachRepository => new CoachRepository(_dbContext);
    public ICoachTypeRepository CoachTypeRepository => new CoachTypeRepository(_dbContext);
    public IGenderRepository GenderRepository => new GenderRepository(_dbContext);
    public ICountryRepository CountryRepository => new CountryRepository(_dbContext);
    public ICityRepository CityRepository => new CityRepository(_dbContext);
    public IMemberRepository MemberRepository => new MemberRepository(_dbContext);
    public IUserRepository UserRepository => new UserRepository(_dbContext);

    public async void BeginTransaction()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task<int> SaveAllAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task Commit()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }
}
