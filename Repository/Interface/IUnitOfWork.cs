namespace Repository.Interface;

public interface IUnitOfWork
{
    public ICoachRepository CoachRepository { get; }
    void BeginTransaction();
    Task<int> SaveAllAsync();
    Task Commit();
}
