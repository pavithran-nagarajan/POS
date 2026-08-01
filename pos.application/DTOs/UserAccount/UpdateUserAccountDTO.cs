using System.ComponentModel.DataAnnotations;

namespace pos.application.DTOs.UserAccount
{
    public class UpdateUserAccountDTO
    {
        public long UserId { get; set; }

        public bool BitSuperAdmin { get; set; } = false;

        [StringLength(100)]
        public string? StaffName { get; set; }

        [StringLength(254)]
        public string? EmailAddress { get; set; }

        [StringLength(4)]
        public string? MobileNoCountryCode { get; set; }

        [StringLength(15)]
        public string? MobileNo { get; set; }

        public bool BitBlocked { get; set; } = false;

        public bool BitActive { get; set; } = true;

        public int CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
