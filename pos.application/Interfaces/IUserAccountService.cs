using pos.application.DTOs.UserAccount;

namespace pos.application.Interfaces
{
    public interface IUserAccountService
    {
        Task<ResponseUserAccountDTO> CreateUser(CreateUserAccountDTO createUserAccountDTO);
    }
}
