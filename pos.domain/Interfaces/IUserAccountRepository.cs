using pos.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pos.domain.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> CreateUser(UserAccount userAccount);
    }
}
