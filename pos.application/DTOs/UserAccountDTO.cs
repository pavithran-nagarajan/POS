using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pos.application.DTOs
{
    public class UserAccountDTO
    {
        public Guid UserIdGuid { get; } = Guid.NewGuid();

        [Required(ErrorMessage = "User name required")]
        [StringLength(10)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password required")]
        [StringLength(25)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "PIN required")]
        [StringLength(6)]
        public string UserPINHash { get; set; } = string.Empty;

        public bool BitSuperAdmin { get; set; } = false;

        [StringLength(50)]
        public string StaffName { get; set; }

        [StringLength(254)]
        public string EmailAddress { get; set; }

        [StringLength(4)]
        public string MobileNoCountryCode { get; set; }

        [StringLength(15)]
        public string MobileNo { get; set; }

        public bool BitBlocked { get; set; } = false;

        public bool BitActive { get; set; } = true;

        public long CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
