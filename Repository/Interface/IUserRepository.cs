using Domain.Entities;

namespace Repository.Interface;
public interface IUserRepository
{
    Task<User> GetUserByEmail(string email, int userTypeId);
    Task<bool> VerifyEmail(string email, int userTypeId);
    Task<bool> VerifyPhone(string phone, int userTypeId);
}