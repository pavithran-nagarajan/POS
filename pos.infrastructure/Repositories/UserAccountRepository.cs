using pos.domain.Entities;
using pos.domain.Interfaces;
using pos.infrastructure.Data;

namespace pos.infrastructure.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AppDbContext _context;

        public UserAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccount> CreateUser(UserAccount user)
        {
            _context.UserAccounts.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
