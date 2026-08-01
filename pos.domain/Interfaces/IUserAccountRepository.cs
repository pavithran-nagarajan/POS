using pos.domain.Entities;

namespace pos.domain.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> CreateUser(UserAccount userAccount);
    }
}
