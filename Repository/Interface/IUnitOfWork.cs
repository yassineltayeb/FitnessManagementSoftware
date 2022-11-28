namespace Repository.Interface;

public interface IUnitOfWork
{
    public ICoachRepository CoachRepository { get; }
    public IGenderRepository GenderRepository { get; }
    public ICountryRepository CountryRepository { get; }
    public ICityRepository CityRepository{ get; }
    public IMemberRepository MemberRepository{ get; }
    void BeginTransaction();
    Task<int> SaveAllAsync();
    Task Commit();
}
