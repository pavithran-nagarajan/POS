
namespace pos.application.DTOs.AuthToken
{
    public class AuthTokenDto
    {
        public string AuthToken { get; set; } = string.Empty;
        public DateTime AuthTokenExpiry { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiry { get; set; }
    }
}
