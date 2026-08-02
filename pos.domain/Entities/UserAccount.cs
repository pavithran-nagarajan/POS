
namespace pos.domain.Entities
{
    public class UserAccount
    {
        public long UserId { get; set; }
        public Guid UserGuid { get; set; }
        public int CompanyId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string UserPINHash { get; set; } = string.Empty;
        public bool IsSuperAdmin { get; set; } = false;
        public string? StaffName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNoCountryCode { get; set; }
        public string? MobileNo { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
