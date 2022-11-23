namespace Repository.Interface;

public interface IUnitOfWork
{
    public ICoachRepository CoachRepository { get; }
    public IGenderRepository GenderRepository { get; }
    void BeginTransaction();
    Task<int> SaveAllAsync();
    Task Commit();
}
