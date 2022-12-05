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

    public ICoachRepository Coaches => new CoachRepository(_dbContext);
    public ICoachClassRepository CoachClasses => new CoachClassRepository(_dbContext);
    public ICoachTypeRepository CoachTypes => new CoachTypeRepository(_dbContext);
    public IGenderRepository Genders => new GenderRepository(_dbContext);
    public ICountryRepository Counties => new CountryRepository(_dbContext);
    public ICityRepository Cities => new CityRepository(_dbContext);
    public IMemberRepository Members => new MemberRepository(_dbContext);
    public IUserRepository Users => new UserRepository(_dbContext);

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
