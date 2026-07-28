using pos.application.DTOs.UserAccount;
using pos.domain.Entities;

namespace pos.application.Interfaces
{
    public interface IUserAccountService
    {
        Task<UserAccount> CreateUser(CreateUserAccountDTO createUserAccountDTO);
    }
}
