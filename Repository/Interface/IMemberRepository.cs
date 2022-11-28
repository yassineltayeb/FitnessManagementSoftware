using Domain.Entities;

namespace Repository.Interface
{
    public interface IMemberRepository
    {
        Task<Member> AddMember(Member member);
        Task<Member> GetMemberhByEmail(string email);
        Task<bool> VerifyEmail(string email);
    }
}