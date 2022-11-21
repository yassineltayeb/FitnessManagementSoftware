using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Interface;

namespace Repository.Implementation
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICoachRepository CoachRepository =>  new CoachRepository(_dbContext);

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
}
