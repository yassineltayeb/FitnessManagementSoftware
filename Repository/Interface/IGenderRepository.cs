using Domain.Entities;

namespace Repository.Interface;
public interface IGenderRepository
{
    Task<List<Gender>> GetGenders();
}