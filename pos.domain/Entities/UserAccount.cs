using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace pos.domain.Entities
{
    public class UserAccount
    {
        public long UserId { get; }

        public Guid UserIdGuid { get; } = Guid.NewGuid();

        public required string UserName { get; set; }

        public required string PasswordHash { get; set; }

        public required string UserPINHash { get; set; }

        public bool BitSuperAdmin { get; set; } = false;

        public string StaffName { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNoCountryCode { get; set; }

        public string MobileNo { get; set; }

        public bool BitBlocked { get; set; } = false;

        public bool BitActive { get; set; } = true;

        public long CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
