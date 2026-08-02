using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pos.application.DTOs.AuthToken;
using pos.application.Interfaces.AuthToken;
using pos.domain.Entities;
using pos.domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace pos.infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public TokenService(IOptions<JwtSettings> jwtSettings, IRefreshTokenRepository refreshTokenRepository)
        {
            _jwtSettings = jwtSettings.Value;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AuthTokenDto> GenerateTokensAsync(UserTokenRequestDto request)
        {
            //Auth token
            var authTokenExpiry = DateTime.UtcNow.AddMinutes(_jwtSettings.AuthTokenExpiryMinutes);
            var authToken = GenerateAuthToken(request.UserGuid, request.UserRole, authTokenExpiry);

            //Refresh token
            var refreshTokenExpiry = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays);
            var refreshTokenValue = GenerateRefreshTokenValue();

            //Store refresh token
            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Token = refreshTokenValue,
                ExpiresAt = refreshTokenExpiry
            };
            await _refreshTokenRepository.AddAsync(refreshTokenEntity);

            return new AuthTokenDto
            {
                AuthToken = authToken,
                AuthTokenExpiry = authTokenExpiry,
                RefreshToken = refreshTokenValue,
                RefreshTokenExpiry = refreshTokenExpiry
            };
        }

        public async Task<AuthTokenDto> RefreshTokenAsync(string refreshToken)
        {
            var storedToken = await _refreshTokenRepository.GetByTokenAsync(refreshToken)
                ?? throw new SecurityTokenException("Invalid refresh token.");

            if (storedToken.ExpiresAt < DateTime.UtcNow)
                throw new SecurityTokenException("Refresh token has expired.");

            // Revoke the old refresh token (rotation)
            await _refreshTokenRepository.RevokeAsync(storedToken);

            // NOTE: fetch the user's current role from DB here if roles can change.
            // For now we reuse UserGuid only; adjust as needed to pull fresh UserRole.
            var newRequest = new UserTokenRequestDto
            {
                UserId = storedToken.UserId,
                UserRole = await GetUserRoleAsync(storedToken.UserId)
            };

            return await GenerateTokensAsync(newRequest);
        }

        private string GenerateAuthToken(Guid userGuid, string userRole, DateTime expiry)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userGuid.ToString()),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GenerateRefreshTokenValue()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes);
        }

        // Stub — replace with actual lookup via your UserAccount repository/service.
        private Task<string> GetUserRoleAsync(int userId)
        {
            // e.g. var user = await _userRepository.GetByGuidAsync(userGuid); return user.Role;
            throw new NotImplementedException("Wire this up to your user repository to fetch current role.");
        }
    }
}