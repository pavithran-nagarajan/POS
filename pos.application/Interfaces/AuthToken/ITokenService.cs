using pos.application.DTOs.AuthToken;

namespace pos.application.Interfaces.AuthToken
{
    public interface ITokenService
    {
        Task<AuthTokenDto> GenerateTokensAsync(UserTokenRequestDto request);
        Task<AuthTokenDto> RefreshTokenAsync(string refreshToken);
    }
}
