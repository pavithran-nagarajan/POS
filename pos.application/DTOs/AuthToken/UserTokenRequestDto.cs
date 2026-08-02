
namespace pos.application.DTOs.AuthToken
{
    public class UserTokenRequestDto
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string UserRole { get; set; } = string.Empty;
    }
}
