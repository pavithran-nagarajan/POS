using pos.application.DTOs;
using pos.application.Interfaces;
using pos.domain.Entities;
using pos.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace pos.application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _repository;

        public UserAccountService(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserAccount> CreateUser(UserAccountDTO userAccount)
        {
            var user = new UserAccount
            {
                UserName = userAccount.UserName,
                PasswordHash = userAccount.PasswordHash,
                UserPINHash = userAccount.UserPINHash,
                StaffName = userAccount.StaffName,
                EmailAddress = userAccount.EmailAddress,
                MobileNoCountryCode = userAccount.MobileNoCountryCode,
                MobileNo = userAccount.MobileNo,
                BitBlocked = userAccount.BitBlocked,
                BitActive = userAccount.BitActive,
                CreatedBy = userAccount.CreatedBy,
                CreatedDateTime = DateTime.UtcNow
            };

            return await _repository.CreateUser(user);
        }
    }
}
