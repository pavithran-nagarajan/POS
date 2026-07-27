using pos.application.DTOs;
using pos.domain.Entities;

namespace pos.application.Interfaces
{
    public interface IUserAccountService
    {
        Task<UserAccount> CreateUser(UserAccountDTO userAccount);
    }
}
