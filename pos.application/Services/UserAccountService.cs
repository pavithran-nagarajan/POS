using pos.application.DTOs.UserAccount;
using pos.application.Interfaces;
using pos.domain.Entities;
using pos.domain.Interfaces;

namespace pos.application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _repository;

        public UserAccountService(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserAccount> CreateUser(CreateUserAccountDTO createUserAccountDTO)
        {
            var user = new UserAccount
            {
                UserName = createUserAccountDTO.UserName,
                PasswordHash = createUserAccountDTO.Password,
                UserPINHash = createUserAccountDTO.UserPIN,
                StaffName = createUserAccountDTO.StaffName,
                EmailAddress = createUserAccountDTO.EmailAddress,
                MobileNoCountryCode = createUserAccountDTO.MobileNoCountryCode,
                MobileNo = createUserAccountDTO.MobileNo,
                IsBlocked = createUserAccountDTO.IsBlocked,
                IsActive = createUserAccountDTO.IsActive,
                CreatedBy = createUserAccountDTO.CreatedBy,
                CreatedDateTime = DateTime.UtcNow
            };

            return await _repository.CreateUser(user);
        }
    }
}
