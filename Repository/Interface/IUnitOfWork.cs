namespace Repository.Interface;

public interface IUnitOfWork
{
    public ICoachRepository CoachRepository { get; }
    public ICoachTypeRepository CoachTypeRepository { get; }
    public IGenderRepository GenderRepository { get; }
    public ICountryRepository CountryRepository { get; }
    public ICityRepository CityRepository { get; }
    public IMemberRepository MemberRepository { get; }
    public IUserRepository UserRepository { get; }
    void BeginTransaction();
    Task<int> SaveAllAsync();
    Task Commit();
}
