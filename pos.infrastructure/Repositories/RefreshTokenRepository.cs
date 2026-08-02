using Microsoft.EntityFrameworkCore;
using pos.domain.Entities;
using pos.domain.Interfaces;
using pos.infrastructure.Data;

namespace pos.infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;

        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken token)
        {
            await _context.RefreshToken.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshToken
                .FirstOrDefaultAsync(t => t.Token == token && !t.IsRevoked);
        }

        public async Task RevokeAsync(RefreshToken token)
        {
            token.IsRevoked = true;
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}