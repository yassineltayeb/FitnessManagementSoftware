namespace Repository.Interface;

public interface IUnitOfWork
{
    public ICoachRepository Coaches { get; }
    public ICoachClassRepository CoachClasses { get; }
    public ICoachTypeRepository CoachTypes { get; }
    public IGenderRepository Genders { get; }
    public ICountryRepository Counties { get; }
    public ICityRepository Cities { get; }
    public IMemberRepository Members { get; }
    public IUserRepository Users { get; }
    void BeginTransaction();
    Task<int> SaveAllAsync();
    Task Commit();
}
